using System.Net;
using SmaguciaiCore.Interfaces.Services;
using System.Net.Mail;

namespace SmaguciaiInfrastructure.ExternalServices;

public class DiscountCodeEmailServices : IDiscountCodeEmailService
{
    public bool EmailSendingFunction(string email, string discountCode, DateTime expirationDate)
    {
        MailMessage mailMessage = new MailMessage();
        mailMessage.From = new MailAddress("smaguciaiINFO@gmail.com");
        mailMessage.To.Add(email);
        mailMessage.Subject = "Smagučiai sistemos nuolaidos kodas";
        mailMessage.Body = "Dėkui už aktyvų prisidėjimą prie mūsų elektroninės parduotuvės ir palikus 10 atsiliepimų. Pateikiame Jums 15% nuolaidos kodą: " + discountCode
            + " . Jis galioja iki: "+expirationDate.Year+"-"+expirationDate.Month+"-"+expirationDate.Day;

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