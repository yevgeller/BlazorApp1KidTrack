using BlazorApp1.FakeDAL2;
using BlazorApp1.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1.Client.Pages
{
    public partial class RoomDetails
    {
        [Parameter]
        public int RoomId { get; set; }

        [Inject]
        NavigationManager nm { get; set; }

        Room thisRoom;
        MainDAL mainDAL;
        List<int> allTeacherIds;
        List<int> allStudentIds;
        List<Role> roles;

        protected override void OnParametersSet()
        {
            if (RoomId < 1)
                throw new ArgumentException("Room id number is missing", "RoomId");
            RoomId = RoomId;
            roles = mainDAL.GetAllRoles();
            Role teacherRole = roles.Where(x => x.Name.ToLower().Contains("teacher")).First();
            Role studentRole = roles.Where(x => x.Name.ToLower().Contains("student")).First();
            thisRoom = mainDAL.GetRoomWithTeachersAndStudents(RoomId);
            allTeacherIds = mainDAL.GetAllPersonsInRole(new Role { Id = teacherRole.Id, Name = teacherRole.Name }).Select(x => x.Id).ToList();
            allStudentIds = mainDAL.GetAllPersonsInRole(new Role { Id = studentRole.Id, Name = studentRole.Name }).Select(x => x.Id).ToList(); ;
            base.OnParametersSet();
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            mainDAL = new MainDAL();
        }
    }
}
