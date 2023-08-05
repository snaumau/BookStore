using API.Extensions;
using API.Helpers;
using API.Middleware;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<StoreContext>(options => options.UseSqlite(connectionString));

builder.Services.AddAutoMapper(typeof(MappingProfiles));

builder.Services.AddApplicationServices();
builder.Services.AddSwaggerDocumentation();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();
app.UseSwaggerDocumentation();

app.ApplyMigrations();

app.UseStatusCodePagesWithReExecute("/errors/{0}");

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
