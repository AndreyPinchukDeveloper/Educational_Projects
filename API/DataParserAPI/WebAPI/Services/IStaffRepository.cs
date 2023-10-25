using WebAPI.ClassesAsDatabase.Entities;

namespace WebAPI.Services
{
    public interface IStaffRepository
    {
        IEnumerable<Employee> GetAllEmployees();
        Employee LoadAndre();
    }
}