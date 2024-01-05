using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRAdministrationAPI;
using SchoolHRAdministration.Enums;
using SchoolHRAdministration.Infrastructure.Factories;
using SchoolHRAdministration.Models;

namespace SchoolHRAdministration.Services
{
    public class ManagerService
    {
        public void SeedData(List<IEmployee> employees)
        {
            IEmployee teacher1 = EmployeeFactory.GetEmployeeInstance(EmployeeType.Teacher, 1, "John", "Better", 40000);
            employees.Add(teacher1);

            IEmployee teacher2 = EmployeeFactory.GetEmployeeInstance(EmployeeType.Teacher, 1, "Sara", "Snow", 40000);
            employees.Add(teacher2);

            IEmployee headDepartment = EmployeeFactory.GetEmployeeInstance(EmployeeType.HeadOfDepartment, 1, "Andre", "Snow", 60000);
            employees.Add(headDepartment);

            IEmployee deputyHeadMaster = EmployeeFactory.GetEmployeeInstance(EmployeeType.DeputyHeadMaster, 1, "Bill", "Terner", 70000);
            employees.Add(deputyHeadMaster);

            IEmployee headMaster = EmployeeFactory.GetEmployeeInstance(EmployeeType.HeadMaster, 1, "Edvard", "Better", 100000);
            employees.Add(headMaster);
        }
    }
}
