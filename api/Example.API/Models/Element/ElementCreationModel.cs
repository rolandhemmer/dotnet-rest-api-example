using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Example.API.Models.Element
{
    public sealed class ElementCreationModel
    {
        #region FIELDS

        public string Description { get; set; }

        [Required]
        [JsonRequired]
        public string Name { get; set; }

        #endregion FIELDS
    }
}
