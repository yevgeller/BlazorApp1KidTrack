using BlazorApp1.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlazorApp1.FakeDAL2
{
    public partial class MainDAL
    {
        //private List<StudentRoom> studentRooms;

        //public StudentRoomDAL()
        //{
        //    studentRooms = new List<StudentRoom>();

        //    Room r1 = new Room { Id = 1, Name = "First Room", MaxCapacity = 10 };
        //    Room r2 = new Room { Id = 2, Name = "Secon Room", MaxCapacity = 8 };

        //    Person p07 = new Person { Id = 7, Name = "7Student1" };
        //    Person p08 = new Person { Id = 8, Name = "8Student2" };
        //    Person p09 = new Person { Id = 9, Name = "9Student3" };
        //    Person p10 = new Person { Id = 10, Name = "10Student4" };

        //    studentRooms.Add(new StudentRoom { Id=1, Room = r1, Student = p07 });
        //    studentRooms.Add(new StudentRoom { Id=2, Room = r1, Student = p08 });
        //    studentRooms.Add(new StudentRoom { Id=3, Room = r2, Student = p09 });
        //    studentRooms.Add(new StudentRoom { Id=4, Room = r2, Student = p10 });
        //}

        private int GetNextIdentityValue()
        {
            int next = studentRooms.Select(x => x.Id).Max() + 1;
            return next;
        }

        public List<Person> GetStudentsInRoom(Room room)
        {
            return studentRooms
                .Where(x => x.Room.Id == room.Id)
                .Select(x=>x.Student)
                .ToList();
        }

        public int AddStudentToRoom(Person student, Room room)
        {
            if(studentRooms.Where(x=>x.Student.Id == student.Id && x.Room.Id == room.Id).Any())
            {
                throw new Exception($"Student {student.Id} is already listed in room {room.Id}");
            }

            int newId = GetNextIdentityValue();
            studentRooms.Add(new StudentRoom { Id = newId, Room = room, Student = student });
            return newId;
        }

        public int RemoveStudentFromRoom(Person student, Room room)
        {
            if (!studentRooms.Where(x => x.Student.Id == student.Id && x.Room.Id == room.Id).Any())
            {
                throw new Exception($"Student {student.Id} is not listed in room {room.Id}");
            }

            int numberRemoved = studentRooms.RemoveAll(x => x.Room.Id == room.Id && x.Student.Id == student.Id);
            return numberRemoved;
        }
    }
}
