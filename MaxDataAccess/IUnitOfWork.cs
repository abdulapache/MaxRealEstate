using MaxDataAccess.Entites;
using MaxDataAccess.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxDataAccess
{
	public interface IUnitOfWork : IDisposable
	{
		IRepository<Agent> agents { get; }
		IRepository<Property> properties { get; }
		IRepository<Blog> blogs { get; }
		IRepository<ContactU> contactUs { get; }
		IRepository<UserQuery> userQuery { get; }
		void Save();
	}
}
