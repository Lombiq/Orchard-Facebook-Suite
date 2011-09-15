using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.Localization;

/*
 * ==== Examples ====
 * 
 * 
 * 
 * ----Validating in service example----
 * 
 * var validationContext = new ValidationContext(part, null, null);
 * var validationResults = new List<ValidationResult>();
 * bool isValid = Validator.TryValidateObject(part, validationContext, validationResults, true?);
 * 
 * 
 * ----Notification example----
 * if (!_service.ValidationDictionary.IsValid)
 * {
 *      foreach (var error in _service.ValidationDictionary.Errors)
 *      {
 *          _notifier.Add(NotifyType.Warning, error.Value);
 *      }
 * }
 * 
 * 
 * ----Transcribe errors from service dictionary to update----
 * ValidationDictionaryTranscriber.TranscribeValidationDictionaryErrorsToUpdater(_service.ValidationDictionary, updater);
 * This way notifications will automatically appear on the UI.
 */

namespace Piedone.Facebook.Suite.Validation
{
    public class ServiceValidationDictionary : IServiceValidationDictionary
    {
        public ServiceValidationDictionary()
        {
            Errors = new Dictionary<string, LocalizedString>();
        }

        #region IValidationDictionary Members
        public Dictionary<string, LocalizedString> Errors { get; private set; }

        public void AddError(string key, LocalizedString errorMessage)
        {
            Errors.Add(key, errorMessage);
        }

        public bool IsValid
        {
            get
            {
                return Errors.Count == 0;
            }
        }
        #endregion
    }
}