using BlazorApp1.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlazorApp1.FakeDAL
{
    public class RoomsDAL
    {
        List<Room> rooms;

        public RoomsDAL()
        {
            rooms = new List<Room>();
            rooms.Add(new Room { Id = 1, Name = "First Room", MaxCapacity = 10 });
            rooms.Add(new Room { Id = 2, Name = "Secon Room", MaxCapacity = 8 });
        }

        public List<Room> GetRooms()
        {
            return rooms;
        }

        public int AddRoom(Room room)
        {
            if(room.Id == 0)
            {
                room.Id = rooms.Select(x => x.Id).Max();
            }

            rooms.Add(room);
            return room.Id;
        }

        public void DeleteRoom(int id)
        {
            rooms.RemoveAll(x => x.Id == id);
        }

        public void DeleteRoom(Room room)
        {
            rooms.RemoveAll(x => x.Id == room.Id);
        }

        public void EditRoom(Room room)
        {
            Room r = rooms.Where(x => x.Id == room.Id).FirstOrDefault();
            if (r == null)
                throw new Exception("Cannot find room, no such room found");

            r.Name = room.Name;
            r.MaxCapacity = room.MaxCapacity;
            r.Description = room.Description;
        }

    }
}
