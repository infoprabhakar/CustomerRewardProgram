using Repository;
using Rewards.Models;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace RewardEngine
{
    public class RewardService : IRewardService
    {
        private readonly IRewardRepository _rewardRepository;
        public RewardService(IRewardRepository rewardRepository)
        {
            _rewardRepository = rewardRepository;
        }

        public async Task<RewardSummaryReport> GetRewardPointSummaryByDates(DateTime? startDateTime,
            DateTime? endDateTime)
        {
            var customers = await Task.FromResult(_rewardRepository.GetCustomerList());
            var transactions = await Task.FromResult(_rewardRepository.GetTransactionList());
            RewardSummaryReport rewardSummaryReport = new RewardSummaryReport();
            var transactionSummary = from tran in transactions
                                     join cust in customers
                                     on tran.CustomerId equals cust.CustomerId
                                     where tran.TransactionDate >= startDateTime && tran.TransactionDate <= endDateTime
                                     select new TransactionSummary
                                     {
                                         MonthYear = tran.TransactionDate.ToString("MMMM") + " " + tran.TransactionDate.Year,
                                         TransactionDate = tran.TransactionDate,
                                         Price = tran.Price,
                                         RewardPoints = CalculateRewardPoints(tran.Price),
                                         CustomerName = cust.FirstName + " " + cust.LastName
                                     };
            var customerwiseRewardSummary = from reward in transactionSummary
                                            group reward by (reward.MonthYear, reward.CustomerName) into crs
                                            orderby crs.Key.CustomerName
                                            select new CustomerwiseRewardSummary
                                            {
                                                CustomerName = crs.Key.CustomerName,
                                                MonthYear = crs.Key.MonthYear,
                                                RewardPoints = crs.Sum(x => x.RewardPoints)
                                            };

            rewardSummaryReport.TransactionSummaryDetail = transactionSummary.ToList();
           
            rewardSummaryReport.CustomerwiseRewardSummaryDetail = customerwiseRewardSummary.ToList();

            return rewardSummaryReport;
        }

        public async Task<RewardSummaryReport> GetRewardPointMonthlySummary(int? noOfMonths)
        {
            var customers = await Task.FromResult(_rewardRepository.GetCustomerList());
            var transactions = await Task.FromResult(_rewardRepository.GetTransactionList());
            var dateTimeCheck = DateTime.Now.AddMonths(-(int)noOfMonths);
            
            RewardSummaryReport rewardSummaryReport = new RewardSummaryReport();
            var transactionSummary = from tran in transactions
                                     join cust in customers
                                     on tran.CustomerId equals cust.CustomerId
                                     where tran.TransactionDate >= dateTimeCheck
                                     select new TransactionSummary
                                     {
                                         MonthYear = tran.TransactionDate.ToString("MMMM") + " " + tran.TransactionDate.Year,
                                         TransactionDate = tran.TransactionDate,
                                         Price = tran.Price,
                                         RewardPoints = CalculateRewardPoints(tran.Price),
                                         CustomerName = cust.FirstName + " " + cust.LastName
                                     };
            var customerwiseRewardSummary = from reward in transactionSummary
                                            group reward by (reward.MonthYear, reward.CustomerName) into crs
                                            orderby crs.Key.CustomerName
                                            select new CustomerwiseRewardSummary
                                            {
                                                CustomerName = crs.Key.CustomerName,
                                                MonthYear = crs.Key.MonthYear,
                                                RewardPoints = crs.Sum(x => x.RewardPoints)
                                            };

            rewardSummaryReport.TransactionSummaryDetail = transactionSummary?.ToList();
           
            rewardSummaryReport.CustomerwiseRewardSummaryDetail = customerwiseRewardSummary?.ToList();
            
            return rewardSummaryReport;
        }

        public async Task<decimal> GetRewardPoints(decimal price)
        {
            return await Task.FromResult(CalculateRewardPoints(price));
        }  

        private decimal CalculateRewardPoints(decimal price)
        {
            return (price > 50) ? ((price > 100) ? (price - 50) * 1 + (price - 100) * 1 : (price - 50) * 1) : 0;
        }     
    }
}
