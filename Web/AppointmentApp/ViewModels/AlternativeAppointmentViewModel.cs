using System;
using System.Collections.Generic;
using NormalFactory.AppointmentApp.Data;

namespace NormalFactory.AppointmentApp.Web.ViewModels
{
    /// <summary>
    /// Contains data for the Appointment\Alternative view
    /// </summary>
    public class AlternativeAppointmentViewModel : BaseAppointmentViewModel
    {

        #region Public Properties

        /// <summary>
        /// List of all of the alternative appointments; sent to patient for confirmation
        /// </summary>
        public List<AppointmentRequestDetail> Appointments { get; set; }

        #endregion

    }
}
