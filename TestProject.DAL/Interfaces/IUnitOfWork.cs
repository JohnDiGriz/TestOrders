using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject.DAL.Interfaces
{
	public interface IUnitOfWork
	{
		IOrdersRepository Orders { get; }
		IStatusesRepository Statuses { get; }
		IArticlesRepository Articles { get; }
		IAdressesRepository Adresses { get; }
		IPaymentsRepository Payments { get; }
		void Commit();
	}
}
