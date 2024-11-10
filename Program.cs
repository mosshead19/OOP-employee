using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_employee
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RegularEmployee regEmployee = new RegularEmployee("Alice",1);
            HourlyEmployee hourlyEmployee = new HourlyEmployee("Bob", 2, 160, 20.5f);
            CommissionEmployee commissionEmployee = new CommissionEmployee("Charlie", 3, 50000, 0.10f);

            //instance of hourlyemployee
            //of commision employee


            regEmployee.CalculateSalary();
            hourlyEmployee.CalculateSalary();
            commissionEmployee.CalculateSalary();
            //xEmployee.Caculate salary();
            //...


            Console.WriteLine("Employee Salaries(before bonus): ");
            Console.WriteLine($"Name: {regEmployee.name}, ID: {regEmployee.id}, Salary: {regEmployee.salary}");
            Console.WriteLine($"Name: {hourlyEmployee.name}, ID: {hourlyEmployee.id}, Salary: {hourlyEmployee.salary}");
            Console.WriteLine($"Name: {commissionEmployee.name}, ID: {commissionEmployee.id}, Salary: {commissionEmployee.salary}");
            //follow lang formatng prev line 


            //USE THE APPLY BONUS for each emplloyee here HERE
            regEmployee.applyBonus(4000.0f, 500f);
            hourlyEmployee.applyBonus(4000.0f, 500f);
            commissionEmployee.applyBonus(4000.0f, 500f);



            //Calculate ssalary again here 

            //employee 2...

           Console.WriteLine();

            Console.WriteLine("Employee Salaries(after bonus): ");
            Console.WriteLine($"Name: {regEmployee.name}, ID: {regEmployee.id}, Salary: {regEmployee.salary}");
            Console.WriteLine($"Name: {hourlyEmployee.name}, ID: {hourlyEmployee.id}, Salary: {hourlyEmployee.salary}");
            Console.WriteLine($"Name: {commissionEmployee.name}, ID: {commissionEmployee.id}, Salary: {commissionEmployee.salary}");

            //for payroll ako na lng? or if you want
            Console.WriteLine();
            Console.WriteLine($"Total Payroll: {regEmployee.salary+hourlyEmployee.salary+commissionEmployee.salary}");

            Console.ReadKey();

        }
    }

    public class Employee
    {
        
        public string name { get; set; }
        public int id { get; set; }
        public float salary { get; set; }

        public Employee(string name, int id) { 
        
            this.name = name;
            this.id = id;
            salary = 0;
        
        
        }

        public void applyBonus(float threshold, float bonus)
        {
            if (salary > threshold)
            {

                salary += bonus;

            }

        }

        

    }

    public class RegularEmployee : Employee
    {
        public const float fixedSalary = 3000;
        public RegularEmployee(string name, int id) : base(name,id)
        {
        
        
        }

        public void CalculateSalary()
        {
            salary = fixedSalary;
        }
    }


    public class HourlyEmployee: Employee
    {
        public float hoursWorked { get; set; }
        public float hourlyRate {  get; set; }
        public HourlyEmployee(string name, int id, float hoursWorked,float hourlyRate): base(name, id)
        {

            this.hoursWorked = hoursWorked;
            this.hourlyRate = hourlyRate;
        }

        public void CalculateSalary()
        {
            salary = hoursWorked * hourlyRate;
        }
    }

    //commission employee
    public class CommissionEmployee : Employee
    {
        public float SalesAmount { get; set; }
        public float CommissionRate { get; set; }

        public CommissionEmployee(string name, int id, float salesAmount,float commissionRate) : base(name, id)
        {
            
            this.SalesAmount = salesAmount;
            this.CommissionRate = commissionRate;

        }

        public void CalculateSalary()
        {
            salary = SalesAmount * CommissionRate;
        }
    }
}
