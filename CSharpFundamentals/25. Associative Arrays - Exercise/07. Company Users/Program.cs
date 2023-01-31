using System;
using System.Collections.Generic;

namespace _07._Company_Users
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var companyInfo = new Dictionary<string, List<string>>();
            string cmd = "";
            while ((cmd = Console.ReadLine()) != "End")
            {
                string[] tokens = cmd.Split(" -> ", StringSplitOptions.RemoveEmptyEntries); 
                string company = tokens[0];
                string employeeId = tokens[1];
                if (!companyInfo.ContainsKey(company))
                {
                    companyInfo[company] = new List<string>();

                }
                if (companyInfo[company].Contains(employeeId))
                {
                    continue;
                }
                companyInfo[company].Add(employeeId);

            }
            foreach (var company in companyInfo)
            {
                Console.WriteLine($"{company.Key}");
                foreach (var employee in company.Value)
                {
                    Console.WriteLine($"-- {employee}");
                }
            }
        }
    }
}
