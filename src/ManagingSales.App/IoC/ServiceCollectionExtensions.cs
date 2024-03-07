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

using System;
using System.Net.Http;
using ManagingSales.App.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;

namespace ManagingSales.App.IoC;

public static class ServiceCollectionExtensions
{
    public static TConfig ConfigurePOCO<TConfig>(this IServiceCollection services, IConfiguration configuration)
   where TConfig : class, new()
    {
        if (services == null) throw new ArgumentNullException(nameof(services));
        if (configuration == null) throw new ArgumentNullException(nameof(configuration));

        var config = new TConfig();
        configuration.Bind(config);
        services.AddSingleton(config);
        return config;
    }

    //public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    //{
    //    ////register delegating handlers
    //    //// services.AddTransient<HttpClientAuthorizationDelegatingHandler>();
    //    //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

    //    ////register http services
    //    //services
    //    //    .AddHttpClient<IOrderService, OrderService>("ApiUrl", client =>
    //    //    {
    //    //        client.BaseAddress = new Uri("http://localhost:38163");//new Uri(configuration.GetValue<string>("urls:ApiUrl"));
    //    //    });
    //    ////.AddTransientHttpErrorPolicy(builder => builder.WaitAndRetryAsync(5, arrempt => TimeSpan.FromSeconds(arrempt * 2)
    //    ////));

    //    //// добавляем HttpClient
    //    ////services.AddScoped(sp =>
    //    ////    new HttpClient
    //    ////    {
    //    ////        BaseAddress = new Uri("https://localhost:7066/")
    //    ////    });
    //    ////services.AddHttpClient();
    //    //services.AddScoped<HttpClient>();
    //    //return services;

    //    //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    //    //services.AddSingleton<IOrderService, OrderService>();
    //    ////register http services
    //    //services
    //    //    .AddHttpClient<IOrderService, OrderService>("ApiUrl", client =>
    //    //    {
    //    //        var url = configuration.GetValue<string>("urls:apiUrl");
    //    //        client.BaseAddress = new Uri(url);
    //    //    });
    //    //    //.AddTransientHttpErrorPolicy(builder => builder.WaitAndRetryAsync(5, arrempt => TimeSpan.FromSeconds(arrempt * 2)
    //    //       //));

    //    //return services;
    //}

}

