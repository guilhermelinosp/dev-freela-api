using DevFreela.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DevFreela.Application;

public static class ApplicationInjaction
{
	public static IServiceCollection AddApplicationInjaction(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddInfrastructureInjaction();
		return services;
	}
	
	
}