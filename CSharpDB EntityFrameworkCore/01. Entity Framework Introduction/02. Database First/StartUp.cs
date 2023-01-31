using Microsoft.VisualBasic;
using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            using SoftUniContext context = new SoftUniContext();

            string result = RemoveTown(context);
            Console.WriteLine(result);

        }
        //03. Employees Full Information
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employeeInformations =
                 context
                 .Employees
                 .Select(e => new
                 {
                     e.FirstName,
                     e.LastName,
                     e.MiddleName,
                     e.JobTitle,
                     e.Salary
                 })
                 .ToArray();
            foreach (var e in employeeInformations)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }
        //04. Employees with Salary Over 50 000
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var employeesWithSalaryOver =
                context
                .Employees
                .Where(e => e.Salary > 50000)
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ToArray();

            foreach (var e in employeesWithSalaryOver)
            {
                sb.AppendLine($"{e.FirstName} - {e.Salary:F2}");
            }
            return sb.ToString().TrimEnd();
        }
        //05. Employees from Research and Development
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var employeesFromDepartment =
                context
                .Employees
                .Where(e => e.Department.Name == "Research and Development")
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    DepartmentName = e.Department.Name,
                    e.Salary
                })
                .ToArray();

            foreach (var e in employeesFromDepartment)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} from {e.DepartmentName} - ${e.Salary:F2}");
            }
            return sb.ToString().TrimEnd();
        }
        //06. Adding a New Address and Updating Employee
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            Address newAdressToAdd = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };
            context.Addresses.Add(newAdressToAdd);

            Employee employeeToAddAdress = context.Employees.First(e => e.LastName == "Nakov");
            employeeToAddAdress.Address = newAdressToAdd;
            context.SaveChanges();
            var employeesAdressesToPrint =
                context
                .Employees
                .OrderByDescending(ea => ea.AddressId)
                .Take(10)
                .Select(e => new
                {
                    e.Address.AddressText
                })
                .ToArray();

            foreach (var employee in employeesAdressesToPrint)
            {
                sb.AppendLine(employee.AddressText);
            }
            return sb.ToString().TrimEnd();
        }
        //07. Employees and Projects
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var projectsStartInRange = context
                .Employees
                .Where(e => e.EmployeesProjects
                        .Any(p => p.Project.StartDate.Year >= 2001
                        && p.Project.StartDate.Year <= 2003))
                .Take(10)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    ManigerFirstName = e.Manager.FirstName,
                    ManigerLastName = e.Manager.LastName,
                    AllProjects = e.EmployeesProjects
                                   .Select(ep => new
                                   {
                                       ProjectName = ep.Project.Name,
                                       StartDate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt"),
                                       EndDate = ep.Project.EndDate.HasValue ? ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt") : "not finished"
                                   })
                                   .ToArray()
                })
                .ToArray();
            foreach (var e in projectsStartInRange)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.ManigerFirstName} {e.ManigerLastName}");
                foreach (var p in e.AllProjects)
                {
                    sb.AppendLine($"--{p.ProjectName} - {p.StartDate} - {p.EndDate}");
                }
            }

            return sb.ToString().TrimEnd();
        }
        //08. Addresses by Town
        public static string GetAddressesByTown(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
           
            var addressesByNumberOfEmployee = context
                .Addresses
                .OrderByDescending(e => e.Employees.Count())
                .ThenBy(t=>t.Town.Name)
                .Select(a => new 
                { 
                    a.AddressText,
                    NumberOfEmployeeOnAdress = a.Employees.Count,
                    TownName = a.Town.Name
                })
                .ToArray();
            foreach (var a in addressesByNumberOfEmployee)
            {
                sb.AppendLine($"{a.AddressText}, {a.TownName} - {a.NumberOfEmployeeOnAdress} employees");
            }
            return sb.ToString().TrimEnd();
        }
        //09. Employee 147
        public static string GetEmployee147(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            int numberOfEmployee = 147;
            Employee emplyee = context.Employees.First(e => e.EmployeeId == numberOfEmployee);
          
            sb.AppendLine($"{emplyee.FirstName} {emplyee.LastName} - {emplyee.JobTitle}");
            var allProjectsOfEmployee = emplyee.EmployeesProjects.Select(p => p.Project);
            foreach (var p in allProjectsOfEmployee.OrderBy(p=>p.Name))
            {
                sb.AppendLine(p.Name);
            }
          
            return sb.ToString().TrimEnd();
        }
        //10. Departments with More Than 5 Employees
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var allDepartmentsWithMoreThenFiveEmployees = context
                .Departments
                .Where(e => e.Employees.Count > 5)
                .OrderBy(e => e.Employees.Count)
                .ThenByDescending(d=>d.Name)
                .Select(d=> new 
                {
                    d.Name,
                    DepartmentManiger = $"{d.Manager.FirstName} {d.Manager.LastName}",
                    AllDepartmentEmployees = d.Employees
                })
                .ToArray();

            foreach (var d in allDepartmentsWithMoreThenFiveEmployees)
            {
                sb.AppendLine($"{d.Name} - {d.DepartmentManiger}");
                foreach (var e in d.AllDepartmentEmployees.OrderBy(e=>e.FirstName).ThenBy(e=>e.LastName))
                {
                    sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");
                }
            }
            return sb.ToString().TrimEnd();
        }
        //11. Find Latest 10 Projects
        public static string GetLatestProjects(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var latestProjects = context
                .Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .OrderBy(p=>p.Name)
                .ToArray();

            foreach (var p in latestProjects)
            {
                sb.AppendLine(p.Name);
                sb.AppendLine(p.Description);
                sb.AppendLine(p.StartDate.ToString("M/d/yyyy h:mm:ss tt"));
            }

            return sb.ToString().TrimEnd();
        }
        //12.  Increase Salaries
        public static string IncreaseSalaries(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            string[] increasingDepartmentsSalary = { "Engineering", "Tool Design", "Marketing", "Information Services" };
            decimal increasingSalaryValue = 12m / 100;


            var employees = context.Employees 
              .Where(e => increasingDepartmentsSalary.Contains(e.Department.Name))
              .OrderBy(e => e.FirstName).ThenBy(e => e.LastName)
              .ToList();
            foreach (var e in employees)
            {
                e.Salary += e.Salary * increasingSalaryValue;
                sb.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:f2})");
            }
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }
        //13. Find Employees by First Name Starting With Sa
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employeesWithSaInName = context.Employees
                .Where(e => e.FirstName.StartsWith("Sa"))
                .Select(e => new
                {                    
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary
                })
                .ToArray();
            foreach (var e in employeesWithSaInName.OrderBy(e=>e.FirstName).ThenBy(e=>e.LastName))
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:F2})");
            }

            return sb.ToString().TrimEnd();
        }
        //14. Delete Project by Id
        public static string DeleteProjectById(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            int numberOfProjectToDelete = 2;
            Project projectToDelete = context.Projects.First(p => p.ProjectId == numberOfProjectToDelete);

            if (projectToDelete == null)
            {
                throw new ArgumentNullException($"There is not project with Id {numberOfProjectToDelete}");
            }
            var employeesProjectsToDelete = context.EmployeesProjects.Where(p => p.ProjectId == projectToDelete.ProjectId).ToArray();

            context.RemoveRange(employeesProjectsToDelete);
            context.Remove(projectToDelete);

            context.SaveChanges();

            string[] projectNames = context.Projects.Select(e => e.Name ).ToArray();
            foreach (string pn in projectNames)
            {
                sb.AppendLine(pn);
            }
            return sb.ToString().TrimEnd();
        }
        //15. Remove Town
        public static string RemoveTown(SoftUniContext context)
        {
            string townNameToDelete = "Seattle";
            Town townToDelete = context.Towns.First(t => t.Name == townNameToDelete);

            if (townToDelete == null)
            {
                throw new ArgumentNullException($"Town with name \"{townNameToDelete}\" is not in collection!");
            }

            Address[] addressesToDelete = context.Addresses.Where(a => a.Town.TownId == townToDelete.TownId).ToArray();
            int numberOfDeletedAddresses = addressesToDelete.Length;

            Employee[] employeesFromDeletedAddresses = context.Employees.Where(e => e.Address.Town.TownId == townToDelete.TownId).ToArray();

            foreach (var e in employeesFromDeletedAddresses)
            {
                e.Address.AddressText = null;
            }
            context.RemoveRange(addressesToDelete);
            context.Remove(townToDelete);
            context.SaveChanges();

            return $"{numberOfDeletedAddresses} addresses in {townNameToDelete} were deleted";
        }
    }
}
