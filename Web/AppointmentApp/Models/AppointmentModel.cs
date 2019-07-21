using System;
using System.Collections.Generic;
using NormalFactory.AppointmentApp.Data;

namespace NormalFactory.AppointmentApp.Web.Models
{
    /// <summary>
    /// Contains appointment information from the data store
    /// </summary>
    public sealed class AppointmentModel
    {
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

        /// <summary>
        /// List of the appointments requested
        /// </summary>
        public List<AppointmentRequestDetail> Appointments { get; set; }

        #endregion
    }
}
