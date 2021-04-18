using BlazorApp1.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlazorApp1.FakeDAL2
{
    public partial class MainDAL
    {
        //public List<TeacherRoom> TeacherRoomAssignments { get; set; }

        //public TeacherRoomDAL()
        //{
        //    Person p01 = new Person { Id = 1, Name = "1AdminTeacher" };
        //    Person p03 = new Person { Id = 3, Name = "3JustTeacher1" };
        //    Person p04 = new Person { Id = 4, Name = "4JustTeacher2" };
        //    Person p05 = new Person { Id = 5, Name = "5JustTeacher3" };
        //    Person p06 = new Person { Id = 6, Name = "6JustTeacher4" };

        //    Room r1 = new Room { Id = 1, Name = "First Room", MaxCapacity = 10 };
        //    Room r2 = new Room { Id = 2, Name = "Secon Room", MaxCapacity = 8 };

        //    TeacherRoomAssignments.Add(new TeacherRoom { Room = r1, Teacher = p01 });
        //    TeacherRoomAssignments.Add(new TeacherRoom { Room = r1, Teacher = p03 });
        //    TeacherRoomAssignments.Add(new TeacherRoom { Room = r2, Teacher = p04 });
        //    TeacherRoomAssignments.Add(new TeacherRoom { Room = r2, Teacher = p05 });
        //    TeacherRoomAssignments.Add(new TeacherRoom { Room = r2, Teacher = p06 });
        //}

        public int AssignTeacherToARoom(Person teacher, Room room)
        {
            //get room, get teacher, add new pairing, check if exists already
            throw new NotImplementedException();
        }

        public int AssignManyTeachersToARoom(List<int> teacherIds, int roomId)
        {
            //get list of teachers, check existing, assign to new pairing
            throw new NotImplementedException();
        }

        public List<TeacherRoom> GetAllTeacherRoomAssignments()
        {
            return teacherRooms;
        }

        public List<TeacherRoom> GetAllTeachersForRoom(Room r)
        {
            return teacherRooms.Where(x => x.Room.Id == r.Id).ToList();
        }

        public List<TeacherRoom> GetAllRoomsForTeacher(SystemUser t)
        {
            return teacherRooms.Where(x => x.Teacher.Id == t.Id).ToList();
        }
    }
}
