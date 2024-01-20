using System.ComponentModel.DataAnnotations;

namespace student_management.Models
{
    public class Student_Management
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Roll {  get; set; }

        [Required]
        public int Registation {  get; set; }

        [Required]
        public DateTime DateTime { get; set; }
        [Required]
        public string? Student_Name { get; set; }

        [Required]
        public string? Student_Email { get; set; }

        [Required]
        public int present {  get; set; }

        [Required]
        public int absent { get; set; }


    }
}
