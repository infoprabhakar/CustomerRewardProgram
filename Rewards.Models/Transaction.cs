using System;

namespace Rewards.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal? Reward { get; set; }
        public int CustomerId { get; set; }        
    }
}
