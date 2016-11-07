using System.IO;
using MimeKit;
using UniversalMaibox.Dto;

namespace UniversalMaibox.Composed
{
    public class ComposedMimeMessage
    {
        public MimeMessage MimeMessage { get; set; }
        public ComposedMimeMessage(MessageDto md)
        {
            MimeMessage = new MimeMessage();
            MimeMessage.From.Add(new MailboxAddress(md.From[0], md.From[1]));
            MimeMessage.Subject = md.Subject;
            var body = new TextPart("plain")
            {
                Text = md.Text
            };
            var multipart = new Multipart("mixed") { body };
            foreach (var to in md.To)
            {
                MimeMessage.To.Add(new MailboxAddress(to[0], to[1]));
            }
            if (md.Attachment != null)
            {
                foreach (var a in md.Attachment)
                {
                    var attachment = new MimePart(a[0], a[1])
                    {
                        ContentObject = new ContentObject(File.OpenRead(a[2])),
                        ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
                        ContentTransferEncoding = ContentEncoding.Base64,
                        FileName = Path.GetFileName(a[2])
                    };
                    multipart.Add(attachment);
                }
            }
            MimeMessage.Body = multipart;
        }
    }
}
