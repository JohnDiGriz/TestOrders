using System;
using System.Collections.Generic;
using System.Text;
using TestProject.DAL.Interfaces;

namespace TestProject.DAL.Repositories
{
	public class ArticlesRepository : Repository<Models.Articles>, IArticlesRepository
	{
		public ArticlesRepository(OrdersDBContext context) : base(context) { }
	}
}
