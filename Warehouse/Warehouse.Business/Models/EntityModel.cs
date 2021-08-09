using System.ComponentModel.DataAnnotations;
using Warehouse.Business.Helpers;

namespace Warehouse.Business.Models
{
    public abstract class EntityModel
    {
        [SwaggerIgnore]
        public string Id { get; set; }
        
        [Required]
        public string SerialNumber { get; set; }
    }
}
