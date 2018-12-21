using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBindingDemo
{
    public abstract class Recipients
    {
        public abstract bool Update(string message,string subject);

    }


    public class RepEmployee : Recipients
    {
        public override bool Update(string message, string subject)
        {
            List<Employee> T;
            bool error;
            SMSHelper h = new SMSHelper();
            using (var context = new mainEntities())
            {
                T = context.Employees.ToList();
                error = h.SendSMS(T, message);
            }
            return error;
        }
    }


    public class RepTeacher : Recipients
    {
        public override bool Update(string message, string subject)
        {
            List<Teacher> T;
            bool error;
            SMTPHelper h = new SMTPHelper();
            using (var context = new mainEntities())
            {
                T  = context.Teachers.ToList();
                error=h.SendEmail(T, message, subject);
            }
            return error;
        }
    }

    public class RepParent : Recipients
    {
        public override bool Update(string message, string subject)
        {
            List<Parent> T;
            bool error;
            SMSHelper h = new SMSHelper();
            using (var context = new mainEntities())
            {
                T = context.Parents.ToList();
                error = h.SendSMS(T, message);
            }
            return error;
        }
    }
}
