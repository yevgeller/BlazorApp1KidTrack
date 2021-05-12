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

        public int EditingThisId { get; set; }
        private int selectedRoom;
        public List<Room> allRooms;

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

        void SetEditable(StudentRoom thisStudentRoom)
        {
            EditingThisId = thisStudentRoom.Id;
        }

        void SaveEdits(StudentRoom editableStudentRoom)
        {
            int newRoomId = selectedRoom;
        }

        void CancelEdit()
        {
            selectedRoom = -1;
            EditingThisId = -1;
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            mainDAL = new MainDAL();
            EditingThisId = -1;
            allStudentRooms = mainDAL.GetAllStudentRoomAssignments();
            allRooms = mainDAL.GetRooms();
        }

    }
}
