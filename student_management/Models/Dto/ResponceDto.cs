namespace student_management.Models.Dto
{
    public class ResponceDto
    {
        public object? Result {  get; set; }
        public bool? Success { get; set; } = true;
        public string? Massage { get; set; }

    }
}
