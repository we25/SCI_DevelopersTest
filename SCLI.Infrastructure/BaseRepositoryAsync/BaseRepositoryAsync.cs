using Microsoft.EntityFrameworkCore;
using SCLI.Application.Contacts.Presisence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCLI.Infrastructure.BaseRepositoryAsync
{
    public class BaseRepositoryAsync<T> : IBaseRepositoryAsync<T> where T : class
    {
        SCLIAppContext appContext;
        public BaseRepositoryAsync(SCLIAppContext appContext)
        {

            this.appContext = appContext;

        }
        public async Task<List<T>> GetAllAsync()
        {
            var data = await appContext.Set<T>().Select(a => a).ToListAsync();
            return data;
        }
        public async Task<T> AddAsync(T item)
        {
            await appContext.Set<T>().AddAsync(item);
            await appContext.SaveChangesAsync();
            return item;
        }
        public async Task<T> UpdateAsync(T item)
        {
            appContext.Entry(item).State = EntityState.Modified;
            await appContext.SaveChangesAsync();
            return item;
        }
        public async Task<T> RemoveAsync(T item)
        {
            appContext.Set<T>().Remove(item);
            await appContext.SaveChangesAsync();
            return item;
        }
    }
}
