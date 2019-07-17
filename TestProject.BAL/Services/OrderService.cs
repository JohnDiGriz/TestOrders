using System;
using System.Collections.Generic;
using System.Text;
using TestProject.BAL.Interfaces;
using TestProject.BAL.ViewModels;
using TestProject.BAL.Extensions;
using TestProject.DAL.Interfaces;
using TestProject.DAL.Models;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TestProject.BAL.Services
{
	public class OrderService : IOrdersService
	{
		private readonly IUnitOfWork Unit;
		public OrderService(IUnitOfWork unitOfWork)
		{
			Unit = unitOfWork;
		}
		public OrdersListViewModel GetOrders()
		{
			var list = new OrdersListViewModel();
			list.Orders.AddRange(Unit.Orders.GetAll().Select(x => x.ToViewModel()).ToList());
			list.Statuses.AddRange(Unit.Statuses.GetAll().Select(x => new SelectListItem() { Value=x.Name, Text=x.Name}).ToList());
			return list;
		}
		public OrdersListViewModel GetOrders(Expression<Func<Orders, bool>> predicate)
		{
			var list = new OrdersListViewModel();
			list.Orders.AddRange(Unit.Orders.GetRange(predicate).Select(x => x.ToViewModel()).ToList());
			list.Statuses.AddRange(Unit.Statuses.GetAll().Select(x => new SelectListItem() { Value = x.Name, Text = x.Name }).ToList());
			return list;
		}
		public void ApplyChanges(OrdersListViewModel viewModel)
		{
			foreach(var order in viewModel.Orders)
			{
				if (!string.IsNullOrEmpty(order.OrderStatus) && order.OrderStatus!="None")
					Unit.Orders.SetStatus(order.OxId, order.OrderStatus);
				if (order.InvoiceNumber != null)
					Unit.Orders.SetInvoiceNumber(order.OxId, (int)order.InvoiceNumber);
			}
			Unit.Commit();
		}
	}
}
