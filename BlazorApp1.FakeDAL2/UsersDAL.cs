using BlazorApp1.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlazorApp1.FakeDAL2
{
    [Obsolete]
    public class UsersDAL
    {
        List<SystemUser> users;

        public UsersDAL()
        {
            users = new List<SystemUser>();
            users.Add(new SystemUser { Id = 1, IsAdmin = true, IsTeacher = true, Name = "AdminTeacher" });
            users.Add(new SystemUser { Id = 2, IsAdmin = true, IsTeacher = false, Name = "JustAdmin" });
            users.Add(new SystemUser { Id = 3, IsAdmin = false, IsTeacher = true, Name = "JustTeacher" });
            users.Add(new SystemUser { Id = 4, IsAdmin = false, IsTeacher = false, Name = "Student" });

        }

        public List<SystemUser> GetUsers()
        {
            return users;
        }

        public int AddUser(SystemUser user)
        {
            if(user.Id == 0)
            {
                user.Id = users.Select(x => x.Id).Max() + 1;
            }

            users.Add(user);
            return user.Id;
        }

        public void DeleteUser(int id)
        {
            users.RemoveAll(x => x.Id == id);
        }

        public void DeleteUser(SystemUser user)
        {
            users.RemoveAll(x => x.Id == user.Id);
        }

        public void EditUser(SystemUser user)
        {
            SystemUser e = users.Where(x => x.Id == user.Id).FirstOrDefault();
            if (e == null)
                throw new Exception("Cannot edit user, no such user found");

            e.Name = user.Name;
            e.IsAdmin = user.IsAdmin;
            e.IsTeacher = user.IsTeacher;
        }
    }
}
