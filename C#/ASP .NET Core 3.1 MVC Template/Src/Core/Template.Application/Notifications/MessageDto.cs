namespace Template.Application.Notifications
{
    public class MessageDto
    {
        public string From { get; set; }

        public string To { get; set; }

        public string Subject { get; set; }
        
        public string Body { get; set; }
    }
}