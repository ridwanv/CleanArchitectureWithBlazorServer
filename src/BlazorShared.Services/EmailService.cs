using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazor.Templates;
using BlazorTemplater;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using PreMailer.Net;
using static MudBlazor.CategoryTypes;

namespace BlazorShared.Services;

[ScopedRegistration]
public class EmailService : IEmailService
{
    public void SendEmail(EmailDto email)
    {
        var html = new ComponentRenderer<InvitationTemplate>().Render();
        email.Body = PreMailer.Net.PreMailer.MoveCssInline(html).Html;
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("FromName", "fromAddress@gmail.com"));
        message.To.Add(new MailboxAddress("Ridwan", email.To));
        message.Subject = email.Subject;
        message.Body = new TextPart("plain") { Text = email.Body };

        using (var client = new SmtpClient())
        {
            try
            {
                if (!client.IsConnected)
                {
                    client.ConnectAsync("smtp.gmail.com", 587, false);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                }
                if (!client.IsAuthenticated)
                {
                    client.AuthenticateAsync("nvisionitdev123@gmail.com", "nvisionit");
                }

                client.SendAsync(message);
                client.DisconnectAsync(true);

              
            }
            catch (SmtpCommandException ex)
            {
                throw;
            }
            catch (SmtpProtocolException ex)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception($"The email from  captured but not sent to the owner");
            }

        }


        //using (var client = new SmtpClient())
        //{
           
        //    client.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
        //    client.Authenticate("nvisionitdev123@gmail.com", "nvisionit");
        //    client.Send(message);
        //    client.Disconnect(true);
        //}
    }
}
