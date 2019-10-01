using Assignment.API.Core.DomainModels;
using Assignment.API.Core.Helpers.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.API.Infrastructure.EF.Seeding {
    public class TransactionSeed {

        private static string[] CurrencyCode = { "USD", "CNY" };

        public static void Seed(DBContext context) {

            Array values = Enum.GetValues(typeof(TransactionStatus));

            var rand = new Random();

            for (var i = 0; i < 10; i++) {

                var item = new Transaction() {
                    TransactionDate = DateTimeOffset.Now,
                    CurrencyCode = CurrencyCode[i % 2],
                    Amount = (decimal)((rand.Next() % 100) +  rand.NextDouble()),
                    Status = (TransactionStatus)values.GetValue((i % 3)),
                    CustomerId = (int)((i % 2) + 1)
                };

                context.Transactions.Add(item);
            }

            context.SaveChanges();

        }
    }
}
