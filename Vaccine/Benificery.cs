using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vaccine
{
    public class Benificery
    {
        private int _autoincrementer = 1001;
        public int ID { get; set; }
        public string Name { get; set; }
        public long MobileNumber { get; set; }
        public string City { get; set; }
        public int Age { get; set; }
        public GenderChoice Gender { get; set; }
        public List<Vaccine> VaccDetails = new List<Vaccine>();


        public Benificery(string name, long mobileno, string city, int age, int gender)
        {
            ID = _autoincrementer++;
            Name = name;
            MobileNumber = mobileno;
            City = city;
            Age = age;
            Gender = (GenderChoice)gender;


        }
        public string Vaccinatee(int vaccine, DateTime date)
        {
            string message = null;
            if (VaccDetails.Count == 0)
            {
                Vaccine dtil = new Vaccine(vaccine, date, 1);
                VaccDetails.Add(dtil);
                message = $"Your next dose date is {dtil.VaccinateDate.AddDays(30).ToString("dd/MM/yyyy")}";
            }
            else if (VaccDetails.Count == 1)
            {
                if (VaccDetails[0].VaccinateDate > VaccDetails[0].VaccinateDate.AddDays(30))
                {
                    Vaccine dtil = new Vaccine(vaccine, date, 2);
                    message = "You completed the both vaccination,Thanks!...";
                    return message;
                }
                else
                {
                    message = $"you are not allowed for 2nd vaccination,your next vaccination date{VaccDetails[0].VaccinateDate.AddDays(30).ToString("dd/mm/yyyy")}";
                    return message;
                }
            }
            else
            {
                message = "You Already Complete Both Dosage";
                return message;
            }
            return message;



        }
        public string DueDate()
        {
            string msg = null;
            if (VaccDetails.Count == 1)
            {
                msg = $"Your Next Vaccination Date is {VaccDetails[0].VaccinateDate.AddDays(30).ToString("dd/MM/yyyy")}";
                return msg;
            }
            else
            {
                msg = "You Complete the vaccination Thanks for participation...";
                return msg;
            }
        }
    }
    public enum GenderChoice
    {
        Male=1, 
        Female, 
        Transgender



    }









}
