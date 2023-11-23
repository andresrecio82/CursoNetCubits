using CBTeam.Domain.Entities;
using CBTeam.Domain.Interfaces;
using CBTeam.Infraestructure.Database;


namespace CBTeam.Infraestructure.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly SqlServerContext _context;

		public UserRepository(SqlServerContext context) 
		{
			_context = context;
		}

		public List<User> GetList()
		{
			var userList = _context
				.Set<User>()
				.ToList();
			return userList;

		}
	}
}

