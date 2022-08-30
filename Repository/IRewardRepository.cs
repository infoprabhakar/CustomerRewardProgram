using Rewards.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public interface IRewardRepository
    {
        List<Customer> GetCustomerList();
        List<Transaction> GetTransactionList();
    }
}
