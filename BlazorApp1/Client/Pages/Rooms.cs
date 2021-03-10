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
            newRoom = new Room();
            rooms = new List<Room>();
            rooms.Add(new Room { Id = 1, Name = "First Room", MaxCapacity = 10 });
            rooms.Add(new Room { Id = 2, Name = "Secon Room", MaxCapacity = 8 });
        }

        private void ToggleNewRoomInterface()
        {
            showNewRoomUI = !showNewRoomUI;
        }

        private void AddNewRoom()
        {
            if (RoomNumber > 0) //update
            {

                Room toBeUpdated = rooms.Where(x => x.Id == RoomNumber).FirstOrDefault();
                toBeUpdated.Name = newRoom.Name;
                toBeUpdated.MaxCapacity = newRoom.MaxCapacity;
                toBeUpdated.Description = newRoom.Description;
                newRoom = new Room();
                showNewRoomUI = false;
                NavigationManager.NavigateTo("/rooms/");
            }
            else
            {
                if (rooms.Where(x => x.Name.Equals(newRoom.Name, StringComparison.OrdinalIgnoreCase)).Any())
                {
                    ErrorMessage = "A room with this name already exists. Please choose another name.";
                }
                else
                {
                    ErrorMessage = string.Empty;
                    int newId = rooms.Select(x => x.Id).Max();
                    rooms.Add(new Room { Id = newId + 1, Name = newRoom.Name, MaxCapacity = newRoom.MaxCapacity, Description = newRoom.Description });
                    newRoom = new Room();
                    showNewRoomUI = false;
                }
            }

        }

        private void InvalidSubmit()
        {

        }
    }
}
