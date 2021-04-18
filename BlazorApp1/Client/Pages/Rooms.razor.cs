using BlazorApp1.FakeDAL2;
using BlazorApp1.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1.Client.Pages
{
    public partial class Rooms
    {
        [Parameter]
        public int RoomNumber { get; set; }

        [Inject]
        NavigationManager NavigationManager { get; set; }

        Room newRoom;
        MainDAL mainDAL;

        public string ErrorMessage { get; set; } = string.Empty;
        public bool NoErrors { get { return ErrorMessage == null || ErrorMessage.Length == 0; } }

        bool showNewRoomUI = false;

        List<Room> rooms;

        protected override void OnParametersSet()
        {
            RoomNumber = RoomNumber;
            if (RoomNumber > 0)
            {
                Room r = rooms.Where(x => x.Id == RoomNumber).FirstOrDefault();
                if (r != null)
                {
                    newRoom.Id = r.Id;
                    newRoom.MaxCapacity = r.MaxCapacity;
                    newRoom.Description = r.Description;
                    newRoom.Name = r.Name;
                    showNewRoomUI = true;
                }
            }
            base.OnParametersSet();
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            mainDAL = new MainDAL();
            newRoom = new Room();
            rooms = mainDAL.GetRoomsWithTeachersAndStudents();
        }

        private void ToggleNewRoomInterface()
        {
            showNewRoomUI = !showNewRoomUI;
        }

        private void AddNewRoom()
        {
            if (rooms.Where(x => x.Name.Equals(newRoom.Name, StringComparison.OrdinalIgnoreCase)).Any())
            {
                ErrorMessage = "A room with this name already exists. Please choose another name.";
            }
            else
            {
                if (RoomNumber > 0) //update
                {
                    Room toBeUpdated = new Room
                    {
                        Id = RoomNumber,
                        Name = newRoom.Name,
                        MaxCapacity = newRoom.MaxCapacity,
                        Description = newRoom.Description
                    };
                    
                    mainDAL.EditRoom(toBeUpdated);
                    NavigationManager.NavigateTo("/rooms/");
                }
                else
                {
                    ErrorMessage = string.Empty;
                    Room r = new Room { Id = 0, Name = newRoom.Name, MaxCapacity = newRoom.MaxCapacity, Description = newRoom.Description };
                    mainDAL.AddRoom(r);
                    rooms = mainDAL.GetRoomsWithTeachersAndStudents();
                }

                newRoom = new Room();
                showNewRoomUI = false;
            }
        }

        private void InvalidSubmit() { }

        private void Cancel()
        {
            NavigationManager.NavigateTo("/rooms/");
            ErrorMessage = string.Empty;
            newRoom = new Room();
            showNewRoomUI = false;
        }
    }
}
