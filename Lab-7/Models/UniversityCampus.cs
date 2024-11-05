using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab_7.Models
{
    public class UniversityCampus
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Student> Students { get; set; } = new HashSet<Student>();

        public string StudentNames
        {
            get
            {
                return string.Join(", ", Students.Select(s => s.Name));
            }
        }
    }
}
