using System.Collections.Generic;

namespace Lab_7.Models
{
    public class SearchStudentViewModel
    {
        public string StudentName { get; set; } 
        public int? CampusID { get; set; }  

        public IEnumerable<UniversityCampus> Campuses { get; set; } 
        public IEnumerable<Student> Students { get; set; }  
    }
}
