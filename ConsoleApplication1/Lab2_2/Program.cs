using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication1
{
    public class Program
    {
        private static readonly List<Department> Departments = new List<Department>();
        private static readonly List<Employee> Employees = new List<Employee>();
        private static int _departmentIdCounter = 1;
        private static int _employeeIdCounter = 1;

        public static void Main()
        {
            var exit = false;
            while (!exit)
            {
                Console.WriteLine("Меню:");
                Console.WriteLine("1. Додати відділ");
                Console.WriteLine("2. Додати співробітника");
                Console.WriteLine("3. Вивести список відділів та співробітників");
                Console.WriteLine("4. Вийти");

                Console.Write("Введіть номер операції: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddDepartment();
                        break;
                    case "2":
                        AddEmployee();
                        break;
                    case "3":
                        DisplayDepartmentsAndEmployees();
                        break;
                    case "4":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Невірний ввід. Спробуйте ще раз.");
                        break;
                }

                Console.WriteLine();
            }
        }

        private static void AddDepartment()
        {
            Console.Write("Введіть назву відділу: ");
            string name = Console.ReadLine();
            Departments.Add(new Department { DepartmentId = _departmentIdCounter++, Name = name });
            Console.WriteLine("Відділ успішно додано.");
        }

        private static void AddEmployee()
        {
            Console.Write("Введіть ім'я співробітника: ");
            string name = Console.ReadLine();
            Console.WriteLine("Доступні відділи:");
            foreach (var department in Departments)
            {
                Console.WriteLine($"{department.DepartmentId}. {department.Name}");
            }
            Console.Write("Виберіть ID відділу для співробітника: ");
            if (int.TryParse(Console.ReadLine(), out int departmentId))
            {
                if (Departments.Any(d => d.DepartmentId == departmentId))
                {
                    Employees.Add(new Employee { EmployeeId = _employeeIdCounter++, Name = name, DepartmentId = departmentId });
                    Console.WriteLine("Співробітника успішно додано.");
                }
                else
                {
                    Console.WriteLine("Відділ з таким ID не існує.");
                }
            }
            else
            {
                Console.WriteLine("Невірний ввід для ID відділу.");
            }
        }

        private static void DisplayDepartmentsAndEmployees()
        {
            Console.WriteLine("Список відділів та співробітників:");
            foreach (var department in Departments)
            {
                Console.WriteLine($"Відділ: {department.Name}");
                var deptEmployees = Employees.Where(e => e.DepartmentId == department.DepartmentId);
                foreach (var employee in deptEmployees)
                {
                    Console.WriteLine($"- Співробітник: {employee.Name}");
                }
            }
        }
    }
}