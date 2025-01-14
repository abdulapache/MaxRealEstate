using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MaxDataAccess.IRepository
{
	public interface IRepository<T> where T : class
	{
		IEnumerable<T> All();
		T Add(T entity);
		T Update(T entity);
		T Remove(T entity);
		T FindFirstOrDefault(Expression<Func<T, bool>> filter);
		IEnumerable<T> getList(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IQueryable<T>> include = null);
		IEnumerable<T> GetPage(Expression<Func<T, bool>> filter, int pageNumber, int pageSize, Expression<Func<T, object>> orderBy);
	}
}
