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

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ManagingSales.App;
using ManagingSales.App.Config;
using ManagingSales.App.IoC;
using Microsoft.Extensions.DependencyInjection;
using ManagingSales.App.Services;
using System.Net.Http;
using System;
using Microsoft.Extensions.Configuration;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
var configuration = builder.Configuration;

builder.Services.ConfigurePOCO<UrlsConfig>(configuration.GetSection("urls"));

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddSingleton<IOrderService, OrderService>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress =  new Uri(configuration.GetValue<string>("urls:apiUrl") )});
//builder.Services.AddApplicationServices(configuration);
await builder.Build().RunAsync();

