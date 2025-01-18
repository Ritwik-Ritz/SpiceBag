using eCommerce.Services;
using eCommerce.Core;
using eCommerceApi.Middlewares;
using System.Text.Json.Serialization;
using eCommerce.Core.Mappers;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

//add infrastructure services
builder.Services.AddInfrastructure();
builder.Services.AddCore();

//add controllers
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddAutoMapper(typeof(UserMapper).Assembly);

builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseExceptionHandling();

app.UseSwagger();
app.UseSwaggerUI();

//routing
app.UseRouting();

//auth
app.UseAuthentication();
app.UseAuthorization();

//controller
app.MapControllers();

app.Run();
