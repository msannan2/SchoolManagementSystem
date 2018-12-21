using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBindingDemo
{
    public class NotificationViewModel
    {
        List<Recipients> recipients;
        Recipients parent, employee, teacher;
        public NotificationViewModel()
        {
            recipients = new List<Recipients>();
            parent = new RepParent();
            employee = new RepEmployee();
            teacher = new RepTeacher();
        }
        public bool UpdateAll(string message,string subject)
        {
            foreach(var recipient in recipients)
            {
                recipient.Update(message,subject);
            }
            return true;
        }
    }
}
