using BlazorApp1.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorApp1.FakeDAL2
{
    public partial class MainDAL
    {
        public List<Role> GetAllRoles()
        {
            return roles;
        }
    }
}
