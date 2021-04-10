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
        public PersonDAL()
        {
            persons = new List<Person>();
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

        public int AddPerson(Person pNew)
        {
            int newId = pNew.Id;

            if(pNew.Id == 0)
            {
                newId = persons.Select(x => x.Id).Max();
                pNew.Id = newId + 1;
            }

            if(persons.Where(x=>x.Id == newId).Any())
            {
                throw new Exception($"Person with an id of {newId} already exists");
            }

            persons.Add(pNew);

            return newId;
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

        public void EditPerson(Person newData)
        {
            Person p = persons.Where(x => x.Id == newData.Id).FirstOrDefault();
            if(p== null)
            {
                throw new Exception($"No user with Id of {newData.Id}");
            }

            p.Name = newData.Name;
            p.BirthDate = newData.BirthDate;
        }
    }
}
