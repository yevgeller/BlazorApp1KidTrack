using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Text;

namespace BlazorApp1.Shared.Models
{
    [DebuggerDisplay("${ForDisplay}")]
    public class SystemUser
    {
        public int Id { get; set; }
        [Required]
        [StringLength(250, ErrorMessage = "User Name may not be longer than 250 characters")]
        public string Name { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsTeacher { get; set; }

        public string ForDisplay()
        {
            return $"{Id}-{Name}-{IsAdmin}-{IsTeacher}";
        }
    }
}
