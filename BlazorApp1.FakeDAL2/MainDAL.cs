using BlazorApp1.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorApp1.FakeDAL2
{
    public partial class MainDAL 
    {
        List<Person> persons;
        List<PersonRole> personRoles;
        List<Role> roles;

        public MainDAL()
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

            //PersonRoles
            PersonRole pr01admin = new PersonRole { Person = p01, Role = new Role { Id = 100, Name = "Admin" } };
            PersonRole pr01teacher = new PersonRole { Person = p01, Role = new Role { Id = 101, Name = "Teacher" } };
            PersonRole p02admin = new PersonRole { Person = p02, Role = new Role { Id = 100, Name = "Admin" } };
            PersonRole p03teacher = new PersonRole { Person = p03, Role = new Role { Id = 101, Name = "Teacher" } };
            PersonRole p04teacher = new PersonRole { Person = p04, Role = new Role { Id = 101, Name = "Teacher" } };
            PersonRole p05teacher = new PersonRole { Person = p05, Role = new Role { Id = 101, Name = "Teacher" } };
            PersonRole p06teacher = new PersonRole { Person = p06, Role = new Role { Id = 101, Name = "Teacher" } };
            PersonRole p07student = new PersonRole { Person = p07, Role = new Role { Id = 103, Name = "Student" } };
            PersonRole p08student = new PersonRole { Person = p08, Role = new Role { Id = 103, Name = "Student" } };
            PersonRole p09student = new PersonRole { Person = p09, Role = new Role { Id = 103, Name = "Student" } };
            PersonRole p10student = new PersonRole { Person = p10, Role = new Role { Id = 103, Name = "Student" } };
            PersonRole p11parent = new PersonRole { Person = p11, Role = new Role { Id = 102, Name = "Parent" } };
            PersonRole p12parent = new PersonRole { Person = p12, Role = new Role { Id = 102, Name = "Parent" } };

            personRoles = new List<PersonRole>();
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

            roles = new List<Role>();
            Role admin = new Role { Id = 100, Name = "Admin" };
            Role teacher = new Role { Id = 101, Name = "Teacher" };
            Role parent = new Role { Id = 102, Name = "Parent" };
            Role student = new Role { Id = 103, Name = "Student" }; //may not be needed
            roles.Add(admin);
            roles.Add(teacher);
            roles.Add(parent);
            roles.Add(student);
        }        
    }
}
