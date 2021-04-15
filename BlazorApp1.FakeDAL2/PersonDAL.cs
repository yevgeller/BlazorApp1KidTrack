using BlazorApp1.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlazorApp1.FakeDAL2
{
    public class PersonDAL
    {
        List<Person> persons;
        PersonRoleDAL personRoleDAL;
        public PersonDAL()
        {
            persons = new List<Person>();
            Person p01 = new Person { Id = 1, Name = "1AdminTeacher", Login = "aTeacher1" };
            Person p02 = new Person { Id = 2, Name = "2JustAdmin", Login = "jAdmin2" };
            Person p03 = new Person { Id = 3, Name = "3JustTeacher1", Login = "jTeacher3" };
            Person p04 = new Person { Id = 4, Name = "4JustTeacher2", Login = "t2" };
            Person p05 = new Person { Id = 5, Name = "5JustTeacher3", Login = "t3" };
            Person p06 = new Person { Id = 6, Name = "6JustTeacher4", Login = "t4" };
            Person p07 = new Person { Id = 7, Name = "7Student1", Login = "s1" };
            Person p08 = new Person { Id = 8, Name = "8Student2", Login = "s2" };
            Person p09 = new Person { Id = 9, Name = "9Student3", Login = "s3" };
            Person p10 = new Person { Id = 10, Name = "10Student4", Login = "s4" };
            Person p11 = new Person { Id = 11, Name = "11Parent", Login = "p11" };
            Person p12 = new Person { Id = 12, Name = "12Parent", Login = "p12" };


            persons.Add(p01);
            persons.Add(p02);
            persons.Add(p03);
            persons.Add(p04);
            persons.Add(p05);
            persons.Add(p06);
            persons.Add(p07);
            persons.Add(p08);
            persons.Add(p09);
            persons.Add(p10);
            persons.Add(p11);
            persons.Add(p12);
        }

        public PersonDAL(List<Person> persons)
        {
            this.persons = persons;
        }

        public PersonRoleDAL LocalPersonRoleDAL
        {
            get
            {
                if (personRoleDAL == null)
                    personRoleDAL = new PersonRoleDAL();
                return personRoleDAL;
            }
        }

        public PersonWithRoles GetPersonWithRolesForEdit(int id)
        {
            Person p = persons.Where(x => x.Id == id).FirstOrDefault();
            if (p == null)
            {
                throw new Exception($"No person with Id of {id}");
            }
            List<Role> pr = LocalPersonRoleDAL.GetPersonRoles(new Person { Id = id });

            PersonWithRoles pwrs = new PersonWithRoles { Id = p.Id, Name = p.Name, Login = p.Login, Roles = pr };
            
            return pwrs;
        }

        private int GetNextIdentityValue()
        {
            int next = persons.Select(x => x.Id).Max() + 1;
            return next;
        }

        public int AddPerson(Person pNew)
        {
            if (pNew.Id == 0)
            {
                pNew.Id = GetNextIdentityValue();
            }

            if (persons.Where(x => x.Id == pNew.Id).Any())
            {
                throw new Exception($"Person with an id of {pNew.Id} already exists");
            }

            persons.Add(pNew);

            return pNew.Id;
        }

        public List<Person> GetPeople()
        {
            return persons;
        }

        public List<Person> GetPeopleByName(string name)
        {
            return persons.Where(x => x.Name == name).ToList();
        }

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

            LocalPersonRoleDAL.ChangePersonRoles(p, newData.Roles);
        }
    }
}
