using BlazorApp1.FakeDAL2;
using BlazorApp1.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1.Client.Pages
{
    public partial class Students
    {
        MainDAL mainDAL;

        List<StudentRoom> allStudentRooms;

        //List<Room> rooms;

        [Parameter]
        public int Id { get; set; }

        [Inject]
        NavigationManager nm { get; set; }

        protected override void OnParametersSet()
        {
            Id = Id;
            if(Id > 0)
            {
                //Person p = mainDAL.GetStudentRoomAssignments();
                //if(p != null)
                //{

                //}
            }
            base.OnParametersSet();
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            mainDAL = new MainDAL();

            allStudentRooms = mainDAL.GetAllStudentRoomAssignments();
        }

    }
}
