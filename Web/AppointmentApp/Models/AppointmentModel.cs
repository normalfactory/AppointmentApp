﻿using System;
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
        /// List of the appointments requested
        /// </summary>
        public List<AppointmentRequestDetail> Appointments { get; set; }

        /// <summary>
        /// Counts of the appointments by status within current edit session
        /// </summary>
        public AppointmentStatusInfo StatusInfo { get; set; }

        #endregion
    }
}
