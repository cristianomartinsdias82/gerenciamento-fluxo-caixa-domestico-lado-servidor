using IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
DependenciesContainer
	.AddServices(
		builder.Services,
		builder.Configuration);

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseAuthorization();

app.MapControllers();

app.Run();
