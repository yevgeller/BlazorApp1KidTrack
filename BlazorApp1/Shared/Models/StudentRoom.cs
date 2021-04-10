using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorApp1.Shared.Models
{
    public class StudentRoom
    {
        public int Id { get; set; }
        public Person Student { get; set; }
        public Room Room { get; set; }

        public override string ToString()
        {
            return $"{Id}::{Student.Id}-{Student.Name}/{Room.Id}-{Room.Name}";
        }
    }
}
