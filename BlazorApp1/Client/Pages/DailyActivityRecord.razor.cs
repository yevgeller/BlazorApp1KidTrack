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

        Person student;
        //List<StudentRoom> allStudentRooms;

        //List<Room> rooms;

        [Parameter]
        public int StudentId { get; set; }

        //public int EditingThisId { get; set; }
        //private int selectedRoom;
        //public List<Room> allRooms;

        [Inject]
        NavigationManager nm { get; set; }

        DateTime groupActivityDateVar;
        DateTime groupActivityTimeVar;
        public string GroupActivityDate
        {
            get
            {
                return groupActivityDateVar.ToString("ddd d MMM");
            }
            private set { }
        }
        public string GroupActivityTime
        {
            get
            {
                return groupActivityTimeVar.ToString("h:mm");
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

        public void PrevDay()
        {
            var dayOfWeek = groupActivityDateVar.DayOfWeek;
            int increment = -1;
            if (dayOfWeek == DayOfWeek.Monday)
            {
                increment = -3;
            }
            groupActivityDateVar = groupActivityDateVar.AddDays(increment);
        }

        public void NextDay()
        {
            var dayOfWeek = groupActivityDateVar.DayOfWeek;
            int increment = 1;
            if (dayOfWeek == DayOfWeek.Friday)
            {
                increment = 3;
            }
            groupActivityDateVar = groupActivityDateVar.AddDays(increment);
        }
        public void FifteenMinPrior()
        {
            groupActivityTimeVar = groupActivityTimeVar.AddMinutes(-15);
        }

        public void FifteenMinFwd()
        {
            groupActivityTimeVar = groupActivityTimeVar.AddMinutes(15);
        }

        public void SmallMinuteDecrement()
        {
            groupActivityTimeVar = groupActivityTimeVar.AddMinutes(-3);
        }
        public void SmallMinuteIncrement()
        {
            groupActivityTimeVar = groupActivityTimeVar.AddMinutes(3);
        }
        protected override void OnParametersSet()
        {
            StudentId = StudentId;
            base.OnParametersSet();
        }
        protected override void OnInitialized()
        {
            mainDAL = new MainDAL();
            student = mainDAL.GetPersonById(StudentId);
            groupActivityDateVar = DateTime.Now;
            groupActivityTimeVar = DateTime.Now;
            base.OnInitialized();
        }
    }
}
