using BlazorApp1.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlazorApp1.FakeDAL2
{
    public partial class MainDAL
    {
        public PersonWithRoles GetPersonWithRolesForEdit(int id)
        {
            Person p = persons.Where(x => x.Id == id).FirstOrDefault();
            if (p == null)
            {
                throw new Exception($"No person with Id of {id}");
            }
            List<Role> pr = GetPersonRoles(new Person { Id = id });

            PersonWithRoles pwrs = new PersonWithRoles { Id = p.Id, Name = p.Name, Login = p.Login, Roles = pr };
            
            return pwrs;
        }

        private int GetNextPersonIdentityValue()
        {
            int next = persons.Select(x => x.Id).Max() + 1;
            return next;
        }

        public int AddPerson(Person pNew)
        {
            if (pNew.Id == 0)
            {
                pNew.Id = GetNextPersonIdentityValue();
            }

            if (persons.Where(x => x.Id == pNew.Id).Any())
            {
                throw new Exception($"Person with an id of {pNew.Id} already exists");
            }

            persons.Add(pNew);

            return pNew.Id;
        }

        //public List<Person> GetPeople()
        //{
        //    throw new NotImplementedException();
        //    //return persons;
        //}

        //public List<Person> GetPeopleByName(string name)
        //{
        //    throw new NotImplementedException();
        //    //return persons.Where(x => x.Name == name).ToList();
        //}

        public Person GetPersonById(int id)
        {
            return persons.Where(x => x.Id == id).FirstOrDefault();
        }

        public void EditPerson(PersonWithRoles newData)
        {
            Person p = persons.Where(x => x.Id == newData.Id).FirstOrDefault();
            if (p == null)
            {
                throw new Exception($"No user with Id of {newData.Id}");
            }

            p.Name = newData.Name;
            p.BirthDate = newData.BirthDate;
            p.Login = newData.Login;

            ChangePersonRoles(p, newData.Roles);
        }
    }
}
