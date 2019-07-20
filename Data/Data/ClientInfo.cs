using System;
using Newtonsoft.Json;

namespace NormalFactory.AppointmentApp.Data
{
    /// <summary>
    /// Contains basic information on the client. Use JsonProperty to ensure property names start with
    /// lowercase when serialized.
    /// </summary>
    public class ClientInfo
    {

        #region Public Properties

        /// <summary>
        /// Unique identifier for the user
        /// </summary>
        [JsonProperty("userId")]
        public int UserId { get; set; }

        /// <summary>
        /// First name of the user
        /// </summary>
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        /// <summary>
        /// Last name of the user
        /// </summary>
        [JsonProperty("lastName")]
        public string LastName { get; set; }

        #endregion
    }
}
