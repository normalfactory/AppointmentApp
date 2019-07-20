using System;
using Newtonsoft.Json;

namespace NormalFactory.AppointmentApp.Data
{
    /// <summary>
    /// Individual appointment for a patient with the requested time. Use JsonProperty to ensure property starts
    /// with lowercase when serialized.
    /// </summary>
    public class AppointmentRequest
    {
        #region Public Properties

        /// <summary>
        /// Unique idenitifer for the appointment
        /// </summary>
        [JsonProperty("appointmentId")]
        public int AppointmentId { get; set; }

        /// <summary>
        /// Type of the services that is to be performed
        /// </summary>
        [JsonProperty("appointmentType")]
        public string AppointmentType { get; set; }

        /// <summary>
        /// Date when the user created the appointment
        /// </summary>
        [JsonProperty("createDateTime")]
        public DateTime CreateDateTime { get; set; }

        /// <summary>
        /// Date when the user wants to have the appointment
        /// </summary>
        [JsonProperty("requestedDateTimeOffset")]
        public DateTime RequestedDateTimeOffset { get; set; }

        /// <summary>
        /// Metadata on the user that created the appointment
        /// </summary>
        [JsonProperty("user")]
        public ClientInfo User { get; set; }

        /// <summary>
        /// Metadata on the animal that is to have the services performed on
        /// </summary>
        [JsonProperty("animal")]
        public PatientInfo Animal { get; set; }

        #endregion
    }
}
