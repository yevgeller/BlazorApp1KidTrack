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
        List<Person> personnel;

        [Parameter]
        public int Id { get; set; }

        [Inject]
        NavigationManager nm { get; set; }

        Person newUser;
        PersonDAL personsDAL;
        public string ErrorMessage { get; set; } = string.Empty;
        public bool showNewUI = false;

        protected override void OnParametersSet()
        {
            Id = Id;
            if (Id > 0)
            {
                Person p = personnel.Where(x => x.Id == Id).FirstOrDefault();
                if (p != null)
                {
                    newUser.Id = p.Id;
                    newUser.Name = p.Name;
                    showNewUI = true;
                }
            }
            base.OnParametersSet();
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            personsDAL = new PersonDAL();
            newUser = new Person();
            personnel = personsDAL.GetPeople();
        }

        private void ToggleNewUI()
        {
            showNewUI = !showNewUI;
        }

        private void AddNewUser()
        {
            if (Id > 0) //update an existing user
            {
                Person toBeUpdated = new Person
                {
                    Id = Id,
                    Name = newUser.Name
                };

                personsDAL.EditPerson(toBeUpdated);
                nm.NavigateTo("/users/");
            }
            else
            {
                ErrorMessage = string.Empty;
                Person p = new Person { Id = 0, Name = newUser.Name };
                personsDAL.AddPerson(p);
            }

            showNewUI = false;
            newUser = new Person();
        }

        private void InvalidSubmit() { }

        private void Cancel()
        {
            nm.NavigateTo("/personnel/");
            ErrorMessage = string.Empty;
            newUser = new Person();
            showNewUI = false;
        }
    }
}
