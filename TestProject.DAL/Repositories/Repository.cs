using System;
using System.Collections.Generic;
using System.Text;
using TestProject.DAL.Interfaces;
using TestProject.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace TestProject.DAL.Repositories
{
	public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
	{
		protected OrdersDBContext Context_;
		protected DbSet<TEntity> Set_
		{
			get
			{
				return Context_.Set<TEntity>();
			}
		}
		public Repository(OrdersDBContext context)
		{
			Context_ = context;
		}
		public virtual TEntity Get(long id)
		{
			return Set_.Find(id);
		}
		public virtual IEnumerable<TEntity> GetRange(Expression<Func<TEntity, bool>> predicate)
		{
			return Set_.Where(predicate);
		}
		public virtual IEnumerable<TEntity> GetAll()
		{
			return Set_;
		}
		public virtual void Update(TEntity entity)
		{
			Set_.Update(entity);
		}
		public virtual void AddRange(IEnumerable<TEntity> entities)
		{
			Set_.AddRange(entities);
		}
	}
}
