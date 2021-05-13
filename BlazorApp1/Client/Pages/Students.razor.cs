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
               
            }
            base.OnParametersSet();
        }

        void SetEditable(StudentRoom thisStudentRoom)
        {
            EditingThisId = thisStudentRoom.Id;
        }

        void SaveEdits(StudentRoom editableStudentRoom)
        {
            mainDAL.ChangeRoomAssignmentForAStudent(editableStudentRoom.Id, editableStudentRoom.Room.Id);
            selectedRoom = -1;
            EditingThisId = -1;
            RefreshData();
        }

        void CancelEdit()
        {
            selectedRoom = -1;
            EditingThisId = -1;
        }
        public void RemoveStudentRoomAssignment(int studentRoomAssignmentId)
        {
            mainDAL.RemoveStudentRoomAssignment(studentRoomAssignmentId);
        }

        private void RefreshData()
        {
            allStudentRooms = mainDAL.GetAllStudentRoomAssignments();
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            mainDAL = new MainDAL();
            EditingThisId = -1;
            RefreshData();
            allRooms = mainDAL.GetRooms();
        }

    }
}
