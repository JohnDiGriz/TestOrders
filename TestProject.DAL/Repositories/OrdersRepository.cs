using System;
using System.Collections.Generic;
using System.Text;
using TestProject.DAL.Interfaces;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace TestProject.DAL.Repositories
{
	public class OrdersRepository : Repository<Models.Orders>, IOrdersRepository
	{
		public OrdersRepository(OrdersDBContext dBContext) : base(dBContext)
		{
		}
		public override Models.Orders Get(long id)
		{
			return Set_.Where(x=>x.OxId==id)
				.Include(x=>x.OrderStatusNavigation)
				.Include(x=>x.BillingAddresses)
				.Include(x=>x.Articles)
				.Include(x=>x.Payments).FirstOrDefault();
		}
		public override IEnumerable<Models.Orders> GetRange(Expression<Func<Models.Orders, bool>> predicate)
		{
			return Set_.Where(predicate)
				.Include(x => x.OrderStatusNavigation)
				.Include(x => x.BillingAddresses)
				.Include(x => x.Articles)
				.Include(x => x.Payments);
		}
		public override IEnumerable<Models.Orders> GetAll()
		{
			return Set_
				.Include(x => x.OrderStatusNavigation)
				.Include(x => x.BillingAddresses)
				.Include(x => x.Articles)
				.Include(x => x.Payments);
		}
			public void SetStatus(long id, string newStatus)
		{
			var order=Set_.Where(x => x.OxId == id).Include(x => x.OrderStatusNavigation).FirstOrDefault();
			if (order != null)
			{
				order.OrderStatusNavigation = Context_.OrderStatuses.Where(x => x.Name == newStatus).FirstOrDefault();
				Set_.Update(order);
			}
		}
		public void SetInvoiceNumber(long id, int number)
		{
			var order = Set_.Where(x => x.OxId == id).FirstOrDefault();
			if (order != null)
			{
				order.InvoiceNumber = number;
				Set_.Update(order);
			}
		}
		
	}
}
