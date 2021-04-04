using BlazorApp1.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlazorApp1.FakeDAL2
{
    public class ParticipantDAL
    {
        public List<Participant> AllParticipants { get; set; }

        public ParticipantDAL()
        {

        }

        public List<Participant> GetParticipantsPerRoom(Room r)
        {
            return AllParticipants.Where(x => x.RoomId == r.Id).ToList();
        }
    }
}
