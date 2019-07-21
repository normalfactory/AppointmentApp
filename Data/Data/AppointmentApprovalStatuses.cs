using System;
namespace NormalFactory.AppointmentApp.Data
{
    /// <summary>
    /// Status of a requested appointment
    /// </summary>
    public enum AppointmentApprovalStatuses
    {
        /// <summary>
        /// Client has provided appointment that has yet to be confirmed by vendor
        /// </summary>
        Requested = 0,

        /// <summary>
        /// Vendor provided an alternative appointment time
        /// </summary>
        Alternative = 1,

        /// <summary>
        /// Requested appointment time has been approved by vendor
        /// </summary>
        Confirmed = 2
    }
}
