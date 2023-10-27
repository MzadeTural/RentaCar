using RentaCar.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaCar.Business.DTOs.CarDtos
{
    public class GetUserCarsDto
    {
        public string ModelName { get; set; }
        public string Owner { get; set; }  
        public string BrandName { get; set; }
        public string MainPhotoUrl { get; set; }
        public List<CarPhoto> Photos { get; set; }
        public string Description { get; set; }   
        public string GearBox { get; set; }
        public DateTime YearOfManufacture { get; set; }  
        public string FuelType { get; set; }
        public int SeatCount { get; set; }
        public List<Reservation>? Reservations { get; set; }
    }
}
