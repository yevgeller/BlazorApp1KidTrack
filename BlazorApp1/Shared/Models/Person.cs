using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Text;

namespace BlazorApp1.Shared.Models
{
    [DebuggerDisplay("{Id}-{Name}")]
    public class Person
    {
        public int Id { get; set; }
        [Required]
        [StringLength(250, ErrorMessage = "User Name may not be longer than 250 characters")]
        public string Name { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }

        public string Login { get; set; }

        public List<Room> TeacherRooms { get; set; }

        public virtual string ForDisplay()
        {
            return $"{Id}-{Name}-{Login}";
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            Person p = obj as Person;

            if (p == null) return false;

            return Id == p.Id && Name == p.Name;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}
