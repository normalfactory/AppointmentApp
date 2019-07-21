using System;
using System.Collections.Generic;
using NormalFactory.AppointmentApp.Data;

namespace NormalFactory.AppointmentApp.Web.ViewModels
{
    /// <summary>
    /// Contains data for the Appointment\Requested view
    /// </summary>
    public class RequestedAppointmentViewModel: BaseAppointmentViewModel
    {

        #region Public Properties

        /// <summary>
        /// List of all of the requested appointments; waiting for vendor approval
        /// </summary>
        public List<AppointmentRequestDetail> Appointments { get; set; }

        #endregion


    }
}
