using System;
using System.Collections.Generic;
using System.Text;
using TestProject.BAL.ViewModels;
using TestProject.DAL.Models;
using System.Linq.Expressions;

namespace TestProject.BAL.Interfaces
{
	public interface IOrdersService
	{
		OrdersListViewModel GetOrders();
		OrdersListViewModel GetOrders(Expression<Func<Orders, bool>> predicate);
		void ApplyChanges(OrdersListViewModel viewModel);
	}
}
