using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary_EF.Operations
{
    public interface IDataService<T> where T : CommonFields
    {
        Task<IEnumerable<T>> GetAll(T entity);

        Task<T> GetOne(int id);

        Task<T> Create(T entity);
        Task<bool> Delete(int id);
        Task<T> Update(int id, T entity);
    }
}
