using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Example.API.Repositories
{
    public interface IRepository<TModel, in TCreationModel>
    {
        Task<TModel> CreateAsync(TCreationModel model);

        Task DeleteAsync(Guid id);

        Task<TModel> GetAsync(Guid id);

        Task<IList<TModel>> GetListAsync();
    }
}
