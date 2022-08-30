using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Repository;
using RewardEngine;
using Rewards.API.Controllers;
using Rewards.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rewards.API.UnitTests
{
    [TestClass]
    public class RewardControllerTest
    {
        private RewardsController _rewardsController;        
        private Mock<IRewardService> _rewardService;

        [TestInitialize]
        public void Initialize()
        {           
            _rewardService = new Mock<IRewardService>();
            _rewardsController = new RewardsController(_rewardService.Object, null);
        }


        [TestMethod]
        public async Task GetRewardPointSummaryByDatesTest()
        {
            var startDate = Convert.ToDateTime("07/25/2022");
            var endDate = Convert.ToDateTime("07/28/2022");
            _rewardService.Setup(x => x.GetRewardPointSummaryByDates(startDate, endDate)).Returns(new RewardSummaryReport()
            {
                TransactionSummaryDetail = new List<TransactionSummary>()
                {
                    new TransactionSummary(){ CustomerName = "John Wick", MonthYear = "July 2022", Price = 120, RewardPoints = 90, TransactionDate = Convert.ToDateTime("07/25/2022")}
                },
                CustomerwiseRewardSummaryDetail = new List<CustomerwiseRewardSummary>()
                {
                    new CustomerwiseRewardSummary()
                    {
                        CustomerName="John Wick",
                        RewardPoints = 90,
                        MonthYear = "July 2022"
                    }
                }
            });

            var result = await _rewardsController.GetRewardPointSummaryByDates(startDate, endDate) as OkObjectResult;
            Assert.IsNotNull(result.Value);
        }

        [TestMethod]
        public async Task GetRewardPointMonthlySummaryTest()
        {           
            _rewardService.Setup(x => x.GetRewardPointMonthlySummary(null)).Returns(new RewardSummaryReport()
            {
                TransactionSummaryDetail = new List<TransactionSummary>()
                {
                    new TransactionSummary(){ CustomerName = "John Wick", MonthYear = "July 2022", Price = 120, RewardPoints = 90, TransactionDate = Convert.ToDateTime("07/25/2022")}
                },
                CustomerwiseRewardSummaryDetail = new List<CustomerwiseRewardSummary>()
                {
                    new CustomerwiseRewardSummary()
                    {
                        CustomerName="John Wick",
                        RewardPoints = 90,
                        MonthYear = "July 2022"
                    }
                }
            });

            var result = await _rewardsController.GetRewardPointMonthlySummary(null) as OkObjectResult;
            Assert.IsNotNull(result.Value);
        }
    }
}
