using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Example.API.Contexts;
using Example.API.Exceptions.Http;
using Example.API.Models.Element;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Example.API.Repositories
{
    public sealed class ElementRepository : IElementRepository
    {
        #region MEMBERS

        private readonly ILogger<IElementRepository> _logger;
        private readonly DbContextOptions _options;

        #endregion MEMBERS

        #region CONSTRUCTORS

        public ElementRepository(ILogger<IElementRepository> logger, DbContextOptions options)
        {
            _logger = logger;
            _options = options;
        }

        #endregion CONSTRUCTORS

        #region METHODS

        public async Task<ElementModel> CreateAsync(ElementCreationModel model)
        {
            var element = new ElementModel
            {
                Description = model.Description,
                Name = model.Name
            };

            _logger.LogInformation($"(Element '{element.Id}') Creating element model => '{JsonConvert.SerializeObject(model)}'");
            using (var context = new ExampleContext(_options))
            {
                await context.Elements.AddAsync(element);
            }

            _logger.LogInformation($"(Element '{element.Id}') Element model successfully created");

            return element;
        }

        public async Task DeleteAsync(Guid id)
        {
            _logger.LogInformation($"(Element '{id}') Deleting element model");

            var element = await GetAsync(id);
            using (var context = new ExampleContext(_options))
            {
                context.Elements.Remove(element);
            }

            _logger.LogInformation($"(Element '{id}') Element model successfully deleted");
        }

        public async Task<ElementModel> GetAsync(Guid id)
        {
            _logger.LogInformation($"(Element '{id}') Fetching element model");

            ElementModel element;
            using (var context = new ExampleContext(_options))
            {
                element = await context.Elements.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
            }

            if (element == null)
            {
                throw new NotFoundHttpException($"Element '{id}' not found");
            }

            _logger.LogInformation($"(Element '{id}') Element model successfully fetched");
            return element;
        }

        public async Task<IList<ElementModel>> GetListAsync()
        {
            _logger.LogInformation("(Element list) Fetching element model list");

            List<ElementModel> list;
            using (var context = new ExampleContext(_options))
            {
                list = await context.Elements.AsNoTracking().ToListAsync();
            }

            _logger.LogInformation($"(Element list) {list.Count} models successfully fetched: {JsonConvert.SerializeObject(list)}");
            return list;
        }

        #endregion METHODS
    }
}
