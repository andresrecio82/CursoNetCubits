using CBTeam.Domain.Interfaces;
using CBTeam.Infraestructure.Database;
using CBTeam.Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace CBTeam.Infraestructure
{
	public static class Installer
	{
		public static void addInfrastructure(this IServiceCollection services,string connectionString)
		{
			//services.AddDbContext<SqlServerDbContext>();
			services.AddDbContext<SqlServerContext>(options =>
			{
				// options.EnableSensitiveDataLogging();
				options.UseSqlServer(connectionString, sqlServerOptions =>
				{
					sqlServerOptions.CommandTimeout(30);
					sqlServerOptions.EnableRetryOnFailure();
					//sqlServerOptions.MigrationsHistoryTable("_Migrations");
					//sqlServerOptions.MigrationsAssembly("Foodly.Infrastructure");
				});
			});

			services.AddScoped<IUserRepository, UserRepository>();
		}
	}
}


