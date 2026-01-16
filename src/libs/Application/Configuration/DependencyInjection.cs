using ImTools;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Wolverine;
using Wolverine.FluentValidation;

namespace Application.Configuration;

public static class DependencyInjection
{
	extension(IServiceCollection services)
	{
		public IServiceCollection AddApplication(
			IHostBuilder hostBuilder,
			IConfiguration configuration)
		{
			hostBuilder.UseWolverine(options =>
			{
				options.UseFluentValidation();
			});

			return services;
		}
	}
}
