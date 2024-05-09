using System.Net;
using SmaguciaiCore.Interfaces.Services;
using System.Net.Mail;

namespace SmaguciaiInfrastructure.ExternalServices;

public class PasswordEditEmailServices : IPasswordEditEmailService
{
    public bool PasswordEditEmail(string email)
    {
        MailMessage mailMessage = new MailMessage();
        mailMessage.From = new MailAddress("smaguciaiINFO@gmail.com");
        mailMessage.To.Add(email);
        mailMessage.Subject = "Smagučiai sistemos slaptažodžio pakeitimas";
        mailMessage.Body = "Jūsų slaptažodis buvo sėkmingai pakeistas";

        SmtpClient smtpClient = new SmtpClient();

        // Specify Gmail's SMTP server and appropriate port for secure communication
        smtpClient.Host = "smtp.gmail.com";
        smtpClient.Port = 587; // Port 587 for TLS/STARTTLS
        smtpClient.EnableSsl = true; // Enable SSL/TLS
        smtpClient.UseDefaultCredentials = false;

        // Set credentials for Gmail account
        smtpClient.Credentials = new NetworkCredential("smaguciaiINFO@gmail.com", "lloi fvxr mvwc ynml");

        try
        {
            smtpClient.Send(mailMessage);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }  
}