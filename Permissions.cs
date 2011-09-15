using System.Collections.Generic;
using Orchard.Environment.Extensions.Models;
using Orchard.Security.Permissions;

namespace Piedone.Facebook.Suite {
    public class Permissions : IPermissionProvider {
        public static readonly Permission EditSettings = new Permission { Description = "Edit Facebook Suite Settings", Name = "EditFacebookSuiteSettings" };

        public virtual Feature Feature { get; set; }

        public IEnumerable<Permission> GetPermissions() {
            return new[] {
                EditSettings
            };
        }

        public IEnumerable<PermissionStereotype> GetDefaultStereotypes() {
            return new[] {
                new PermissionStereotype {
                    Name = "Administrator",
                    Permissions = new[] {EditSettings}
                }
            };
        }
    }
}
