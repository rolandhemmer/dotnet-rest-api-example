using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Example.API.Models.Element
{
    public sealed class ElementModel
    {
        #region CONSTRUCTORS

        public ElementModel()
        {
            Id = Guid.NewGuid();
            CreationDate = DateTime.UtcNow;
            UpdateDate = DateTime.UtcNow;
        }

        #endregion CONSTRUCTORS

        #region FIELDS

        [Required]
        [JsonRequired]
        public DateTime CreationDate { get; set; }

        [Required]
        [JsonRequired]
        public string Description { get; set; }

        [Required]
        [JsonRequired]
        public Guid Id { get; set; }

        [Required]
        [JsonRequired]
        public string Name { get; set; }

        [Required]
        [JsonRequired]
        public DateTime UpdateDate { get; set; }

        #endregion FIELDS
    }
}
