using System;
using System.Collections.Generic;
using System.Text;
using TestProject.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace TestProject.DAL.Repositories
{
	public class StatusesRepository : Repository<Models.OrderStatuses>, IStatusesRepository
	{
		public StatusesRepository(OrdersDBContext context) : base(context) { }
	}
}
