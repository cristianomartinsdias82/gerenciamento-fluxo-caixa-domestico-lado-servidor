using HouseholdCashFlowManagementApi.Configuration.ErrorHandling;
using IoC;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
DependenciesContainer
	.AddServices(
		builder.Host,
		builder.Services,
		builder.Configuration);

builder.Services.AddProblemDetails(configure =>
{
	configure.CustomizeProblemDetails = context =>
	{
		context.ProblemDetails.Extensions.TryAdd("requestId", context.HttpContext.TraceIdentifier);
	};
});
builder.Services.AddExceptionHandler<ValidationExceptionHandler>();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

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
	app.UseDeveloperExceptionPage();
}

app.UseExceptionHandler();

app.UseAuthorization();

app.MapControllers();

app.Run();
