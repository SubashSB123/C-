using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vaccine
{
    public class Program
    {
        static List<Benificery> ben = new List<Benificery>();


        static void Main(string[] args)
        {
            int option;
            SetInputs();

            do
            {
                Console.WriteLine("\nEnter your Option:\nBeneficiary Registration-->1\n2.Vacccination-->2\n3.Exit-->3");
                option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        BenificiaryRegistation();
                        break;
                    case 2:
                        VaccinationProcess();
                        break;
                    case 3:
                        Console.WriteLine("Thank You");
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            } while (option != 3);
        }

        




           public static void SetInputs()
           { 
        
            Benificery b1 = new Benificery("anto", 9876543, "clg", 20, 1);
            Benificery b2 = new Benificery("poto", 9876543, "ams", 22, 1);
            ben.Add(b1);
            ben.Add(b1);
            b1.Vaccinatee(1, DateTime.Now);
            b2.Vaccinatee(1, DateTime.Now);

        }
        //Get the input from Benificiary
       public static void BenificiaryRegistation()
        {
            Console.WriteLine("Enter your Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter your your Age:");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Choose your Gender:\n1.Male\n2.Female\n3.Transgender");
            int gender = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter your Phone number:");
            long mobile = long.Parse(Console.ReadLine());
            Console.WriteLine("Enter your Address:");
            string address = Console.ReadLine();
            Benificery beneficiary = new Benificery(name, mobile, address, age, gender);
            Console.WriteLine($"Hi {beneficiary.Name} your Registration ID is {beneficiary.ID}");
            ben.Add(beneficiary);
        }
        //Vaccination Process
       public static   void VaccinationProcess()
        {

            bool flag = true;
            do
            {
                Show();

                Console.WriteLine("Enter your registration ID:");
                int regisId = int.Parse(Console.ReadLine());
                Benificery currentBenificiary = null;
                foreach (Benificery beneficiary in ben)
                {
                    if (regisId == beneficiary.ID)
                    {
                        currentBenificiary = beneficiary;
                    }
                }

                if (currentBenificiary != null)
                {
                    int beneficiaryOption = 1;
                    do
                    {

                        Console.WriteLine("\nSpecify your options:\nTake Vaccination-->1\nVaccination History-->2\nNext Dose Date-->3\nGo to Menu-->4");
                        beneficiaryOption = int.Parse(Console.ReadLine());
                        switch (beneficiaryOption)
                        {
                            case 1:
                                TakeVaccine(currentBenificiary);
                                break;
                            case 2:
                                VaccinateHistory(currentBenificiary);
                                break;
                            case 3:
                                Console.WriteLine(currentBenificiary.DueDate());
                                break;
                            case 4:
                                flag = false;
                                break;
                            default:
                                Console.WriteLine("invalid input");
                                break;



                        }
                    } while (beneficiaryOption != 4);
                }
                else
                {
                    Console.WriteLine("Register ID Not Found");
                }
            } while (flag);
        }
       public static void TakeVaccine(Benificery currentBeneficiary)
        {

            do
            {
                
                Console.WriteLine("Choose your Vaccine:\nCovaxin-->1\nCovishield-->2\nSputnic-->3");
                int vaccineType = int.Parse(Console.ReadLine());
                if (currentBeneficiary.VaccDetails.Count == 0)
                {
                    Console.WriteLine("Enter Date in dd/MM/yyyy");
                    string enteredDate = Console.ReadLine();
                    string[] splitDate = enteredDate.Split('/');
                    DateTime date = new DateTime(int.Parse(splitDate[2]), int.Parse(splitDate[1]), int.Parse(splitDate[0]));
                    Console.WriteLine($"You are Vaccinated {currentBeneficiary.Vaccinatee(vaccineType, date)}");
                    break;
                }
                else if (currentBeneficiary.VaccDetails.Count == 1)
                {
                    if ((VaccinationType)vaccineType == currentBeneficiary.VaccDetails[0].Vaccin)
                    {
                        Console.WriteLine("Enter Date in dd/MM/yyyy");
                        string enteredDate = Console.ReadLine();
                        string[] splitDate = enteredDate.Split('/');
                        DateTime date = new DateTime(int.Parse(splitDate[2]), int.Parse(splitDate[1]), int.Parse(splitDate[0]));
                        Console.WriteLine(currentBeneficiary.Vaccinatee(vaccineType, date));
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"You have not selected same vaccine. Your First vaccine is {currentBeneficiary.VaccDetails[0].Vaccin}");
                    }
                }

            } while (true);
        }
        public static void VaccinateHistory(Benificery currentBeneficiary)
        {
           
            foreach (Vaccine detail in currentBeneficiary.VaccDetails)
            {
                Console.WriteLine($"Vaccine: {detail.Vaccin} | Dosage:{detail.Dosage} dose | Date:{detail.VaccinateDate.ToString("dd/MM/yyyy")}");
            }


        }
        //sow bwnificiery list
        public static  void Show()
        {
            foreach (Benificery beneficiary in ben)
            {
                Console.WriteLine($"REGISTER ID: {beneficiary.ID} | NAME:{beneficiary.Name}");
            }
        }





    }
}
