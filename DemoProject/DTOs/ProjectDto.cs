namespace DemoProject.DTOs
{
    public class ProjectDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int? CreatedById { get; set; }//UserId
        public bool IsCompleted { get; set; }
    }
}
