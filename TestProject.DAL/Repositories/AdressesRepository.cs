using System;
using System.Collections.Generic;
using System.Text;
using TestProject.DAL.Interfaces;

namespace TestProject.DAL.Repositories
{
	public class AdressesRepository : Repository<Models.BillingAddresses>, IAdressesRepository
	{
		public AdressesRepository(OrdersDBContext context) : base(context) { }
	}
}
