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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
