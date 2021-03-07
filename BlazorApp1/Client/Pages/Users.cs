using BlazorApp1.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1.Client.Pages
{
    public partial class Users
    {
        List<SystemUser> users;

        protected override void OnInitialized()
        {
            base.OnInitialized();
            users = new List<SystemUser>();
            users.Add(new SystemUser { Id = 1, IsAdmin = true, IsTeacher = true, Name = "AdminTeacher" });
            users.Add(new SystemUser { Id = 2, IsAdmin = true, IsTeacher = false, Name = "JustAdmin" });
            users.Add(new SystemUser { Id = 3, IsAdmin = false, IsTeacher = true, Name = "JustTeacher" });
            users.Add(new SystemUser { Id = 4, IsAdmin = false, IsTeacher = false, Name = "Student" });
        }
    }
}
