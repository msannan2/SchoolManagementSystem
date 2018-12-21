using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBindingDemo
{
    public abstract class Fee
    {
        public abstract void Operation(Student s);
    }



   public class ConcreteFee : Fee

    {
        public override void Operation(Student s)
        {
            Console.WriteLine("ConcreteComponent.Operation()");
        }
    }
}
