using System;
using NormalFactory.AppointmentApp.Data;

namespace NormalFactory.AppointmentApp.Web.ViewModels
{
    /// <summary>
    /// Contains data for the Appointment\EditAlternative view
    /// </summary>
    public class EditAlternativeAppointmentViewModel: BaseAppointmentViewModel
    {
        #region Public Properties

        /// <summary>
        /// Appointment to suggest alternative time
        /// </summary>
        public AppointmentRequestDetail Appointment { get; set; }

        #endregion
    }
}
