using LDCR.Infrastructure.Extensions;
using LDCR.Infrastructure.Modules;
using LDCR.Shared.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSharedInfrastructure();

var modules = new ModuleLoader(builder.Configuration).LoadModules();

builder.Services.AddDbContext<ModuleDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Master")));

foreach (var moduleConfig in modules)
{
    moduleConfig.RegisterServices(builder);
}

builder.Services.AddProblemDetails(options =>
{
    options.CustomizeProblemDetails = context =>
    {
        context.ProblemDetails.Extensions.Add("Details", context.AdditionalMetadata);
        context.ProblemDetails.Extensions.Add("Details1", context.Exception?.Message);
        //context.ProblemDetails.Extensions["TraceId"] = context.HttpContext.TraceIdentifier;

        //;
        //context.HttpContext
        //context.ProblemDetails.
    };
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

foreach (var moduleConfig in modules)
{
    moduleConfig.ConfigureGlobalMiddlewares(app);
}

app.Run();
