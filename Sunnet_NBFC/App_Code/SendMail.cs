using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using Sunnet_NBFC.Models;
using System.IO;
namespace Sunnet_NBFC.App_Code
{
    public class clsSendMail
    {
        public int SendMail(clsMailTemplate cls)
        {
            int a = 0;
            string emailSender = ConfigurationManager.AppSettings["username"].ToString();
            string emailSenderPassword = ConfigurationManager.AppSettings["password"].ToString();
            string emailSenderHost = ConfigurationManager.AppSettings["smtp"].ToString();
            int emailSenderPort = Convert.ToInt16(ConfigurationManager.AppSettings["portnumber"]);
            Boolean emailIsSSL = Convert.ToBoolean(ConfigurationManager.AppSettings["IsSSL"]);


            //Base class for sending email  
            MailMessage _mailmsg = new MailMessage();

            //Make TRUE because our body text is html  
            _mailmsg.IsBodyHtml = true;

            //Set From Email ID  
            _mailmsg.From = new MailAddress(emailSender);

            //Set To Email ID  
            _mailmsg.To.Add(cls.ToMail.ToString());

            //Set Subject  
            _mailmsg.Subject = cls.Subject;

            //Set Body Text of Email   
            _mailmsg.Body = cls.Body;
            if (cls.Attachment != "")
            {
                _mailmsg.Attachments.Add(new Attachment(cls.Attachment));
            }
            //Now set your SMTP   
            SmtpClient _smtp = new SmtpClient();

            //Set HOST server SMTP detail  
            _smtp.Host = emailSenderHost;

            //Set PORT number of SMTP  
            _smtp.Port = emailSenderPort;

            //Set SSL --> True / False  
            _smtp.EnableSsl = emailIsSSL;

            //Set Sender UserEmailID, Password  
            NetworkCredential _network = new NetworkCredential(emailSender, emailSenderPassword);
            _smtp.Credentials = _network;

            //Send Method will send your MailMessage create above.  
            _smtp.Send(_mailmsg);
            return a;


        }

        public string TicketMail(string UserName,string TicketNo,string FilePath)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(FilePath))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{Client Name}",UserName);
            body = body.Replace("{TicketNo}", TicketNo);
            return body;
        }
    }

}