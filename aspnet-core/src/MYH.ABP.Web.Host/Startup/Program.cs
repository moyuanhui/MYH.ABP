﻿using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace MYH.ABP.Web.Host.Startup
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseUrls("http://localhost:8000")
                .Build();
        }
    }
}
