using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrganizerLibrary.Services
{
    public interface IDataService<T>
    {
        Task<IEnumerable<T>> GetAll();

        Task<IEnumerable<T>> GetAllExtended();

        Task<T> Get(int id);

        Task<T> GetExtended(int id);

        Task<T> Create(T entity);

        Task<T> Update(int id, T entity);

        Task<bool> Delete(int id);
    }
}
