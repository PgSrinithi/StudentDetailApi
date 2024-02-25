using System.ComponentModel.DataAnnotations;

namespace StudentDetailsBackend.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string StudentName { get; set; }
        public string course { get; set; }
    }
}
