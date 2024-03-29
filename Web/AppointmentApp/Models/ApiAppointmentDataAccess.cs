﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using NormalFactory.AppointmentApp.Data;

namespace NormalFactory.AppointmentApp.Web.Models
{

    /// <summary>
    /// Gets appointment information from API
    /// </summary>
    public class ApiAppointmentDataAccess: IAppointmentDataAccess
    {
        #region Private Properties

        /// <summary>
        /// URL to the endpoint that contains the appointment information
        /// </summary>
        private const string _apiUrl = "https://sampledata.petdesk.com/api/appointments";

        /// <summary>
        /// Key within the cache that contains list of AppointmentRequestDetail
        /// </summary>
        private const string _appointmentCacheKey = "appointments";

        /// <summary>
        /// Reference to HTTP client for making requests
        /// </summary>
        private readonly IHttpClientFactory _clientFactory;

        /// <summary>
        /// Reference to the cache
        /// </summary>
        private readonly IMemoryCache _appointmentCache;

        #endregion



        #region Constructor

        /// <summary>
        /// Creates a new instance sets the default values
        /// </summary>
        /// <param name="clientFactory">Reference to HTTP client; from dependency injection</param>
        /// <param name="memoryCache">Reference to memory cache; from dependency injection</param>
        public ApiAppointmentDataAccess(IHttpClientFactory clientFactory, IMemoryCache memoryCache)
        {
            _clientFactory = clientFactory;
            _appointmentCache = memoryCache;
        }

        #endregion



        #region Get Appointments

        /// <summary>
        /// Returns list of appointents based on the status provided; searches for current session
        /// that is stored in cache; not found then pulls appointments from API
        /// </summary>
        /// <param name="status">Status to filter the records for</param>
        /// <returns>Information requested</returns>
        public async Task<AppointmentModel> GetAppointmentsAsync(AppointmentApprovalStatuses status)
        {
            //- Get Appointments
            var allAppointments = await GetAppointmentsAsync();


            //- Calcualate Counts
            AppointmentModel model = new AppointmentModel();

            model.StatusInfo = CalculateStatusCounts(allAppointments);


            //- Filter Appointments
            model.Appointments = (from item in allAppointments
                                      where (item.Status == status)
                                      orderby item.RequestedDateTimeOffset ascending
                                      select item).ToList();

            return model;
        }

        #endregion



        #region Change Status of Appointment

