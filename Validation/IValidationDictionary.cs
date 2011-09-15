using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Orchard.Localization;
using System.Collections;

namespace Piedone.Facebook.Suite.Validation
{
    /// <summary>
    /// Stores validation errors, similar to ModelStateDictionary in controllers
    /// </summary>
    /// <remarks>
    /// See also: http://www.asp.net/mvc/tutorials/validating-with-a-service-layer-cs
    /// Maybe this together with ServiceValidationDictionary should be refactored to a separate assembly.
    /// </remarks>
    public interface IValidationDictionary
    {
        Dictionary<string, LocalizedString> Errors { get; }
        void AddError(string key, LocalizedString errorMessage);
        bool IsValid { get; }
    }
}
