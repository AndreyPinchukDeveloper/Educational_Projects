using WebAPI.ClassesAsDatabase;
using WebAPI.ClassesAsDatabase.Entities;

namespace WebAPI.Services
{
    public class StaffRepository : IStaffRepository
    {
        public IEnumerable<Employee> GetAllEmployees()
        {
            return StaffDatabase.GetAllEmployees();
        }

        public Employee LoadAndre()
        {
            return StaffDatabase.GetAllEmployees().First(e => e.Name == "Andre");
        }
    }
}
