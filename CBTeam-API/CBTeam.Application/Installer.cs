using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CBTeam.Application
{
	public static class Installer
	{

		public static void InstallApplication(this IServiceCollection services)
		{
			
			services.AddAutoMapper(Assembly.GetExecutingAssembly());
			services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
			services.AddMediatR(x => x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
		}
	}
}
