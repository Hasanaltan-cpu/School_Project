using Microsoft.EntityFrameworkCore;
using SMS_Data_Layer.ProjectContext;
using SMS_Data_Layer.Repositories.Interfaces.Base;
using SMS_Entity_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SMS_Data_Layer.Repositories.Concrete.Base
{
 
        public class KernelRepository<T> : IKernelRepository<T> where T : class, IBaseEntity
        {

            private readonly ApplicationDbContext _context;
            protected DbSet<T> _table;

            public KernelRepository(ApplicationDbContext applicationDbContext)
            {
                _context = applicationDbContext;
                _table = _context.Set<T>();
            }

            public async Task Add(T entity)
            {
                await _table.AddAsync(entity);
                await _context.SaveChangesAsync();
            }

            public async Task<bool> Any(Expression<Func<T, bool>> expression) => await _table.AnyAsync(expression);

            public async Task Delete(T entity)
            {
                _table.Remove(entity);
                await _context.SaveChangesAsync();
            }

            public async Task<T> FirstOrDefault(Expression<Func<T, bool>> expression) => await _table.Where(expression).FirstOrDefaultAsync();

            public async Task<List<T>> Get(Expression<Func<T, bool>> expression) => await _table.Where(expression).ToListAsync();

            public async Task<List<T>> GetAll() => await _table.ToListAsync();

            public async Task<T> GetById(int id) => await _table.FindAsync(id);

            public async Task Update(T entity)
            {
                _context.Entry<T>(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }
}
