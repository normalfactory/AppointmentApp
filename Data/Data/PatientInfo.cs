using System;
using Newtonsoft.Json;

namespace NormalFactory.AppointmentApp.Data
{
    /// <summary>
    /// Metadata about an individual animal patient. Use JsonProperty to ensure properties start with lowercase when serialized
    /// </summary>
    public class PatientInfo
    {
        #region Public Properties

        /// <summary>
        /// Unique identifier for the animal
        /// </summary>
        [JsonProperty("animalId")]
        public int AnimalId { get; set; }

        /// <summary>
        /// Name of the animal
        /// </summary>
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        /// <summary>
        /// Type of animal species; potential null
        /// </summary>
        [JsonProperty("species")]
        public string Species { get; set; }

        /// <summary>
        /// Type of breed of the animal; potentially null
        /// </summary>
        [JsonProperty("breed")]
        public string Breed { get; set; }

        #endregion

    }
}
