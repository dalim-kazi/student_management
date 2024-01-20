using System.ComponentModel.DataAnnotations;

namespace student_management.Models.Dto
{
    public class Student_ManagementDto
    {
        public int Id { get; set; }
        public int Roll { get; set; }

        public int Registation { get; set; }

        public DateTime DateTime { get; set; }= DateTime.Now;

        public string? Student_Name { get; set; }

        public string? Student_Email { get; set; }

        public int present { get; set; }

        public int absent { get; set; }
        public int TotalPresent { get; set; }
        public int TotalAbsent { get; set; }
    }
}
