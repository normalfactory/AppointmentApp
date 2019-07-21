using System;
using NormalFactory.AppointmentApp.Data;


namespace NormalFactory.AppointmentApp.Web.ViewModels
{
    /// <summary>
    /// Provides functionality for formating data within the view; abstract to be used by multiple viewModels.
    /// </summary>
    public abstract class BaseAppointmentViewModel
    {
        #region Format Date

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceDate"></param>
        /// <returns></returns>
        public string GetFormattedDateTime(DateTimeOffset sourceDate)
        {
            return sourceDate.ToString("M-d-yyyy h:mm tt");
        }

        #endregion



        #region Display Names

        /// <summary>
        /// Returns name to be used within UI; "FirstName LastName"
        /// </summary>
        /// <param name="sourceClient">Source object to build display name for</param>
        /// <returns>Name to be displayed</returns>
        public string GetClientDisplayName(ClientInfo sourceClient)
        {
            string clientName = string.Empty;

            if (string.IsNullOrEmpty(sourceClient.FirstName) == false)
            {
                clientName = sourceClient.FirstName;
            }

            if (string.IsNullOrEmpty(sourceClient.LastName) == false)
            {
                if (string.IsNullOrEmpty(clientName) == false)
                {
                    clientName += " ";
                }

                clientName += sourceClient.LastName;
            }

            return clientName;
        }

        /// <summary>
        /// Returns name of the patient
        /// </summary>
        /// <returns>Display name</returns>
        public string GetPatientDisplayName(PatientInfo sourcePatient)
        {
            string displayName = string.Empty;

            //- Get Animal Info
            if (string.IsNullOrEmpty(sourcePatient.Breed) == true)
            {
                if (string.IsNullOrEmpty(sourcePatient.Species) == false)
                {
                    displayName = sourcePatient.Species;
                }
            }
            else
            {
                displayName = sourcePatient.Breed;
            }


            //- Add Name
            if (string.IsNullOrEmpty(sourcePatient.FirstName) == false)
            {
                if (string.IsNullOrEmpty(displayName) == false)
                {
                    displayName += ": ";
                }

                displayName += sourcePatient.FirstName;
            }


            return displayName;
        }

        #endregion

    }
}
