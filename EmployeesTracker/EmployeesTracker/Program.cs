using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeesTracker
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Department { get; set; }
        public decimal Salary { get; set; }
        public int Grade { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee { Id = 1, Name = "Ahmed", Age = 25, Department = "IT", Salary = 10000, Grade = 90 },
                new Employee { Id = 2, Name = "Sara", Age = 30, Department = "HR", Salary = 8000, Grade = 75 },
                new Employee { Id = 3, Name = "Ali", Age = 28, Department = "IT", Salary = 12000, Grade = 85 },
                new Employee { Id = 4, Name = "Mona", Age = 35, Department = "Finance", Salary = 15000, Grade = 70 },
                new Employee { Id = 5, Name = "Omar", Age = 24, Department = "HR", Salary = 9000, Grade = 95 }
            };

            // 1. Get a list of all employee salaries multiplied by 1.1 (10% raise)
            var newSalaries = employees.Select(e => e.Salary * 1.1m);

            Console.WriteLine("Salaries After 10% Raise:");
            foreach (var salary in newSalaries)
            {
                Console.WriteLine(salary);
            }

            Console.WriteLine();

            // 2. Get all employees ordered by Age ascending
            var orderByAge = employees.OrderBy(e => e.Age);

            Console.WriteLine("Employees Ordered By Age:");
            foreach (var employee in orderByAge)
            {
                Console.WriteLine($"{employee.Name} - {employee.Age}");
            }

            Console.WriteLine();

            // 3. Get all employees ordered by Salary descending
            var orderBySalary = employees.OrderByDescending(e => e.Salary);

            Console.WriteLine("Employees Ordered By Salary:");
            foreach (var employee in orderBySalary)
            {
                Console.WriteLine($"{employee.Name} - {employee.Salary}");
            }

            Console.WriteLine();

            // 4. Group employees by Department and count employees
            var departmentGroups = employees.GroupBy(e => e.Department);

            Console.WriteLine("Employees By Department:");
            foreach (var group in departmentGroups)
            {
                Console.WriteLine($"{group.Key} : {group.Count()} Employees");
            }

            Console.WriteLine();

            // 5. Group employees by Grade (>=80 or <80)
            var gradeGroups = employees.GroupBy(e => e.Grade >= 80 ? "Grade >= 80" : "Grade < 80");

            Console.WriteLine("Employees By Grade:");
            foreach (var group in gradeGroups)
            {
                Console.WriteLine(group.Key);

                foreach (var employee in group)
                {
                    Console.WriteLine(employee.Name);
                }

                Console.WriteLine();
            }
        }
    }
}