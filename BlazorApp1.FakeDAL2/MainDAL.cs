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
        List<TeacherRoom> teacherRooms;
        List<Room> rooms;
        List<StudentRoom> studentRooms;

public MainDAL()
        {
            persons = new List<Person>();
            Person p01 = new Person { Id = 1, Name = "Adminateachy", Login = "ateachy1" };
            Person p02 = new Person { Id = 2, Name = "Admins", Login = "mAdmins2" };
            Person p03 = new Person { Id = 3, Name = "Tiana Perkins", Login = "tper3" };
            Person p04 = new Person { Id = 4, Name = "Tony Smith", Login = "tsmith4" };
            Person p05 = new Person { Id = 5, Name = "Terry Pratchett", Login = "tpra5" };
            Person p06 = new Person { Id = 6, Name = "Tennis Court", Login = "tcourt6" };
            Person p07 = new Person { Id = 7, Name = "Styles Green", Login = "sgreen7" };
            Person p08 = new Person { Id = 8, Name = "Sandra Collins", Login = "sco8" };
            Person p09 = new Person { Id = 9, Name = "Suzy Ormond", Login = "sormo9" };
            Person p10 = new Person { Id = 10, Name = "Stella Kings", Login = "skings10" };
            Person p11 = new Person { Id = 11, Name = "Perry Johnson", Login = "pjoh11" };
            Person p12 = new Person { Id = 12, Name = "Petra Schevich", Login = "psche12" };

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

            personRoles = new List<PersonRole>
            {
                pr01admin,
                pr01teacher,
                p02admin,
                p03teacher,
                p04teacher,
                p05teacher,
                p06teacher,
                p07student,
                p08student,
                p09student,
                p10student,
                p11parent,
                p12parent
            };

            roles = new List<Role>();
            Role admin = new Role { Id = 100, Name = "Admin" };
            Role teacher = new Role { Id = 101, Name = "Teacher" };
            Role parent = new Role { Id = 102, Name = "Parent" };
            Role student = new Role { Id = 103, Name = "Student" }; //may not be needed
            roles.Add(admin);
            roles.Add(teacher);
            roles.Add(parent);
            roles.Add(student);

            Room r1 = new Room { Id = 1, Name = "First Room", MaxCapacity = 10 };
            Room r2 = new Room { Id = 2, Name = "Secon Room", MaxCapacity = 8 };

            rooms = new List<Room>
            {
                r1,
                r2
            };

            teacherRooms = new List<TeacherRoom>
            {
                new TeacherRoom { Room = r1, Teacher = p01 },
                new TeacherRoom { Room = r1, Teacher = p03 },
                new TeacherRoom { Room = r2, Teacher = p04 },
                new TeacherRoom { Room = r2, Teacher = p05 },
                new TeacherRoom { Room = r2, Teacher = p06 }
            };

            studentRooms = new List<StudentRoom>
            {
                new StudentRoom { Id = 1, Room = r1, Student = p07 },
                new StudentRoom { Id = 2, Room = r1, Student = p08 },
                new StudentRoom { Id = 3, Room = r2, Student = p09 },
                new StudentRoom { Id = 4, Room = r2, Student = p10 }
            };
        }
    }
}
