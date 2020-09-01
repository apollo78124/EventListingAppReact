namespace EventReactApp.Models
{
    public class CommentModel
    {
        
        public int Id { get; set; }
        public string Author { get; set; }
        public string EventName { get; set; }
        public string Text { get; set; }
        public string EventKeyword { get; set; }
        public string EventSummary { get; set; }
        public int EventSort { get; set; }
        public int CategoryId { get; set; }
    }
}