        /// <summary>
        /// Sets the alternative time for the appointment
        /// </summary>
        /// <param name="appointmentID">Unique identifier for the appointment</param>
        /// <param name="alternativeDate">Date of the proposed alternative time</param>
        /// <returns>TRUE- success in sending notification to user
        /// FALSE- Unable to send alternative appointment</returns>
        public async Task<bool> SetAlternativeAppointmentAsync(int appointmentID, DateTimeOffset alternativeDate)
        {
            //- Get Appointments
            var allAppts = await GetAppointmentsAsync();


            //- Find Appt
            var alternativeAppt = (from item in allAppts
                                   where (item.AppointmentId == appointmentID)
                                   select item).FirstOrDefault();

            //- Update Status
            if (alternativeAppt != null)
            {
                alternativeAppt.Status = AppointmentApprovalStatuses.Alternative;
                alternativeAppt.AlternativeDateTimeOffset = alternativeDate;

                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Approve the requested appointment time that was requested
        /// </summary>
        /// <param name="appointmentID">Unique identifier for the appointment</param>
        /// <returns>TRUE- success in setting the approval for appointment
        /// FALSE- unable to set the approval</returns>
        public async Task<bool> SetConfirmAppointmentAsync(int appointmentID)
        {
            //- Get Appointments
            var allAppts = await GetAppointmentsAsync();


            //- Find Appointment
            var confirmedAppointment = (from item in allAppts
                                        where (item.AppointmentId == appointmentID)
                                        select item).FirstOrDefault();


            //- Update Status
            if (confirmedAppointment != null)
            {
                confirmedAppointment.Status = AppointmentApprovalStatuses.Confirmed;

                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion



        #region Calcualte Count by Status

        /// <summary>
        /// Gets counts of the different appointments by status within current edit session;
        /// does not pull records from DataStore.
        /// </summary>
        /// <returns>Contains counts</returns>
        public async Task<AppointmentStatusInfo> GetAppointmentStatusesAsync()
        {
            List<AppointmentRequestDetail> appts;

            if (_appointmentCache.TryGetValue(_appointmentCacheKey, out appts) == true)
            {
                return CalculateStatusCounts(appts);
            }
            else
            {
                return new AppointmentStatusInfo();
            }
       }

        /// <summary>
        /// Determines the counts of appointments based on the status
        /// </summary>
        /// <param name="appointments">List of the appointments to determine count</param>
        /// <returns>Model with the counts</returns>
        private AppointmentStatusInfo CalculateStatusCounts(List<AppointmentRequestDetail> appointments)
        {
            AppointmentStatusInfo model = new AppointmentStatusInfo();

            model.AlternativeAppointmentCount = (from item in appointments
                                                 where (item.Status == AppointmentApprovalStatuses.Alternative)
                                                 select item).Count();

            model.ConfirmedAppointmentCount = (from item in appointments
                                                 where (item.Status == AppointmentApprovalStatuses.Confirmed)
                                                 select item).Count();

            model.RequestedAppointmentCount = (from item in appointments
                                               where (item.Status == AppointmentApprovalStatuses.Requested)
                                               select item).Count();

            return model;
        }

        #endregion



        #region Get Appointments from data store

        /// <summary>
        /// Gets all of the appointments; first checks cache and if not found hits the API
        /// </summary>
        /// <returns>All of the appointments</returns>
        private async Task<List<AppointmentRequestDetail>> GetAppointmentsAsync()
        {
            List<AppointmentRequestDetail> appointments;


            //- Get Appointments from Cache
            if (_appointmentCache.TryGetValue(_appointmentCacheKey, out appointments) == false)
            {
                //- Get From API
                var sourceAppointments = await GetAppointmentsFromApi();


                //- Create Details
                appointments = new List<AppointmentRequestDetail>();

                foreach(var item in sourceAppointments)
                {
                    appointments.Add(new AppointmentRequestDetail(item));    
                }


                //- Add to Cache
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(30));

                _appointmentCache.Set(_appointmentCacheKey, appointments, cacheEntryOptions);
            }


            return appointments;
        }

        #endregion



        #region Get Appointments by ID

        /// <summary>
        /// Returns the appointment based on the ID provided;
        /// returns NULL when not found.
        /// </summary>
        /// <param name="appointmentID">Unique identifier of appointment</param>
        /// <returns>Metadata on the results</returns>
        public async Task<SingleAppointmentModel> GetAppointmentByIDAsync(int appointmentID)
        {
            //- Get Appointments
            var appts = await GetAppointmentsAsync();


            //- Get Counts
            SingleAppointmentModel apptModel = new SingleAppointmentModel();

            apptModel.StatusInfo = CalculateStatusCounts(appts);


            //- Find Appointment
            apptModel.Appointment = (from item in appts
                                     where (item.AppointmentId == appointmentID)
                                     select item).FirstOrDefault();

            return apptModel;
        }

        #endregion





        #region Get Appointments from API

        /// <summary>
        /// Gets all of the appointments from the API; start of the edit session
        /// </summary>
        /// <returns>List of the appointment requests</returns>
        private async Task<List<AppointmentRequest>> GetAppointmentsFromApi()
        {
            //- Get Appointments
            var request = new HttpRequestMessage(HttpMethod.Get, _apiUrl);

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);


            //- Verify Response
            response.EnsureSuccessStatusCode();


            //- Convert JSON to DTO
            var content = await response.Content.ReadAsStringAsync();

            var results = JsonConvert.DeserializeObject<List<AppointmentRequest>>(content);


            return results;
        }

        #endregion
    }
}
