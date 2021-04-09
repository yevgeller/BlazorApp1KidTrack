using BlazorApp1.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlazorApp1.FakeDAL2
{
    public class PersonRoleDAL
    {
        List<PersonRole> personRoles;
        public PersonRoleDAL()
        {
            personRoles = new List<PersonRole>();
        }

        public List<PersonRole> GetPersonRoles(Person person)
        {
            return personRoles.Where(x => x.Person.Id == person.Id).ToList();
        }

        public List<PersonRole> GetPersonRoles()
        {
            return personRoles;
        }

        public List<PersonRole> GetPersonRoles(int personId)
        {
            return personRoles.Where(x => x.Person.Id == personId).ToList();
        }

        public void AddRoleToPerson(Person person, Role role)
        {
            if(personRoles.Where(x=>x.Person.Id == person.Id && x.Role.Id == role.Id).Any())
            {
                throw new Exception("There is already such a RolePerson object");
            }

            personRoles.Add(new PersonRole { Person = person, Role = role });
        }

        public void RemovePersonRole(Person person, Role role)
        {
            throw new NotImplementedException();

            //if (!personRoles.Where(x => x.Person.Id == person.Id && x.Role.Id == role.Id).Any())
            //{
            //    throw new Exception("No such a RolePerson object");
            //}

            //List<PersonRole> temp = new List<PersonRole>();
        }
    }
}
