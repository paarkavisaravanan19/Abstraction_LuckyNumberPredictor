using System.Net.Sockets;
using System.Runtime.ConstrainedExecution;
using System.Xml.Linq;
using System;

namespace Abstraction
{/*
    A company XYZ wants to develop an app which can predict the
    lucky number for a person.
    The name of the app is LuckyNumberPredictor.
    This app consists of a method - upon calling the person gets 
    to know his/her lucky number.
    This method calls another class —> NumberPredictor - which have 
    the formula for predicting the lucky number of that person.
    This approach is done so that no-one else gets
    to know the secret formula for this prediction.

    
    LuckyNumberPredictor accepts only one argument i.e: date of birth of the person. 
    The formula for predicting the lucky number is quite simple -> a person’s lucky 
    number is calculated by rounding off the date of birth to the nearest Fibonacci number.
    Another thought that XYZ company is  having - is to predict unlucky number as well - 
    but for this — for now, they don’t have any formula ready.But they want to have this idea 
    to be stored in - in their NumberPredictor class. The company is asking you to develop this system.
   */ 
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime dob;
            try
            {
                Console.WriteLine("Enter the date of birth in the format: eg: 19/09/2001");
                dob = Convert.ToDateTime(Console.ReadLine());
                LuckyNumberPredictor obj = new Implementation();
                obj.NumberPredictor(dob);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Provide the valid date of birth");
            }
        }
    }
    abstract class LuckyNumberPredictor
    {
        public abstract void NumberPredictor(DateTime dob);
        public void UnLuckyNumberPredictor()
        {
            //can calculate unlucky number;
        }
    }
    class Implementation : LuckyNumberPredictor
    {
        public override void NumberPredictor(DateTime dob)
        {
            
            string dob1 = dob.ToString();
            string[] dob2 = dob1.Split('-');
            string d = "";
            foreach (string s in dob2)
            {
                d = s.ToString();
                break;
            }
            
            int num = Int32.Parse(d);
            int first = 0, second = 1;
            int third = first + second;

            while (third <= num)
            {
                first = second;
                second = third;

                third = first + second;
            }
            int ans = (Math.Abs(third - num) >= Math.Abs(second - num)) ? second : third;
            Console.Write("Your Lucky Number is : "+ans);
        }
    }


}