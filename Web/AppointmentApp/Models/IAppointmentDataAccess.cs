using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NormalFactory.AppointmentApp.Data;

namespace NormalFactory.AppointmentApp.Web.Models
{
    /// <summary>
    /// Provides access to the appointment requests
    /// </summary>
    public interface IAppointmentDataAccess
    {
        /// <summary>
        /// Returns a list of all the appointments that have the status provided
        /// </summary>
        /// <param name="status">Status of the appointments to get</param>
        /// <returns>List of appointments waiting for approval</returns>
        Task<AppointmentModel> GetAppointmentsAsync(AppointmentApprovalStatuses status);

        /// <summary>
        /// Approve the requested appointment time that was requested
        /// </summary>
        /// <param name="appointmentID">Unique identifier for the appointment</param>
        /// <returns>TRUE- success in setting the approval for appointment
        /// FALSE- unable to set the approval</returns>
        Task<bool> SetConfirmAppointmentAsync(int appointmentID);

        /// <summary>
        /// Sets the alternative time for the appointment
        /// </summary>
        /// <param name="appointmentID">Unique identifier for the appointment</param>
        /// <param name="alternativeDate">Date of the proposed alternative time</param>
        /// <returns>TRUE- success in sending notification to user
        /// FALSE- Unable to send alternative appointment</returns>
        Task<bool> SetAlternativeAppointmentAsync(int appointmentID, DateTime alternativeDate);
    }
}
