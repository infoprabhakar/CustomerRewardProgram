using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using static Rewards.API.Constants;

namespace Rewards.API.Helper
{
    public static class HealthConfigExtension
    {
        public static IServiceCollection ConfigHealthChecks(this IServiceCollection services)
        {
            services.AddHealthChecks()
                .AddCheck(HealthConstants.Health, () => HealthCheckResult.Healthy(), tags: new[] { HealthConstants.Health });
            return services;
        }

        public static void MapCustomHealthChecks(this IEndpointRouteBuilder endpoint)
        {
            endpoint.MapHealthChecks($"/", new HealthCheckOptions()
            {
                Predicate = (check) => check.Tags.Contains(HealthConstants.Health),
                ResponseWriter = WriteResponses,
            }).WithMetadata(new AllowAnonymousAttribute());
        }

        public static async Task WriteResponses(HttpContext context, HealthReport report)
        {
            var json = new JObject(
                            new JProperty("Overall Health", report.Status.ToString()),
                            new JProperty("results", new JObject(report.Entries.Select(pair =>
                            new JProperty(pair.Key, new JObject(
                                new JProperty("Status", pair.Value.Status.ToString()),
                                new JProperty("Description", pair.Value.Description)
                                ))))));

            context.Response.ContentType = MediaTypeNames.Application.Json;
            await context.Response.WriteAsync(json.ToString(Formatting.Indented));
        }
    }
}
