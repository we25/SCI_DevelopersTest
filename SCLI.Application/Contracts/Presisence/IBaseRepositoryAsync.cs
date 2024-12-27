using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCLI.Application.Contacts.Presisence
{
    public interface IBaseRepositoryAsync<T>
    {
        Task<List<T>> GetAllAsync();
        Task<T> AddAsync(T item);
        Task<T> UpdateAsync(T item);
        Task<T> RemoveAsync(T item);
    }
}
