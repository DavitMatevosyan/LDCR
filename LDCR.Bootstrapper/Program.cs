using Catalog.Infrastructure;
using LDCR.Infrastructure.Controllers;
using LDCR.Infrastructure.Extensions;
using LDCR.Infrastructure.Middlewares;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSharedInfrastructure();

var modules = new ModuleLoader(builder.Configuration).LoadModules();

foreach (var moduleConfig in modules)
{
    moduleConfig.RegisterServices(builder);
}

builder.Services.AddProblemDetails(options =>
{
    options.CustomizeProblemDetails = context =>
    {
        //context.ProblemDetails.Extensions["TraceId"] = context.HttpContext.TraceIdentifier;

        //;
        //context.HttpContext.
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
    moduleConfig.ConfigureMiddlewares(app);
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionHandlingMiddleware>();
//app.UseExceptionHandler(/*"/error"*/);


app.UseAuthorization();

app.MapControllers();

app.Run();
