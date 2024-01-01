using HRAdministrationAPI;
using SchoolHRAdministration.Services;

decimal totalSalaries = 0;
List<IEmployee> employees = new List<IEmployee>();

ManagerService manager = new ManagerService();
manager.SeedData(employees);

#region BaseWay
foreach (IEmployee employee in employees)
{
    totalSalaries += employee.Salary;
}
Console.WriteLine($"Total Annul Salaries (including bonus): {totalSalaries}");
#endregion

//LINQ way
Console.WriteLine($"Total Annul Salaries (including bonus): {employees.Sum(e => e.Salary)}");

Console.ReadKey();
 