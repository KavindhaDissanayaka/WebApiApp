using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiApp.Models
{
    public partial class University
    {
        public University()
        {
            Students = new HashSet<Student>();
        }

        public int UniversityId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
