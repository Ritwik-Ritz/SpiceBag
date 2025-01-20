using eCommerce.Prod.Core;
using eCommerce.Prod.Service;
using FluentValidation.AspNetCore;
using ProductService.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDataService(builder.Configuration);
builder.Services.AddCoreServices();

builder.Services.AddControllers();

builder.Services.AddFluentValidationAutoValidation();

var app = builder.Build();

app.UseExceptionHandling();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
