using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBindingDemo
{
    public abstract class IFeeDetail : Fee 
    {
        public Fee fee;
        public void SetComponent(Fee fee)
        {
            this.fee = fee;
        }


        public override void Operation(Student s)
        {
            
            s.AfterDiscountedFee = s.MonthlyFee;
        }
               
    }



    public class ChildernDiscount: IFeeDetail
    {

        public override void Operation(Student s)
        {
            AddOn(s);            
        }

        public void AddOn(Student s)
        {
            float discountPer = 5;
            float fee = s.AfterDiscountedFee;
            List<Student> temp = s.Parent.Students.ToList();
            int TotalChildern = temp.Count;
            for (int i = 0; i < TotalChildern-1; i++)
            {
                float discount;
                discount = fee * (discountPer / 100);
                fee = fee - discount;
                if (i == 5)
                    break;
            }
            s.AfterDiscountedFee = (long)fee;

        }
    }

    public class OnAttendenceDiscount : IFeeDetail
    {
        public override void Operation(Student s)
        {
           
            base.Operation(s);
            AddOn(s);    


        }
        public void AddOn(Student s)
        {
            
            float discountPer = 5;
            float fee = (float)s.AfterDiscountedFee;
            Random random = new Random();
            int AttendencePercent = random.Next(70, 100);
            if (AttendencePercent > 85)
            {
                float discount;
                discount = fee * (discountPer / 100);
                fee = fee-discount;
            }
            s.AfterDiscountedFee = (long)fee;


        }

    }
        
           

    public class GetScholarship : IFeeDetail
    {

        public override void Operation(Student s)
        {
           AddOn(s);
        }
        public void AddOn(Student s)
        {
            float discountPer = 5;
            float fee = (float)s.AfterDiscountedFee;
            Random random = new Random();
            int AttendencePercent = random.Next(70, 100);
            if (AttendencePercent > 85)
            {
                float discount;
                discount = fee * (discountPer / 100);
                fee = fee - discount;
            }
            s.AfterDiscountedFee = (long)fee;


        }
    }


    public class Onfine : IFeeDetail
    {

        public override void Operation(Student s)
        {
            AddOn(s);
        }
        public void AddOn(Student s)
        {
            long fine = 2000;
            s.OtherCharges += fine; 
           
        }
    }

}


