using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazorApp1.Shared.Models
{
    public class Person
    {
        public int Id { get; set; }
        [Required]
        [StringLength(250, ErrorMessage = "User Name may not be longer than 250 characters")]
        public string Name { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }

        public string ForDisplay()
        {
            return $"{Id}-{Name}";
        }
    }
}
