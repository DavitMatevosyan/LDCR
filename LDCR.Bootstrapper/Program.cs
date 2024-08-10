using LDCR.Infrastructure.Controllers;
using LDCR.Infrastructure.Extensions;

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
        context.ProblemDetails.Extensions.Add("asd", "qweqwe");
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
    moduleConfig.ConfigureMiddlewares(app);
}

app.Run();
