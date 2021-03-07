using BlazorApp1.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1.Client.Pages
{
    public partial class Rooms
    {
        Room newRoom;

        public string NewRoomName { get; set; } = "First room";
        public int NewRoomMaxCap { get; set; } = 10;
        public string NewRoomDescription { get; set; } = "Awesome new room!";
        public string ErrorMessage { get; set; } = string.Empty;
        public bool NoErrors { get { return ErrorMessage == null || ErrorMessage.Length == 0; } }

        bool showNewRoomUI = false;

        List<Room> rooms;

        protected override void OnInitialized()
        {
            base.OnInitialized();
            newRoom = new Room();
            rooms = new List<Room>();
            rooms.Add(new Room { Id = 1, Name = "First Room", MaxCapacity = 10 });
            rooms.Add(new Room { Id = 1, Name = "Secon Room", MaxCapacity = 8 });
        }

        private void ToggleNewRoomInterface()
        {
            showNewRoomUI = !showNewRoomUI;
        }

        private void AddNewRoom()
        {
            bool roomExists = rooms.Where(x => x.Name.Equals(NewRoomName, StringComparison.OrdinalIgnoreCase)).Any();
            if (roomExists)
                ErrorMessage = "A room with this name already exists. Please choose another name.";
            else
            {
                ErrorMessage = string.Empty;
                int newId = rooms.Select(x => x.Id).Max();
                rooms.Add(new Room { Id = newId + 1, Name = NewRoomName, Description = NewRoomDescription, MaxCapacity = NewRoomMaxCap });
                NewRoomName = NewRoomDescription = ErrorMessage = string.Empty;
                NewRoomMaxCap = 0;
                showNewRoomUI = false;
            }

        }
    }
}
