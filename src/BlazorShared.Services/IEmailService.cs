using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorShared.Services;
public interface IEmailService
{
    void SendEmail(EmailDto email);
}

// create a class that represents and email object

public class EmailDto
{
    public Guid Id { get; set; }
    public string To { get; set; }
    public string From { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public DateTime DateSent { get; set; }
    public bool IsSent { get; set; }
    public bool IsRead { get; set; }
    public bool IsImportant { get; set; }
    public bool IsDeleted { get; set; }
    public List<AttachmentDto>  Attachments { get; set; }
}

public class AttachmentDto
{


    public Guid Id { get; set; }
    public string FileName { get; set; }
    public string FileExtension { get; set; }
    public string FileSize { get; set; }
    public string FileLocation { get; set; }
    public byte[] File { get; set; }


}


