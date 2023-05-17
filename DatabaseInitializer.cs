using BBloGer.Models.Context;
using BBloGer.Models.Entiteis;

namespace BBloGer
{
	public class DatabaseInitializer
	{
		private static DatabaseContext _context;
		private static AppSettings _settings;
		public DatabaseInitializer(DatabaseContext context ,AppSettings settings)
		{
			_context = context;
			_settings = settings;
		}
		public static void Seed()
		{
			if (_context.Users.Any(x => x.UserName == _settings.AdminUsername) == false) 
			{
				_context.Users.Add(new User
				{
					UserName = _settings.AdminUsername,
					Password = _settings.AdminPassword,
					FullName = _settings.AdminFullName,
					Email = _settings.AdminEmail,
					IsActive = true,
					IsAdmin = true,
					CreateUser = "default",
					CreatedAt = DateTime.Now

				});

				_context.SaveChanges();
			}
		}
	}
}
