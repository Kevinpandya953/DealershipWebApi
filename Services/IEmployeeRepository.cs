using DealershipWebApi.Models;

namespace DealershipWebApi.Services
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Task<bool> Delete(Guid id);
        Task<bool> Delete(int id);
    }
}
