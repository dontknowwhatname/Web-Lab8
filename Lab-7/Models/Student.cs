using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab_7.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public int CampusID { get; set; }

        public virtual UniversityCampus Campus { get; set; }

    }
}
