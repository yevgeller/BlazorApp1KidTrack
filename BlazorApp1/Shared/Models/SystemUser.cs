using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorApp1.Shared.Models
{
    public class SystemUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsTeacher { get; set; }
    }
}
