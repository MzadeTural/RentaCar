using RentaCar.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaCar.Core.Entities
{
    public class UserCard:BaseSectionEntity
    {
        public string FullName { get; set; }
        public string CardNumber { get; set; }
        public DateTime ExpireDate { get; set; }
        public string CVV { get; set; }
        public string UserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
