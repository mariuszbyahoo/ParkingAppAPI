using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingApp.Tests
{
    public class AppConfig
    {

#if NETSTANDARD2_0 || NETCOREAPP3_0
        /// <summary>
        /// Gets a net core cfg supplied via json jsonCfgFileNames
        /// </summary>
        /// <returns></returns>
        public static IConfiguration GetNetCoreConfig()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(System.AppContext.BaseDirectory)

                //TODO - should really start using customised cfg providers at some point instead of IHostingEnv

                //cfg can be provided via appsettings
                //this is a default behavior, so always add id
                .AddJsonFile("testsettings.json",optional: false, reloadOnChange: true);

            return builder.Build();
        }
#endif
    }
}
