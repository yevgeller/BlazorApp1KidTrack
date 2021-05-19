using BlazorApp1.FakeDAL2;
using BlazorApp1.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1.Client.Pages
{
    public partial class DailyActivityRecord
    {
        MainDAL mainDAL;

        //List<StudentRoom> allStudentRooms;

        //List<Room> rooms;

        [Parameter]
        public int StudentId { get; set; }

        //public int EditingThisId { get; set; }
        //private int selectedRoom;
        //public List<Room> allRooms;

        [Inject]
        NavigationManager nm { get; set; }

        protected override void OnParametersSet()
        {
            StudentId = StudentId;
            base.OnParametersSet();
        }
        protected override void OnInitialized()
        {
            mainDAL = new MainDAL();
            base.OnInitialized();
        }
    }
}
