using Microsoft.EntityFrameworkCore;
using SimpleAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleAPI.Services
{
    public class Repository//<T> : IRepository<T> where T : class 
    {
        ////private readonly FinalDB_IPContext context;
       // private readonly DbSet<T> entity;

        //public Repository()
        //{
        //    this.context = context;
        //    entity = context.Set<T>();

        //}

        //public async Task<IEnumerable<T>> GetAllAsync() => await entity.ToListAsync();

        //public async Task<T> GetByIdAsync(object id) => await entity.FindAsync(id);

        //public async Task SaveAsync() => await context.SaveChangesAsync();

        //protected DbSet<T> GetDbSet() => entity;

        //public async Task InsertAsync(T obj)
        //{
        //    await entity.AddAsync(obj);
        //    await SaveAsync();
        //}

        //public async Task UpdateAsync(T obj)
        //{
        //    entity.Attach(obj);
        //    context.Entry(obj).State = EntityState.Modified;
        //    await SaveAsync();
        //}

        //public async Task DeleteAsync(object id)
        //{
        //    T existing = await entity.FindAsync(id);
        //    entity.Remove(existing);
        //    await SaveAsync();
        //}
    }
}
