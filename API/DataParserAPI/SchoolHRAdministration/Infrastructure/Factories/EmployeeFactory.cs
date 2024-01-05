using HRAdministrationAPI;
using HRAdministrationAPI.Factories;
using SchoolHRAdministration.Enums;
using SchoolHRAdministration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolHRAdministration.Infrastructure.Factories
{
    public static class EmployeeFactory
    {
        public static IEmployee GetEmployeeInstance(EmployeeType employeeType, int id, string firstName, string lastName, decimal salary)
        {
            IEmployee employee = null;
            switch (employeeType) 
            {
                case EmployeeType.Teacher:
                    employee = FactoryPattern<IEmployee, Teacher>.GetInstance();
                    break;
                case EmployeeType.HeadOfDepartment:
                    FactoryPattern<IEmployee, HeadOfDepartment>.GetInstance();
                    break;
                case EmployeeType.DeputyHeadMaster:
                    FactoryPattern<IEmployee, DeputyHeadMaster>.GetInstance();
                    break;
                case EmployeeType.HeadMaster:
                    FactoryPattern<IEmployee, HeadMaster>.GetInstance();
                    break;
                default:
                    break;
            }
            if (employee != null)
            {
                employee.Id = id;
                employee.FirstName = firstName;
                employee.LastName = lastName;
                employee.Salary = salary;
            }
            else
            {
                throw new ArgumentException("employee is null");
            }
            return employee;
        }
    }
}
