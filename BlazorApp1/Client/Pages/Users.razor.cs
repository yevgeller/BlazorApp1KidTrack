﻿using BlazorApp1.FakeDAL2;
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
        List<PersonWithRoles> personsWithRoles;

        [Parameter]
        public int Id { get; set; }

        [Inject]
        NavigationManager nm { get; set; }

        PersonWithRoles newUser;
        MainDAL mainDAL;

        public string ErrorMessage { get; set; } = string.Empty;
        public bool showNewUI = false;

        List<Role> allRoles;

        protected override void OnParametersSet()
        {
            Id = Id;
            if (Id > 0)
            {
                PersonWithRoles p = mainDAL.GetPersonWithRolesForEdit(Id);
                if (p != null)
                {
                    newUser.Id = p.Id;
                    newUser.Name = p.Name;
                    newUser.Login = p.Login;
                    newUser.Roles = p.Roles;
                    showNewUI = true;
                }
            }
            else
            {
                personsWithRoles = mainDAL.GetAllPersonsWithRoles();
            }
            base.OnParametersSet();
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            mainDAL = new MainDAL();
            newUser = new PersonWithRoles();
            allRoles = mainDAL.GetAllRoles();
            personsWithRoles = mainDAL.GetAllPersonsWithRoles();
        }

        private void ToggleNewUI()
        {
            showNewUI = !showNewUI;
        }

        private void ToggleRole(bool added, string role)
        {
            int roleId = allRoles.Where(x => x.Name == role).Select(x => x.Id).First();
            if (added)
            {
                newUser.Roles.Add(new Role { Id = roleId, Name = role });
            }
            else
            {
                newUser.Roles.RemoveAll(x => x.Id == roleId);
            }
        }

        private bool SelectedUserHasRole(int roleId)
        {
            if (newUser == null)
                return false;

            if (newUser.Roles == null)
                return false;

            if (!newUser.Roles.Any())
                return false;

            return newUser.Roles.Where(x => x.Id == roleId).Any();
        }

        private void AddNewUser()
        {
            if (Id > 0) //update an existing user
            {
                PersonWithRoles toBeUpdated = new PersonWithRoles
                {
                    Id = Id,
                    Name = newUser.Name,
                    Login = newUser.Login,
                    Roles = newUser.Roles
                };

                mainDAL.EditPerson(toBeUpdated);
                nm.NavigateTo("/persons/");
            }
            else
            {
                ErrorMessage = string.Empty;
                Person p = new Person { Id = 0, Name = newUser.Name };
                mainDAL.AddPerson(p);
            }

            showNewUI = false;
            newUser = new PersonWithRoles();
        }

        private void InvalidSubmit() { }

        private void Cancel()
        {
            nm.NavigateTo("/personnel/");
            ErrorMessage = string.Empty;
            newUser = new PersonWithRoles();
            showNewUI = false;
        }
    }
}
