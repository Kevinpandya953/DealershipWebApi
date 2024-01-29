using DealershipWebApi.Models;
using Microsoft.EntityFrameworkCore;
using DealershipWebApi.Services;
using DealershipWebApi.Data;

namespace DealershipWebApi.Services
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(DBContext context, ILogger logger) : base(context, logger)
        {
        }

        public override async Task<IEnumerable<Employee>> All()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All function error", typeof(EmployeeRepository));
                return new List<Employee>();
            }
        }
        public override async Task<bool> Upsert(Employee entity)
        {
            try
            {
                var existingUser = await dbSet.Where(x => x.EmployeeId == entity.EmployeeId)
                                                    .FirstOrDefaultAsync();

                if (existingUser == null)
                    return await Add(entity);
                existingUser.EmployeeId = entity.EmployeeId;
                existingUser.FirstName = entity.FirstName;
                existingUser.LastName = entity.LastName;
                existingUser.AddressId = entity.AddressId;
                existingUser.DateJoined = entity.DateJoined;
                existingUser.DesignationId = entity.DesignationId;
                existingUser.Salary = entity.Salary;
                existingUser.Email = entity.Email;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Upsert function error", typeof(EmployeeRepository));
                return false;
            }
        }

        public  async Task<bool> Delete(int id)
        {
            try
            {
                var exist = await dbSet.Where(x => x.EmployeeId == id)
                                        .FirstOrDefaultAsync();

                if (exist == null) return false;

                dbSet.Remove(exist);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Delete function error", typeof(EmployeeRepository));
                return false;
            }
        }

        public Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
