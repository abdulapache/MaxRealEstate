using MaxDataAccess.Entites;
using MaxDataAccess.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MaxDataAccess.Repository
{
	public class Repository<T> : IRepository<T> where T : class
	{
		private readonly MaxRealStateContext dbContext;
		internal DbSet<T> dbSet;
		public Repository(MaxRealStateContext db)
		{
			dbContext = db;
			dbSet = dbContext.Set<T>();
		}

		public T Add(T entity)
		{
			dbSet.Add(entity);
			return entity;
		}

		public IEnumerable<T> getList(Expression<Func<T, bool>> filter)
		{
			IQueryable<T> query = dbSet;
			return query.Where(filter).ToList();
		}

		public IEnumerable<T> getList(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IQueryable<T>> include = null)
		{
			IQueryable<T> query = dbSet;

			if (filter != null)
				query = query.Where(filter);

			if (include != null)
				query = include(query);

			return query.ToList();
		}


		public IEnumerable<T> All()
		{
			IQueryable<T> query = dbSet;
			return query.ToList();
		}

		public T FindFirstOrDefault(Expression<Func<T, bool>> filter)
		{
			IQueryable<T> query = dbSet;
			return query.Where(filter).FirstOrDefault();
		}

		public T Remove(T entity)
		{
			dbSet.Remove(entity);

			return entity;
		}

		public T Update(T entity)
		{
			dbContext.Update(entity);
			return entity;
		}
		public IEnumerable<T> GetPage(Expression<Func<T, bool>> filter, int pageNumber, int pageSize, Expression<Func<T, object>> orderBy)
		{
			return dbContext.Set<T>().Where(filter).OrderByDescending(orderBy)
				.Skip((pageNumber - 1) * pageSize)
				.Take(pageSize)
				.ToList();
		}

	}

}
