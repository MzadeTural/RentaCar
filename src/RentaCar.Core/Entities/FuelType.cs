using RentaCar.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaCar.Core.Entities
{
    public class FuelType:BaseEntity
    {
        public string Name { get; set; }
        public Car Car { get; set; }
    }
}
