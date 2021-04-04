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

        public int AssignTeacherToARoom(int teacherId, int roomId)
        {
            throw new NotImplementedException();
        }

        public int AssignManyTeachersToARoom(List<int> teacherIds, int roomId)
        {
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

        public List<TeacherRoom> GetAllRoomsForTeacher(Teacher t)
        {
            return TeacherRoomAssignments.Where(x => x.Teacher.Id == t.Id).ToList();
        }
    }
}
