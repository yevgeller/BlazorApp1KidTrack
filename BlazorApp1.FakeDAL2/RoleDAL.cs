using BlazorApp1.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorApp1.FakeDAL2
{
    public class RoleDAL
    {
        List<Role> roles;
        public RoleDAL()
        {
            roles = new List<Role>();
            Role admin = new Role { Id = 100, Name = "Admin" };
            Role teacher = new Role { Id = 101, Name = "Teacher" };
            Role parent = new Role { Id = 102, Name = "Parent" };
            Role student = new Role { Id = 103, Name = "Student" }; //may not be needed

            roles.Add(admin);
            roles.Add(teacher);
            roles.Add(parent);
            roles.Add(student);
        }

        public RoleDAL(List<Role> roles)
        {
            this.roles = roles;
        }

        public List<Role> GetAllRoles()
        {
            return roles;
        }
    }
}
