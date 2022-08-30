using System;
using System.Collections.Generic;
using System.Text;

namespace Rewards.Models
{
    public class CustomerwiseRewardSummary
    {       
        public string MonthYear { get; set; }        
        public string CustomerName { get; set; }        
        public decimal? RewardPoints { get; set; }        
    }
    public class TransactionSummary
    {
        public string MonthYear { get; set; }
        public DateTime TransactionDate { get; set; }
        public string CustomerName { get; set; }
        public decimal Price { get; set; }
        public decimal? RewardPoints { get; set; }
    }

    public class RewardSummaryReport
    {
        public List<CustomerwiseRewardSummary> CustomerwiseRewardSummaryDetail { get; set; }
        public List<TransactionSummary> TransactionSummaryDetail { get; set; }

    }
}
