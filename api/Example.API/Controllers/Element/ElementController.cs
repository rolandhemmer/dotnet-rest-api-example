using System;
using System.Threading.Tasks;
using Example.API.Constants;
using Example.API.Models.Element;
using Example.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Example.API.Controllers.Element
{
    [ApiController]
    [Route(ControllerConstants.ElementControllerRoute)]
    public sealed class ElementController : ControllerBase
    {
        #region MEMBERS

        private readonly IElementRepository _elementRepository;
        private readonly ILogger<ElementController> _logger;

        #endregion MEMBERS

        #region CONSTRUCTORS

        public ElementController(IElementRepository elementRepository, ILogger<ElementController> logger)
        {
            _elementRepository = elementRepository;
            _logger = logger;
        }

        #endregion CONSTRUCTORS

        #region ROUTES

        [HttpPost]
        public async Task<IActionResult> CreateElementAsync([FromBody] ElementCreationModel creation)
        {
            _logger.LogInformation($"(Element creation) Element creation requested => '{JsonConvert.SerializeObject(creation)}'");

            var element = await _elementRepository.CreateAsync(creation);
            return Created($"http://{Request.Host.Value}/{ControllerConstants.ElementControllerRoute}/{element.Id}", element);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteElementAsync([FromRoute] Guid id)
        {
            _logger.LogInformation($"(Element '{id}') Element deletion requested");

            await _elementRepository.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetElementAsync([FromRoute] Guid id)
        {
            _logger.LogInformation($"(Element '{id}') Element fetch requested");

            var element = await _elementRepository.GetAsync(id);
            return Ok(element);
        }

        [HttpGet]
        public async Task<IActionResult> GetElementList()
        {
            _logger.LogInformation("(Element list) Element list fetch requested");

            var elementList = await _elementRepository.GetListAsync();
            return Ok(elementList);
        }

        #endregion ROUTES
    }
}
