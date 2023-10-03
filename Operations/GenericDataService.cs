using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary_EF.Operations
{
    public class GenericDataService<T> : IDataService<T> where T : CommonFields 
    {
        public string k = "-";
        private readonly KinoDbnewContext _context;
        public GenericDataService()
        {
            _context = new KinoDbnewContext();
        }
        public Task<T> Create(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAll(T entity)
        {
            try
            {
                using (KinoDbnewContext context = _context)
                {
                    var createdEntities = await context.Set<T>().ToListAsync();
                    

                    string serializedEntity = JsonConvert.SerializeObject(createdEntities);
                    return createdEntities;
                }
            }
            catch (Exception ex) { k = ex.Message; return null; }
        }

        public Task<T> GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public Task<T> Update(int id, T entity)
        {
            throw new NotImplementedException();
        }
    }
}
