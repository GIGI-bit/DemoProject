namespace DemoProject.DTOs
{
    public class MessageDto
    {
        public int Id { get; set; }
        public string? Text { get; set; }
        public int? SenderId { get; set; }
        public int? ReceiverId { get; set; }
        public DateTime SentDate { get; set; }
    }
}
