using System;

namespace NormalFactory.AppointmentApp.Web.Models
{
    /// <summary>
    /// Contains information about the current counts of the appointments by status
    /// </summary>
    public sealed class AppointmentStatusInfo
    {
        #region Constructor

        /// <summary>
        /// Creates a new instance and sets default values
        /// </summary>
        public AppointmentStatusInfo()
        {
            RequestedAppointmentCount = 0;
            ConfirmedAppointmentCount = 0;
            AlternativeAppointmentCount = 0;
        }

        #endregion



        #region Public Properties

        /// <summary>
        /// Number of appointments in current session that have status of Requested
        /// </summary>
        public int RequestedAppointmentCount { get; set; }

        /// <summary>
        /// Number of appointments in current session that have status of Confirmed
        /// </summary>
        public int ConfirmedAppointmentCount { get; set; }

        /// <summary>
        /// Number of appointments in current session that have status of Alternative
        /// </summary>
        public int AlternativeAppointmentCount { get; set; }

        #endregion
    }
}
