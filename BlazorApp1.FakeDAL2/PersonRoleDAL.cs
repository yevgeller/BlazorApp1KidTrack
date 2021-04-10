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

            Person p01 = new Person { Id = 1, Name = "1AdminTeacher" };
            Person p02 = new Person { Id = 2, Name = "2JustAdmin" };
            Person p03 = new Person { Id = 3, Name = "3JustTeacher1" };
            Person p04 = new Person { Id = 4, Name = "4JustTeacher2" };
            Person p05 = new Person { Id = 5, Name = "5JustTeacher3" };
            Person p06 = new Person { Id = 6, Name = "6JustTeacher4" };
            Person p07 = new Person { Id = 7, Name = "7Student1" };
            Person p08 = new Person { Id = 8, Name = "8Student2" };
            Person p09 = new Person { Id = 9, Name = "9Student3" };
            Person p10 = new Person { Id = 10, Name = "10Student4" };
            Person p11 = new Person { Id = 11, Name = "11Parent" };
            Person p12 = new Person { Id = 12, Name = "12Parent" };

            Role admin = new Role { Id = 100, Name = "Admin" };
            Role teacher = new Role { Id = 101, Name = "Teacher" };
            Role parent = new Role { Id = 102, Name = "Parent" };
            Role student = new Role { Id = 103, Name = "Student" }; //may not be needed

            PersonRole pr01admin = new PersonRole { Person = p01, Role = admin };
            PersonRole pr01teacher = new PersonRole { Person = p01, Role = teacher };
            PersonRole p02admin = new PersonRole { Person = p02, Role = admin };
            PersonRole p03teacher = new PersonRole { Person = p03, Role = teacher };
            PersonRole p04teacher = new PersonRole { Person = p04, Role = teacher };
            PersonRole p05teacher = new PersonRole { Person = p05, Role = teacher };
            PersonRole p06teacher = new PersonRole { Person = p06, Role = teacher };
            PersonRole p07student = new PersonRole { Person = p07, Role = student };
            PersonRole p08student = new PersonRole { Person = p08, Role = student };
            PersonRole p09student = new PersonRole { Person = p09, Role = student };
            PersonRole p10student = new PersonRole { Person = p10, Role = student };
            PersonRole p11parent = new PersonRole { Person = p11, Role = parent };
            PersonRole p12parent = new PersonRole { Person = p12, Role = parent };

            personRoles.Add(pr01admin);
            personRoles.Add(pr01teacher);
            personRoles.Add(p02admin);
            personRoles.Add(p03teacher);
            personRoles.Add(p04teacher);
            personRoles.Add(p05teacher);
            personRoles.Add(p06teacher);
            personRoles.Add(p07student);
            personRoles.Add(p08student);
            personRoles.Add(p09student);
            personRoles.Add(p10student);
            personRoles.Add(p11parent);
            personRoles.Add(p12parent);
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
            if (!personRoles.Where(x => x.Person.Id == person.Id && x.Role.Id == role.Id).Any())
            {
                throw new Exception("No such a RolePerson object");
            }

            PersonRole[] allBut = personRoles
                .Where(x => x.Role.Id != role.Id && x.Person.Id != person.Id)
                .ToArray();
            personRoles = null;
            personRoles = allBut.ToList<PersonRole>();
        }
    }
}
