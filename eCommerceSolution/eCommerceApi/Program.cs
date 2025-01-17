using eCommerce.Services;
using eCommerce.Core;
using eCommerceApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

//add infrastructure services
builder.Services.AddInfrastructure();
builder.Services.AddCore();

//add controllers
builder.Services.AddControllers();

var app = builder.Build();

app.UseExceptionHandling();

//routing
app.UseRouting();

//auth
app.UseAuthentication();
app.UseAuthorization();

//controller
app.MapControllers();

app.Run();
