using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Presistance.Contracts
{
    public interface IGenricRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetAsync(int id);
        Task SaveAsync(T entity);
        Task DeleteAsync(int id);
        Task UpdateAsync(T entity);
        Task SaveChangesAsync();
        Task<bool> Exist (int id);  
    }
}
