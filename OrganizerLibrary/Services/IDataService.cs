using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrganizerLibrary.Services
{
    public interface IDataService<T>
    {
        Task<IEnumerable<T>> GetAll();

        Task<IEnumerable<T>> GetAllWithItemLists();

        Task<T> Get(int id);

        Task<T> GetWithItemLists(int id);

        Task<T> Create(T entity);

        Task<T> Update(int id, T entity);

        Task<bool> Delete(int id);
    }
}
