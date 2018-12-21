using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DataBindingDemo
{
    public class SMTPHelper
    {
        private SmtpClient SMTP;
        private string email = "bscs15009@itu.edu.pk";
        private string password = "codename12814034";
        private MailAddress addressFrom;
        private string name = "Muhammad Sannan Nasir";
        public SMTPHelper()
        {
            SMTP = new SmtpClient();
            SMTP.Host = "smtp.gmail.com";
            SMTP.Port = 587;
            SMTP.EnableSsl = true;
            SMTP.UseDefaultCredentials = false;
            SMTP.Credentials = new NetworkCredential(email, password);
            addressFrom = new MailAddress(email,name);
        }
        public bool SendEmail(List<Teacher> ts,string message, string subject)
        {
            
            MailMessage msg = new MailMessage();
            if (ts == null)
            {
                return false;
            }
            foreach (var teacher in ts)
            {
                if (teacher.Employee.EmailID != null)
                {
                    msg.To.Add(teacher.Employee.EmailID);
                }
            }
            msg.From = addressFrom;
            msg.To.Add("msannan2@gmail.com");
            msg.Subject = subject;
            msg.Body = message;
            try
            {
                SMTP.Send(msg);
                return true;
            }
            catch (SmtpException e)
            {
                Console.WriteLine("Error: {0}", e.StatusCode);
                return false;
            }
               
        }
    }
}
