using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlazorApp1.Shared.Models
{
    public class PersonWithRoles : Person
    {
        public List<Role> Roles { get; set; }
        public string RoleString()
        {
            var r = this.Roles;
            var a = String.Join(", ", this.Roles.Select(x => x.Name));
            return a;
        }
    }
}
