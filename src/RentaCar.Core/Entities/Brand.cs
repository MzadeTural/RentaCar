using RentaCar.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaCar.Core.Entities
{
    public class Brand:BaseSectionEntity
    {
        public string Name { get; set; }
        public string IconUrl { get; set; }
        public List<Model> Models { get; set; }
    }
}
