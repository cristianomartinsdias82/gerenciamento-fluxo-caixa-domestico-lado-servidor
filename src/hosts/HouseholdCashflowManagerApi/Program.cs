using IoC;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
DependenciesContainer
	.AddServices(
		builder.Services,
		builder.Configuration);

builder.Services.AddOpenApi();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.MapOpenApi();
	app.MapScalarApiReference(options =>
	{
		options.Title = "Household Cash Flow Management API Documentation";
		options.ShowSidebar = true;
		options.Theme = ScalarTheme.Laserwave;
	});
}

app.UseAuthorization();

app.MapControllers();

app.Run();
