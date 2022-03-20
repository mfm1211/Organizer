using OrganizerLibrary.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OrganizerLibrary.Models;
using System.Linq;
namespace OrganizerDataFilesConnection.Services
{
    public class TextFilesSectionsDataService : IDataService<SectionModel>
    {
        private const string fileOfSections = "SectionsFile.csv";
        public async Task<SectionModel> Create(SectionModel entity)
        {
            List<SectionModel> sections = await Task.Run(() => fileOfSections.FullFilePath().LoadFile().ConvertToSectionModels());

            entity.Id = fileOfSections.FindEmptyId();

            sections.Add(entity);

            await Task.Run(() => sections.SaveToSectiontFile(fileOfSections));

            return entity;
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<SectionModel> Get(int id)
        {
            SectionModel result;
            List<SectionModel> temp = await Task.Run(() => fileOfSections.FullFilePath().LoadFile().ConvertToSectionModels());

            result = temp.Single(m => m.Id == id);

            return result;
        }

        public async Task<IEnumerable<SectionModel>> GetAll()
        {
           return await Task.Run(() => fileOfSections.FullFilePath().LoadFile().ConvertToSectionModels());
        }

        public Task<IEnumerable<SectionModel>> GetAllExtended()
        {
            throw new NotImplementedException();
        }

        public Task<SectionModel> GetExtended(int id)
        {
            throw new NotImplementedException();
        }

        public Task<SectionModel> Update(int id, SectionModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
