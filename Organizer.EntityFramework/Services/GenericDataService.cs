  using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Organizer.EntityFramework.Services.Common;
using OrganizerLibrary.Models;
using OrganizerLibrary.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Organizer.EntityFramework.Services
{
    public class GenericDataService<T> : IDataService<T> where T : BaseItemModel
    {
        private readonly OrganizerDbContextFactory _contextFactory;
        private readonly NonQueryDataService<T> _nonQueryDataService;

        public GenericDataService(OrganizerDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _nonQueryDataService = new NonQueryDataService<T>(contextFactory);
        }

        public async Task<T> Create(T entity)
        {
            return await _nonQueryDataService.Create(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _nonQueryDataService.Delete(id);
        }

        public async Task<T> Get(int id)
        {
            using (OrganizerDBContext context = _contextFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync(c => c.Id == id);

                return entity;
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            using (OrganizerDBContext context = _contextFactory.CreateDbContext())
            {
               IEnumerable<T> entities = await context.Set<T>().ToListAsync();

                foreach(T  model in entities)
                {
                    ListModel listModel = await context.Set<ListModel>().FirstOrDefaultAsync(c => c.Id == model.ListModelId);

                    model.FontColor = listModel.ColorString;
                }
               

                return entities;
            }
        }

        public async Task<IEnumerable<T>> GetAllWithItemLists()
        {
            using (OrganizerDBContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<T> entities = await context.Set<T>().ToListAsync();

                return entities;
            }
        }

        public Task<T> GetWithItemLists(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<T> Update(int id, T entity)
        {
            return await _nonQueryDataService.Update(id, entity);
        }
    }
}
