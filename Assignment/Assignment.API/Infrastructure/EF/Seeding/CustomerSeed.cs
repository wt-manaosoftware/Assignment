using Assignment.API.Core.DomainModels;

namespace Assignment.API.Infrastructure.EF.Seeding {

    public class CustomerSeed {

        public static void Seed(DBContext context) {

            for (var i = 1; i <= 3; i++) {

                var item = new Customer() {
                    Name = $"Customer-{i}",
                    ContactEmail = $"customer-{i}@customer.com",
                    MobileNo = $"012345{i}"
                };

                context.Customers.Add(item);
            }

            context.SaveChanges();
        }
    }
}
