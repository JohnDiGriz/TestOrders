using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TestProject.BAL.ViewModels
{
	public class OrdersListViewModel
	{
		public List<OrderViewModel> Orders { get; set; }
		public List<SelectListItem> Statuses { get; set; }
		public OrdersListViewModel()
		{
			Orders = new List<OrderViewModel>();
			Statuses = new List<SelectListItem>();
		}
		public string SearchLine { get; set; }
	}
}
