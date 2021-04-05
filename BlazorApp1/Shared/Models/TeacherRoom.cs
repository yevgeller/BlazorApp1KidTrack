using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorApp1.Shared.Models
{
    public class TeacherRoom
    {
        public SystemUser Teacher { get; set; }
        public Room Room { get; set; }
    }
}
