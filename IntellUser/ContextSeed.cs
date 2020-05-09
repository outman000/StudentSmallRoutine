using Dtol;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntellUser
{
    public class ContextSeed
    {
        public static async Task SeedAsync(IApplicationBuilder applicationBuilder, ILoggerFactory loggerFactory, int retry = 0)
        {
            var retryCount = retry;
            try
            {
                using (var scope = applicationBuilder.ApplicationServices.CreateScope())
                {
                    var context = (DtolContext)scope.ServiceProvider.GetService(typeof(DtolContext));
                    var logger = (ILogger<ContextSeed>)scope.ServiceProvider.GetService(typeof(ILogger<ContextSeed>));
                    logger.LogDebug("Begin userContextSeed SeedAsync");
                    context.Database.Migrate();
                }
            }
            catch (Exception e)
            {
                retryCount++;
                var logger = loggerFactory.CreateLogger(typeof(DtolContext));
                logger.LogError(e.Message);
                await Task.Delay(TimeSpan.FromSeconds(retryCount));
                if (retryCount <= 5)
                {
                    await SeedAsync(applicationBuilder, loggerFactory, retryCount);
                }
            }
        }
    }
}
