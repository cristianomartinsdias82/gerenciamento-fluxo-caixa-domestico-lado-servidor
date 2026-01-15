using Application.Common.Data;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

namespace Infrastructure.Configuration;

public static class DependencyInjection
{
	extension(IServiceCollection services)
	{
		public IServiceCollection AddInfrastructure(IConfiguration configuration)
			=> services.AddPersistence(configuration);

		private IServiceCollection AddPersistence(IConfiguration configuration)
		{
			BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));

			services.AddSingleton(new MongoClient(configuration["DatabaseSettings:ConnectionString"]));
			services.AddScoped(sp =>
			{
				var client = sp.GetRequiredService<MongoClient>();
				var databaseName = configuration["DatabaseSettings:DatabaseName"];

				return client.GetDatabase(databaseName);
			});	
			services.AddScoped<ICashFlowDbContext>(sp =>
			{
				var database = sp.GetRequiredService<IMongoDatabase>();
				
				return new CashFlowDbContext(new DbContextOptionsBuilder<CashFlowDbContext>()
													.UseMongoDB(
														database.Client,
														database.DatabaseNamespace.ToString())
													.Options);
			});

			return services;
		}
	}
}
