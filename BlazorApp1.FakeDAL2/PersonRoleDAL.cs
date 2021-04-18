using BlazorApp1.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlazorApp1.FakeDAL2
{
    public partial class MainDAL
    {
        public List<Role> GetPersonRoles(Person person)
        {
            List<PersonRole> pr = personRoles.Where(x => x.Person.Id == person.Id).ToList();
            List<Role> roles = pr.Select(x => x.Role).ToList<Role>();
            return roles;
        }

        public List<PersonRole> GetPersonRoles()
        {
            return personRoles;
        }

        public List<PersonRole> GetPersonRoles(int personId)
        {
            return personRoles.Where(x => x.Person.Id == personId).ToList();
        }

        public bool PersonHasRole(Person p, Role r)
        {
            return personRoles.Any(x => x.Person.Id == p.Id && x.Role.Id == r.Id);
        }

        public void ChangePersonRoles(Person person, List<Role> freshRoles)
        {
            List<PersonRole> thisPersonsRoles = this.GetPersonRoles(person.Id);
            foreach (PersonRole pr in thisPersonsRoles)
            {
                if (!freshRoles.Any(x => x.Id == pr.Role.Id))
                {
                    this.RemovePersonRole(person, pr.Role);
                }
            }

            foreach (Role r in freshRoles)
            {
                if (!this.PersonHasRole(person, r))
                {
                    this.AddRoleToPerson(person, r);
                }
            }
        }

        public void AddRoleToPerson(Person person, Role role)
        {
            if (personRoles.Where(x => x.Person.Id == person.Id && x.Role.Id == role.Id).Any())
            {
                throw new Exception("There is already such a RolePerson object");
            }

            personRoles.Add(new PersonRole { Person = person, Role = role });
        }

        public void RemovePersonRole(Person person, Role role)
        {
            if (!personRoles.Where(x => x.Person.Id == person.Id && x.Role.Id == role.Id).Any())
            {
                throw new Exception("No such a RolePerson object");
            }

            PersonRole toBeRemoved = personRoles
                .Where(x => x.Role.Id == role.Id && x.Person.Id == person.Id)
                .FirstOrDefault();

            personRoles.Remove(toBeRemoved);
        }

        public List<PersonWithRoles> GetAllPersonsWithRoles()
        {
            List<PersonWithRoles> result = new List<PersonWithRoles>();

            foreach (Person p in persons)
            {
                List<Role> roles = personRoles.Where(x => x.Person.Equals(p))
                    .Select(x => x.Role)
                    .ToList<Role>();

                result.Add(new PersonWithRoles
                {
                    Id = p.Id,
                    Login = p.Login,
                    BirthDate = p.BirthDate,
                    Name = p.Name,
                    Roles = roles
                });
            }

            return result;
        }
    }
}
