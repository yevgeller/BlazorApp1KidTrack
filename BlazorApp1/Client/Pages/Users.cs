using BlazorApp1.FakeDAL2;
using BlazorApp1.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1.Client.Pages
{
    public partial class Users
    {
        List<SystemUser> users;

        [Parameter]
        public int UserId { get; set; }

        [Inject]
        NavigationManager nm { get; set; }

        SystemUser newUser;
        UsersDAL usersDAL;
        public string ErrorMessage { get; set; } = string.Empty;
        public bool showNewUI = false;

        protected override void OnParametersSet()
        {
            UserId = UserId;
            if (UserId > 0)
            {
                SystemUser u = users.Where(x => x.Id == UserId).FirstOrDefault();
                if (u != null)
                {
                    newUser.Id = u.Id;
                    newUser.Name = u.Name;
                    newUser.IsAdmin = u.IsAdmin;
                    newUser.IsTeacher = u.IsTeacher;
                    showNewUI = true;
                }
            }
            base.OnParametersSet();
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            usersDAL = new UsersDAL();
            newUser = new SystemUser();
            users = usersDAL.GetUsers();
            //users = new List<SystemUser>();
            //users.Add(new SystemUser { Id = 1, IsAdmin = true, IsTeacher = true, Name = "AdminTeacher" });
            //users.Add(new SystemUser { Id = 2, IsAdmin = true, IsTeacher = false, Name = "JustAdmin" });
            //users.Add(new SystemUser { Id = 3, IsAdmin = false, IsTeacher = true, Name = "JustTeacher" });
            //users.Add(new SystemUser { Id = 4, IsAdmin = false, IsTeacher = false, Name = "Student" });
        }

        private void ToggleNewUI()
        {
            showNewUI = !showNewUI;
        }

        private void AddNewUser()
        {
            if (UserId > 0) //update an existing user
            {
                SystemUser toBeUpdated = new SystemUser
                {
                    Id = UserId,
                    Name = newUser.Name,
                    IsAdmin = newUser.IsAdmin,
                    IsTeacher = newUser.IsTeacher
                };

                usersDAL.EditUser(toBeUpdated);
                nm.NavigateTo("/users/");
            }
            else
            {
                ErrorMessage = string.Empty;
                SystemUser su = new SystemUser { Id = 0, Name = newUser.Name, IsAdmin = newUser.IsAdmin, IsTeacher = newUser.IsTeacher };
                usersDAL.AddUser(su);
            }

            showNewUI = false;
            newUser = new SystemUser();
        }

        private void InvalidSubmit() { }

        private void Cancel()
        {
            nm.NavigateTo("/users/");
            ErrorMessage = string.Empty;
            newUser = new SystemUser();
            showNewUI = false;
        }
    }
}
