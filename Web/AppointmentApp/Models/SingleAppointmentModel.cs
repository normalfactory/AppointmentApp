using System;
using NormalFactory.AppointmentApp.Data;

namespace NormalFactory.AppointmentApp.Web.Models
{
    /// <summary>
    /// Used to return individual appointment from data access
    /// </summary>
    public sealed class SingleAppointmentModel
    {
        #region Public Properties

        /// <summary>
        /// Individual appointment record requested; null when not found
        /// </summary>
        public AppointmentRequestDetail Appointment { get; set; }


        /// <summary>
        /// Counts of the appointments by status within current edit session
        /// </summary>
        public AppointmentStatusInfo StatusInfo { get; set; }

        #endregion
    }
}
