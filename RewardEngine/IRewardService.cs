using Rewards.Models;
using System;
using System.Threading.Tasks;

namespace RewardEngine
{
    public interface IRewardService
    {
        Task <RewardSummaryReport> GetRewardPointSummaryByDates(DateTime? startDateTime,
            DateTime? endDateTime);
        Task<RewardSummaryReport> GetRewardPointMonthlySummary(int? noOfMonths);
        Task<decimal> GetRewardPoints(decimal price);
    }
}
