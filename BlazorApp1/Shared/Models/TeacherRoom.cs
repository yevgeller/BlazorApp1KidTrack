﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorApp1.Shared.Models
{
    public class TeacherRoom
    {
        public int Id { get; set; }
        public Person Teacher { get; set; }
        public Room Room { get; set; }

        public override string ToString()
        {
            return $"{Id}::{Room.Id}-{Room.Name}/{Teacher.Id}-{Teacher.Name}";
        }
    }
}
