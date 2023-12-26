using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRAdministrationAPI;
using SchoolHRAdministration.Models;

namespace SchoolHRAdministration.Services
{
    public class ManagerService
    {
        public void SeedData(List<IEmployee> employees)
        {
            IEmployee teacher1 = new Teacher()
            {
                Id = 1,
                FirstName = "Andre",
                LastName = "Great",
                Salary = 50000
            };
            employees.Add(teacher1);

            IEmployee teacher2 = new Teacher()
            {
                Id = 2,
                FirstName = "John",
                LastName = "Great",
                Salary = 50000
            };
            employees.Add(teacher2);

            IEmployee headDepartment = new HeadOfDepartment()
            {
                Id = 3,
                FirstName = "Bran",
                LastName = "Great",
                Salary = 100000
            };
            employees.Add(headDepartment);

            IEmployee deputyHeadMaster = new DeputyHeadMaster()
            {
                Id = 4,
                FirstName = "Rohn",
                LastName = "Great",
                Salary = 80000
            };
            employees.Add(deputyHeadMaster);

            IEmployee headMaster = new HeadMaster()
            {
                Id = 5,
                FirstName = "Helga",
                LastName = "Great",
                Salary = 75000
            };
            employees.Add(headMaster);
        }
    }
}
