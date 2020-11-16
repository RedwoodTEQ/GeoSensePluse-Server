﻿using CoreCmd.CommandExecution;
using Google.Cloud.Firestore;
using System;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using GeoSensePlus.Firestore;
using NetCoreUtils.Database.MongoDb;
using Microsoft.Extensions.Logging;
using GeoSensePlus.Mqtt;
using NetCoreUtils.Database.InfluxDb;

namespace GeoSensePlus.Cli
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await new AssemblyCommandExecutor().ExecuteAsync(args, services =>
            {
                services.AddHttpClient();
                services.AddMongoDb(new MongoDbSetting { DatabaseName = "GeoSensePlus" });
                services.AddFirestoreServices();
                services.AddLogging(c => c.AddConsole());
                services.AddTransient<IMqttService, MqttService>();
                services.AddTransient<IMqttClientService, MqttClientService>();
                services.AddInfluxDb(new InfluxDbSetting
                {
                    Token = "ky6JucdlHoiCsDta7BxaagInhk33L9D52sK63CzAYB3S5Ptvvxpqdmn133eq-bWQ31uhH06Kkk7mmwFyhFKfuQ=="
                });
            });
        }

        // TODO: remove this method
        public static void ConfigureServices(IServiceCollection services)
        {
            //services.AddFirestoreServices();
        }
    }
}
