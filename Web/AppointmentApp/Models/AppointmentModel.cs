using System;
using System.Collections.Generic;
using NormalFactory.AppointmentApp.Data;

namespace NormalFactory.AppointmentApp.Web.Models
{
    /// <summary>
    /// Contains appointment information from the data store
    /// </summary>
    public sealed class AppointmentModel: AppointmentInfoModel
    {

        #region Constructor

        /// <summary>
        /// Creates new instance with default values
        /// </summary>
        public AppointmentModel()
        {
            
        }

        /// <summary>
        /// Creates new instance populating status counts
        /// </summary>
        /// <param name="sourceInfo">Metadata on the counts by status</param>
        public AppointmentModel(AppointmentInfoModel sourceInfo)
        {
            ConfirmedAppointmentCount = sourceInfo.ConfirmedAppointmentCount;
            RequestedAppointmentCount = sourceInfo.RequestedAppointmentCount;
            AlternativeAppointmentCount = sourceInfo.AlternativeAppointmentCount;
        }

        #endregion



        #region Public Properties

        /// <summary>
        /// List of the appointments requested
        /// </summary>
        public List<AppointmentRequestDetail> Appointments { get; set; }

        #endregion
    }
}
