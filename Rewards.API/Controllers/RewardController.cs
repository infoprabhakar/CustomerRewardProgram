using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RewardEngine;
using System;
using System.Threading.Tasks;

namespace Rewards.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RewardsController : ControllerBase
    {
        private readonly ILogger<RewardsController> _logger;
        private readonly IRewardService _rewardService;

        public RewardsController(IRewardService rewardService,
            ILogger<RewardsController> logger)
        {
            _rewardService = rewardService;
            _logger = logger;
        }

        [HttpGet("GetRewardPointSummaryByDate")]
        public async Task<IActionResult> GetRewardPointSummaryByDate(DateTime? startDateTime,
            DateTime? endDateTime)
        {
            try
            {
                if(startDateTime == null || endDateTime == null)
                    return StatusCode(500, new {
                        Successful = false,
                        ErrorMessage = "startDateTime and endDateTime can't be null for GetRewardPointSummaryByDate report"
                    });
                var result = await _rewardService.GetRewardPointSummaryByDates(startDateTime, endDateTime);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return StatusCode(500, new {
                        Successful = false,
                        ErrorMessage = ex.Message
                    });                             
            }
        }

        [HttpGet("GetRewardPointMonthlySummary")]
        public async Task<IActionResult> GetRewardPointMonthlySummary(int? noOfMonths = 3)
        {
            try
            {
                var result = await _rewardService.GetRewardPointMonthlySummary(noOfMonths);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return StatusCode(500, new {
                        Successful = false,
                        ErrorMessage = ex.Message
                    });                             
            }
        }

        [HttpGet("GetRewardPoints")]
        public async Task<IActionResult> GetRewardPoints(decimal price)
        {
            try
            {
                var result = await _rewardService.GetRewardPoints(price);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return StatusCode(500, new {
                        Successful = false,
                        ErrorMessage = ex.Message
                    });                             
            }
        }
    }
}
