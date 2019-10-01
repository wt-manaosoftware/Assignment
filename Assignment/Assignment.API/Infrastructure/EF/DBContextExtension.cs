using Assignment.API.Infrastructure.EF.Seeding;
using System.Linq;

namespace Assignment.API.Infrastructure.EF {

    public static class DBContextExtension {

        public static void EnsureSeeded(this DBContext context) {
            if (!context.Customers.Any()) {
                CustomerSeed.Seed(context);
                TransactionSeed.Seed(context);
            }
        }

    }
}
