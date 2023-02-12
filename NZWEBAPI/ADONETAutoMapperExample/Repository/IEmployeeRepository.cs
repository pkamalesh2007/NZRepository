using ADONETAutoMapperExample.Models.Domain;

namespace ADONETAutoMapperExample.Repository
{
    public interface IEmployeeRepository
    {
        public List<Employee> GetEmployees();
    }
}
