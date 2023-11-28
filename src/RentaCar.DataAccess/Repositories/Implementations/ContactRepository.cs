using System;
using RentaCar.Core.Entities;
using RentaCar.DataAccess.Contexts;
using RentaCar.DataAccess.Repositories.Interfaces;

namespace RentaCar.DataAccess.Repositories.Implementations
{
	public class ContactRepository : Repository<Contact>, IContactRepository
    {
		public ContactRepository(RentaCarContext context):base(context)
		{

		}
	}
}

