using WebAPI.ClassesAsDatabase.Entities;

namespace WebAPI.ClassesAsDatabase
{
    public class StaffDatabase
    {
        public static List<Employee> GetAllEmployees()
        {
            return new List<Employee>
            {
                new Employee { Id = 1, Name = "Andre", Salary = 25},
                new Employee { Id = 1, Name = "Brondre", Salary = 50},
                new Employee { Id = 1, Name = "Landre", Salary = 75},
            };
        }
    }
}
