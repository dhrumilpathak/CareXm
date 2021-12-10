using System;
using System.Text.RegularExpressions;

namespace PhoneNumberValidation
{
    class PhoneNumberVaidation
    {

        public string FormatePhoneNumber(long number)
         {
           
            string formatedPhoneNumber = number.ToString();
            int a = formatedPhoneNumber.Length;
            if (a == 10)
            {
                formatedPhoneNumber = Regex.Replace(formatedPhoneNumber, @"(\d{3})(\d{3})(\d{4})", "$1-$2-$3");
            
            }
            else 
            {
                throw new Exception("The Phone number entered should be of 10 Digit only");
            }

            return formatedPhoneNumber;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter the Phone Number");
            long phonenumber = Convert.ToInt64(Console.ReadLine());

            PhoneNumberVaidation p1 = new PhoneNumberVaidation();

            Console.WriteLine(p1.FormatePhoneNumber(phonenumber));
            Console.ReadLine();

        }
    }
}

