using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Orchard.Localization;

namespace Piedone.Facebook.Suite.Validation
{
    /// <summary>
    /// Wraps the ModelStateDictionary of a controller in an IValidationDictionary so objects can directly modify it
    /// </summary>
    public class ModelStateWrapper : IValidationDictionary
    {
        private ModelStateDictionary _modelState;

        public ModelStateWrapper(ModelStateDictionary modelState)
        {
            Errors = new Dictionary<string, LocalizedString>();
            _modelState = modelState;
        }

        #region IValidationDictionary Members
        public Dictionary<string, LocalizedString> Errors { get; private set; }

        public void AddError(string key, LocalizedString errorMessage)
        {
            _modelState.AddModelError(key, errorMessage.ToString());
            Errors.Add(key, errorMessage);
        }

        public bool IsValid
        {
            get
            {
                return _modelState.IsValid;
            }
        }
        #endregion
    }
}