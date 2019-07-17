using System;
using System.Collections.Generic;
using System.Text;
using TestProject.DAL.Interfaces;

namespace TestProject.DAL.Repositories
{
	public class PaymentsRepository : Repository<Models.Payments>, IPaymentsRepository
	{
		public PaymentsRepository(OrdersDBContext context) : base(context) { }
	}
}
