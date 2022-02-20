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
    public class ListsDataServices : IDataService<ListModel>
    {
        private readonly OrganizerDbContextFactory _contextFactory;
        private readonly NonQueryDataService<ListModel> _nonQueryDataService;


        public ListsDataServices(OrganizerDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _nonQueryDataService = new NonQueryDataService<ListModel>(contextFactory);
        }

        public async Task<ListModel> Create(ListModel entity)
        {
            return await _nonQueryDataService.Create(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _nonQueryDataService.Delete(id);
        }

        public async Task<ListModel> Get(int id)
        {
            using (OrganizerDBContext context = _contextFactory.CreateDbContext())
            {
                ListModel entity = await context.ListModels.Include(a =>a.EventModels).FirstOrDefaultAsync(c => c.Id == id);

                return entity;
            }
        }

        public async Task<IEnumerable<ListModel>> GetAll()
        {
            using (OrganizerDBContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<ListModel> entities = await context.ListModels.Include(a => a.EventModels).ToListAsync();

                return entities;
            }
        }

        public async Task<ListModel> Update(int id, ListModel entity)
        {
            return await _nonQueryDataService.Update(id, entity);
        }
    }
}
