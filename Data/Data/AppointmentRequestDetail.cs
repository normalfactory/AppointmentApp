using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace NormalFactory.AppointmentApp.Data
{
    /// <summary>
    /// Metadata on an appointment request; contains additional information used in the vendor approval process
    /// </summary>
    public sealed class AppointmentRequestDetail: AppointmentRequest
    {
        #region Constructor

        /// <summary>
        /// Creates a new instance and sets the default values
        /// </summary>
        public AppointmentRequestDetail()
        {
            Status = AppointmentApprovalStatuses.Requested;
        }

        /// <summary>
        /// Creates a new instance based on the values provided
        /// </summary>
        /// <param name="sourceAppointment">Appointment used to populate object</param>
        public AppointmentRequestDetail(AppointmentRequest sourceAppointment)
        {
            Animal = sourceAppointment.Animal;
            User = sourceAppointment.User;

            AppointmentId = sourceAppointment.AppointmentId;
            AppointmentType = sourceAppointment.AppointmentType;
            CreateDateTime = sourceAppointment.CreateDateTime;
            RequestedDateTimeOffset = sourceAppointment.RequestedDateTimeOffset;
        }

        #endregion



        #region Private Properties

        /// <summary>
        /// Alternative date-time of the appointment created by the vendor; set when the Status is Alternative 
        /// </summary>
        [Required(ErrorMessage = "Valid alternative date required")]
        [JsonProperty("alternativeDateTimeOffset")]
        public DateTimeOffset AlternativeDateTimeOffset { get; set; }

        /// <summary>
        /// Current status of the approval of the appointment
        /// </summary>
        [JsonProperty("status")]
        public AppointmentApprovalStatuses Status { get; set; }

        #endregion

    }
}
