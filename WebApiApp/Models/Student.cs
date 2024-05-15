using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiApp.Models
{
    public partial class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int? UniversityId { get; set; }

        public virtual University University { get; set; }
    }
}
