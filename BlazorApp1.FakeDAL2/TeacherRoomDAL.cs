using BlazorApp1.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlazorApp1.FakeDAL2
{
    public partial class MainDAL
    {
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
