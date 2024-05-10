using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Presistance.Repositories
{
    public class GenericRepositories<T> : IGenricRepository<T> where T : class
    {
        private readonly ApplicationDBContext _context;

        public GenericRepositories(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task DeleteAsync(int id)
        {
            _context.Set<T>().Remove(await GetAsync(id));
           await SaveChangesAsync();
        }

        public async Task<bool> Exist(int id)
        {
           var entry = await GetAsync(id);
            return entry != null;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        => await _context.Set<T>().AsNoTracking().ToListAsync();

        public async Task<T> GetAsync(int id)
            => await _context.Set<T>().FindAsync(id);

        public async Task SaveAsync(T entity)
        {
            await _context.AddAsync(entity);
            await SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        =>await _context.SaveChangesAsync();

        public async Task UpdateAsync(T entity)
        {
           _context.Entry(entity).State = EntityState.Modified;
            await SaveChangesAsync();
        }
    }
}
