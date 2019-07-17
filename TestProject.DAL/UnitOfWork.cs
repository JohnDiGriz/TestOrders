using System;
using System.Collections.Generic;
using System.Text;
using TestProject.DAL.Interfaces;
using TestProject.DAL.Repositories;

namespace TestProject.DAL
{
	public class UnitOfWork : IUnitOfWork
	{
		private OrdersDBContext Context;
		public IOrdersRepository Orders { get; private set; }
		public IStatusesRepository Statuses { get; private set; }
		public IAdressesRepository Adresses { get; private set; }
		public IArticlesRepository Articles { get; private set; }
		public IPaymentsRepository Payments { get; private set; }

		public UnitOfWork(OrdersDBContext context)
		{
			Context = context;
			Orders = new OrdersRepository(context);
			Statuses = new StatusesRepository(context);
			Adresses = new AdressesRepository(context);
			Articles = new ArticlesRepository(context);
			Payments = new PaymentsRepository(context);
		}
		public void Commit()
		{
			Context.SaveChanges();
		}
	}
}
