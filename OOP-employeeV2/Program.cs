using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_employeeV2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RegularEmployee regEmployee = new RegularEmployee("Alice", 1);
            HourlyEmployee hourlyEmployee = new HourlyEmployee("Bob", 2, 160, 20.5f);
            CommissionEmployee commissionEmployee = new CommissionEmployee("Charlie", 3, 50000, 0.10f);

            regEmployee.CalculateSalary();
            hourlyEmployee.CalculateSalary();
            commissionEmployee.CalculateSalary();

            Console.WriteLine("Employee Salaries (before bonus):");
            Console.WriteLine($"Name: {regEmployee.Name}, ID: {regEmployee.Id}, Salary: {regEmployee.Salary}");
            Console.WriteLine($"Name: {hourlyEmployee.Name}, ID: {hourlyEmployee.Id}, Salary: {hourlyEmployee.Salary}");
            Console.WriteLine($"Name: {commissionEmployee.Name}, ID: {commissionEmployee.Id}, Salary: {commissionEmployee.Salary}");

            regEmployee.ApplyBonus(4000.0f, 500f);
            hourlyEmployee.ApplyBonus(4000.0f, 500f);
            commissionEmployee.ApplyBonus(4000.0f, 1000f);

            Console.WriteLine("\nEmployee Salaries (after bonus):");
            Console.WriteLine($"Name: {regEmployee.Name}, ID: {regEmployee.Id}, Salary: {regEmployee.Salary}");
            Console.WriteLine($"Name: {hourlyEmployee.Name}, ID: {hourlyEmployee.Id}, Salary: {hourlyEmployee.Salary}");
            Console.WriteLine($"Name: {commissionEmployee.Name}, ID: {commissionEmployee.Id}, Salary: {commissionEmployee.Salary}");

            Console.WriteLine($"\nTotal Payroll: {regEmployee.Salary + hourlyEmployee.Salary + commissionEmployee.Salary}");

            Console.ReadKey();
        }
    }

    public class Employee
    {
        private string _name;
        private int _id;
        private float _salary;

        public string Name
        {
            get => _name;
            private set => _name = value;
        }

        public int Id
        {
            get => _id;
            private set => _id = value;
        }

        public float Salary
        {
            get => _salary;
            protected set => _salary = value >= 0 ? value : throw new ArgumentException("Salary cannot be negative.");
        }

        public Employee(string name, int id)
        {
            Name = name;
            Id = id;
            Salary = 0;
        }

        public void ApplyBonus(float threshold, float bonus)
        {
            if (Salary > threshold)
            {
                Salary += bonus;
            }
        }
    }

    public class RegularEmployee : Employee
    {
        private const float FixedSalary = 3000;

        public RegularEmployee(string name, int id) : base(name, id) { }

        public void CalculateSalary()
        {
            Salary = FixedSalary;
        }
    }

    public class HourlyEmployee : Employee
    {
        
        private float _hoursWorked;
        private float _hourlyRate;

        public float HoursWorked
        {
            get => _hoursWorked;
            private set => _hoursWorked = value >= 0 ? value : throw new ArgumentException("Hours worked cannot be negative.");
        }

        public float HourlyRate
        {
            get => _hourlyRate;
            private set => _hourlyRate = value >= 0 ? value : throw new ArgumentException("Hourly rate cannot be negative.");
        }

        public HourlyEmployee(string name, int id, float hoursWorked, float hourlyRate) : base(name, id)
        {
            HoursWorked = hoursWorked;
            HourlyRate = hourlyRate;
        }

        public void CalculateSalary()
        {
            Salary = HoursWorked * HourlyRate;
        }
    }

    public class CommissionEmployee : Employee
    {
        
        private float _salesAmount;
        private float _commissionRate;

        public float SalesAmount
        {
            get => _salesAmount;
            private set => _salesAmount = value >= 0 ? value : throw new ArgumentException("Sales amount cannot be negative.");
        }

        public float CommissionRate
        {
            get => _commissionRate;
            private set => _commissionRate = (value >= 0) ? value : throw new ArgumentException("Commission rate must not be negative.");
        }

        public CommissionEmployee(string name, int id, float salesAmount, float commissionRate) : base(name, id)
        {
            SalesAmount = salesAmount;
            CommissionRate = commissionRate;
        }

        public void CalculateSalary()
        {
            Salary = SalesAmount * CommissionRate;
        }
    }
}
