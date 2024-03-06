/*
 *   Copyright (c) 2024 Dzianis Prokharchyk

 *   This program is free software: you can redistribute it and/or modify
 *   it under the terms of the GNU General Public License as published by
 *   the Free Software Foundation, either version 3 of the License, or
 *   (at your option) any later version.

 *   This program is distributed in the hope that it will be useful,
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *   GNU General Public License for more details.

 *   You should have received a copy of the GNU General Public License
 *   along with this program.  If not, see <https://www.gnu.org/licenses/>.
 */

using System.Threading.Tasks;
using ManagingSales.API.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.

builder.Services
    //.AddConfigEf(configuration)
    //.AddDatabaseInitializer<MSDbContext>()
    .AddRequiredMvcComponents()
    .AddBusiness()
    .AddEndpointsApiExplorer()
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    .AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", _ => _.AllowAnyMethod().AllowAnyHeader());
});

//Add support to logging with SERILOG
builder.Host.UseSerilog((context, configuration) =>
    configuration.WriteTo.Console().ReadFrom.Configuration(context.Configuration));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Add support to logging request with SERILOG
app.UseSerilogRequestLogging();

//app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();
app.Use(async (context, next) =>
{
    context.Response.OnStarting(() =>
    {
        context.Response.Headers.Add("X-Powered-By", "ManagingSales: Example test task");
        return Task.CompletedTask;
    });

    await next.Invoke();
});
app.MapControllers();

app.Run();

