using System.Collections.Generic;

namespace UniversalMaibox.Dto
{
    public class MessageDto
    {
        public MessageDto(
            string[] from, List<string[]> to, 
            string subject, string text, List<string[]> attachment
        )
        {
            From = from;
            To = to;
            Subject = subject;
            Text = text;
            Attachment = attachment;
        }
        public string[] From { get; set; }
        public List<string[]> To { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
        public List<string[]> Attachment { get; set; }
    }
}
