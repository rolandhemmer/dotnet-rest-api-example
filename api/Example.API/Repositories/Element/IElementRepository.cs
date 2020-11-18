using Example.API.Models.Element;

namespace Example.API.Repositories
{
    public interface IElementRepository : IRepository<ElementModel, ElementCreationModel>
    {
    }
}
