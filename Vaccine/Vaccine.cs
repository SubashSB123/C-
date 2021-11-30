using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vaccine
{
    public class Vaccine
    {
        public VaccinationType Vaccin { get; set; }
        public int Dosage { get; set; }
        public DateTime VaccinateDate { get; set; }
        public Vaccine(int vaccinee, DateTime date,int dose)
        {
            Vaccin = (VaccinationType)vaccinee;
            VaccinateDate = date;
            Dosage = dose;
        }

       
       
        
    }
    public enum VaccinationType
    {
        Covaccine = 1,
        Covishield,
        sputnic

    }
}
