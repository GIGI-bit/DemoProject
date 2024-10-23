namespace DemoProject.DTOs
{
    public class WorkDto
    {
        public string? Title { get; set; }

        public string? Description { get; set; }

        public DateTime Deadline { get; set; }
        public string? Status { get; set; }

        public string? Priority { get; set; }// Urgent, Primary, Simple
        public int ProjectId { get; set; }

        public int? CreatedById { get; set; }//userId
    }
}
