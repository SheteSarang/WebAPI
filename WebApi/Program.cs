using WebApi.Models;
using Microsoft.EntityFrameworkCore; // Add this using directive
using Microsoft.Extensions.DependencyInjection; // Add this using directive

var builder = WebApplication.CreateBuilder(args);

// Add services to the container. DEPENDENCY INJECTION
builder.Services.AddDbContext<UserContext>(options =>   //Methods like AddDbContext and AddControllers are extension methods on IServiceCollection.
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbCon")));
builder.Services.AddControllers();


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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();