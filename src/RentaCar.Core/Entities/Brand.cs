using RentaCar.Core.Entities.Common;

namespace RentaCar.Core.Entities
{
    public class Brand:BaseSectionEntity
    {
        public string Name { get; set; }
        public string IconUrl { get; set; }
        public IEnumerable<Model> Models { get; set; }
    }
}
