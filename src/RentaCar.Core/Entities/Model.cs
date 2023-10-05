using RentaCar.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaCar.Core.Entities
{
    public class Model:BaseSectionEntity
    {
        public string Name { get; set; }
        public Brand Brand { get; set; }
        public Guid BrandId { get; set; }
    }
}
