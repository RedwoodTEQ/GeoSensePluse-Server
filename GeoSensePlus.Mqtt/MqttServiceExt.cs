﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoSensePlus.Mqtt
{
    public static class MqttServiceExt
    {
        public static void AddMqtt(this IServiceCollection services)
        {
            services.AddSingleton<IMqttService, MqttService>();
            services.AddTransient<IMqttClientService, MqttClientService>();
            services.AddHostedService<MqttHostedService>();
        }
    }
}
