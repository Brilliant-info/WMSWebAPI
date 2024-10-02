using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
//builder.Services.AddConnections("DefaultConnection");
//builder.Services.AddSingleton<IDbConnection>(sp => new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    //  app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
