using Application.Configuration;
using Infrastructure.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace IoC;

public static class DependenciesContainer
{
	public static void AddServices(
		IHostBuilder hostBuilder,
		IServiceCollection services,
		IConfiguration configuration)
	{
		services.AddApplication(hostBuilder, configuration);
		services.AddInfrastructure(configuration);
	}
}
