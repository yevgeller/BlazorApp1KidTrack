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
        RoomsDAL roomsDAL;

        protected override void OnParametersSet()
        {
            if (RoomId < 1)
                throw new ArgumentException("Room id number is missing", "RoomId");
            RoomId = RoomId;
            thisRoom = roomsDAL.GetRoom(RoomId);
            base.OnParametersSet();
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            roomsDAL = new RoomsDAL();
        }
    }
}
