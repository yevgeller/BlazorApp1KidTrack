using BlazorApp1.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlazorApp1.FakeDAL2
{
    public partial class MainDAL
    {
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
