using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;

namespace TestProject.DAL.Interfaces
{
	public interface IRepository<TEntity>
	{
		TEntity Get(long id);
		IEnumerable<TEntity> GetRange(Expression<Func<TEntity, bool>> predicate);
		IEnumerable<TEntity> GetAll();
		void Update(TEntity entity);
		void AddRange(IEnumerable<TEntity> entities);
	}
}
