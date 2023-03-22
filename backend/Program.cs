global using Microsoft.EntityFrameworkCore;
global using backend.Models;
using backend.Services.ClotheService;
using backend.Data;
using NextjsStaticHosting.AspNetCore;
var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<NextjsStaticHostingOptions>(builder.Configuration.GetSection("NextjsStaticHosting"));
builder.Services.AddNextjsStaticHosting();
// Add services to the container.
builder.Services.AddDbContext<DataContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IClotheService, ClotheService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapNextjsStaticHtmls();
app.UseNextjsStaticHosting();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
