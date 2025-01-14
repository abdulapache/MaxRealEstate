using MaxDataAccess.Entites;
using MaxDataAccess.IRepository;
using MaxDataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxDataAccess
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly MaxRealStateContext db;
		public UnitOfWork(MaxRealStateContext db)
		{
			this.db = db;
			agents = new Repository<Agent>(db);
			properties = new Repository<Property>(db);
			blogs = new Repository<Blog>(db);
			
		}
		public IRepository<Agent> agents { get; private set; }
		public IRepository<Property> properties { get; private set; }
		public IRepository<Blog> blogs { get; private set; }

		public void Save()
		{
			db.SaveChanges();
		}

		public void Dispose()
		{
			db.Dispose();
		}
	}
}
