using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierSystemDataLayer.Interfaces
{
    public interface IRepository<T>
    {
        public Task<T> Create(T entity);

        public void Update(T entity);

        public IEnumerable<T> GetAll();

        public T GetById(string Id);

        public void Delete(T entity);
    }
}
