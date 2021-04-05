using BlazorApp1.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlazorApp1.FakeDAL2
{
    public class TeacherRoomDAL
    {
        public List<TeacherRoom> TeacherRoomAssignments { get; set; }

        public TeacherRoomDAL()
        {
            //List<SystemUser> users = new List<SystemUser>();
            SystemUser su1 = new SystemUser { Id = 1, IsAdmin = true, IsTeacher = true, Name = "AdminTeacher" };
            SystemUser su3 = new SystemUser { Id = 3, IsAdmin = false, IsTeacher = true, Name = "JustTeacher" };
            SystemUser su5 = new SystemUser { Id = 5, IsAdmin = false, IsTeacher = true, Name = "Teacher5" };
            SystemUser su6 = new SystemUser { Id = 6, IsAdmin = false, IsTeacher = true, Name = "Teacher6" };
            
            //users.Add();
            //users.Add();
            //users.Add();
            //users.Add();



            //List<Room> rooms = new List<Room>();
            Room r1 = new Room { Id = 1, Name = "First Room", MaxCapacity = 10 };
            Room r2 = new Room { Id = 2, Name = "Secon Room", MaxCapacity = 8 };
            //rooms.Add(r1);
            //rooms.Add(r2);

            TeacherRoomAssignments.Add(new TeacherRoom { Room = r1, Teacher = su1 });
            TeacherRoomAssignments.Add(new TeacherRoom { Room = r1, Teacher = su5 });
            TeacherRoomAssignments.Add(new TeacherRoom { Room = r2, Teacher = su3 });
            TeacherRoomAssignments.Add(new TeacherRoom { Room = r2, Teacher = su6 });

        }

        public int AssignTeacherToARoom(int teacherId, int roomId)
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
            return TeacherRoomAssignments;
        }

        public List<TeacherRoom> GetAllTeachersForRoom(Room r)
        {
            return TeacherRoomAssignments.Where(x => x.Room.Id == r.Id).ToList();
        }

        public List<TeacherRoom> GetAllRoomsForTeacher(SystemUser t)
        {
            return TeacherRoomAssignments.Where(x => x.Teacher.Id == t.Id).ToList();
        }
    }
}
