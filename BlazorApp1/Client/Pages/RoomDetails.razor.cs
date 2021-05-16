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

        public string GroupActivityDate
        {
            get
            {
                return groupActivityDateVar.ToString("ddd d MMM");
            }
            private set { }
        }

        public bool TooFarInTheFuture()
        {
            if (DateTime.Now.AddDays(7) < groupActivityDateVar)
                return true;

            return false;
        }

        public bool TooFarInThePast()
        {
            if (DateTime.Now.AddDays(-7) > groupActivityDateVar)
                return true;

            return false;
        }

        Room thisRoom;
        MainDAL mainDAL;
        List<int> allTeacherIds;
        List<int> allStudentIds;
        List<Role> roles;
        DateTime groupActivityDateVar;

        public void PrevDay()
        {
            var dayOfWeek = groupActivityDateVar.DayOfWeek;
            int increment = -1;
            if(dayOfWeek == DayOfWeek.Monday)
            {
                increment = -3;
            }
            groupActivityDateVar = groupActivityDateVar.AddDays(increment);
            //if (DateTime.Now.AddDays(-7) < candidate)
            //    groupActivityDateVar = candidate;
        }

        public void NextDay()
        {
            var dayOfWeek = groupActivityDateVar.DayOfWeek;
            int increment = 1;
            if(dayOfWeek == DayOfWeek.Friday)
            {
                increment = 3;
            }

            groupActivityDateVar = groupActivityDateVar.AddDays(increment);
        }

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
            groupActivityDateVar = DateTime.Now;
            base.OnParametersSet();
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            mainDAL = new MainDAL();
        }
    }
}
