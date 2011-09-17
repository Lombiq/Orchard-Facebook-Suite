using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement;
using Piedone.ServiceValidation.Dictionaries;

namespace Piedone.Facebook.Suite.Helpers
{
    /// <summary>
    /// Transfers validation dictionary error entries to other objects
    /// </summary>
    public class ValidationDictionaryTranscriber
    {
        /// <summary>
        /// Copies the error entries from an IValidationDictionary to an IUpdateModel for usage in a driver editor
        /// </summary>
        public static void TranscribeValidationDictionaryErrorsToUpdater(IValidationDictionary validationDictionary, IUpdateModel updater)
        {
            foreach (var error in validationDictionary.Errors)
            {
                // Since default DataAnnotations messages are already localized in the .po files, it is no problem that
                // we are transcribing this way. Custom messages will be wrapped somewhere in the service inside a T(),
                // so the translation code generator will find them and generate their entries in the module's .po file.
                updater.AddModelError(error.Key, error.Value);
            }
        }
    }
}