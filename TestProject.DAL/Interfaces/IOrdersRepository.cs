using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject.DAL.Interfaces
{
	public interface IOrdersRepository : IRepository<Models.Orders>
	{
		void SetStatus(long id, string status);
		void SetInvoiceNumber(long id, int number);
	}
}
