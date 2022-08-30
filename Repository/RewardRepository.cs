using Rewards.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RewardRepository:IRewardRepository
    {        
        public List<Customer> GetCustomerList()
        {
            return BuildCustomerList();
        }

        public List<Transaction> GetTransactionList()
        {                        
            return BuildTransactionList();
        }

        private List<Customer> BuildCustomerList()
        {
            return new List<Customer>()
            {
                new Customer{CustomerId = 1, FirstName ="John", LastName="David"},
                new Customer{CustomerId = 2, FirstName ="Kevin", LastName="Thomas"},
                new Customer{CustomerId = 3, FirstName ="Matt", LastName="Wilson"},
                new Customer{CustomerId = 4, FirstName ="Tanya", LastName="David"}
            };
        }
        private List<Transaction> BuildTransactionList()
        {
            return new List<Transaction>()
            {
                new Transaction{ CustomerId = 1, Price = 150, Id = 1, TransactionDate = Convert.ToDateTime("05/09/2022")},
                new Transaction{ CustomerId = 1, Price = 50, Id = 2, TransactionDate = Convert.ToDateTime("05/15/2022")},
                new Transaction{ CustomerId = 1, Price = 20, Id = 3, TransactionDate = Convert.ToDateTime("05/29/2022")},
                new Transaction{ CustomerId = 1, Price = 10, Id = 4, TransactionDate = Convert.ToDateTime("05/19/2022")},
                new Transaction{ CustomerId = 1, Price = 200, Id = 5, TransactionDate = Convert.ToDateTime("06/05/2022")},
                new Transaction{ CustomerId = 1, Price = 50, Id = 6, TransactionDate = Convert.ToDateTime("06/09/2022")},
                new Transaction{ CustomerId = 1, Price = 110, Id = 7, TransactionDate = Convert.ToDateTime("07/02/2022")},
                new Transaction{ CustomerId = 2, Price = 50, Id = 8, TransactionDate = Convert.ToDateTime("06/19/2022")},
                new Transaction{ CustomerId = 3, Price = 50, Id = 9, TransactionDate = Convert.ToDateTime("06/15/2022")},
                new Transaction{ CustomerId = 3, Price = 150, Id = 10, TransactionDate = Convert.ToDateTime("07/10/2022")},
                new Transaction{ CustomerId = 2, Price = 60, Id = 11, TransactionDate = Convert.ToDateTime("06/09/2022")},
                new Transaction{ CustomerId = 3, Price = 70, Id = 12, TransactionDate = Convert.ToDateTime("07/11/2022")},
                new Transaction{ CustomerId = 2, Price = 10, Id = 13, TransactionDate = Convert.ToDateTime("05/29/2022")},
                new Transaction{ CustomerId = 2, Price = 5, Id = 14, TransactionDate = Convert.ToDateTime("05/28/2022")},
                new Transaction{ CustomerId = 2, Price = 150, Id = 15, TransactionDate = Convert.ToDateTime("05/06/2022")},
                new Transaction{ CustomerId = 2, Price = 80, Id = 16, TransactionDate = Convert.ToDateTime("05/03/2022")},
                new Transaction{ CustomerId = 2, Price = 10, Id = 17, TransactionDate = Convert.ToDateTime("06/11/2022")},
                new Transaction{ CustomerId = 2, Price = 90, Id = 18, TransactionDate = Convert.ToDateTime("07/15/2022")},
                new Transaction{ CustomerId = 3, Price = 50, Id = 19, TransactionDate = Convert.ToDateTime("07/18/2022")},
                new Transaction{ CustomerId = 3, Price = 10, Id = 20, TransactionDate = Convert.ToDateTime("07/25/2022")},
                new Transaction{ CustomerId = 3, Price = 60, Id = 21, TransactionDate = Convert.ToDateTime("05/22/2022")},
                new Transaction{ CustomerId = 3, Price = 80, Id = 22, TransactionDate = Convert.ToDateTime("06/21/2022")},
                new Transaction{ CustomerId = 3, Price = 150, Id = 23, TransactionDate = Convert.ToDateTime("06/19/2022")},
                new Transaction{ CustomerId = 4, Price = 150, Id = 24, TransactionDate = Convert.ToDateTime("07/01/2022")},
                new Transaction{ CustomerId = 4, Price = 50, Id = 25, TransactionDate = Convert.ToDateTime("05/09/2022")}
            };
        }
    }
}
