using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Repository;
using RewardEngine;

namespace Rewards.API
{
    public static class DIExtensions
    {
        public static IServiceCollection RegisterRewardDependeny(this IServiceCollection services)
        {
            services.AddTransient<IRewardRepository>(_ => new RewardRepository());
            services.AddTransient<IRewardService>(_ => new RewardService(_.GetRequiredService<IRewardRepository>()));
            return services;
        }
    }
}
