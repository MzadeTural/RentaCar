using RentaCar.Core.Entities.Common;

namespace RentaCar.Core.Entities
{
    public class Model:BaseSectionEntity
    {
        public string Name { get; set; }
        public Guid BrandId { get; set; }
        public Brand Brand { get; set; }
    }
}
