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
            if (this.Roles == null)
                return "No roles specified";
            if (!Roles.Any())
                return "No roles";
            
            return String.Join(", ", this.Roles.Select(x => $"{x.Id}, {x.Name}"));
        }

        public override string ForDisplay()
        {
            return $"{base.ForDisplay()}-{RoleString()}";
        }
    }
}
