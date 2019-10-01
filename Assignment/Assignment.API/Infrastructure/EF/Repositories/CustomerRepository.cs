using Assignment.API.Core.DomainModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Assignment.API.Infrastructure.EF.Repositories {

    public class CustomerRepository : ICustomerRepository {

        private DBContext context { get; set; }

        public CustomerRepository(DBContext context) {
            this.context = context;
        }

        public async Task<Customer> GetCustomerWithTransactionByEmail(string email) {
            return await context.Customers.Include(x => x.Transactions).SingleOrDefaultAsync(x => x.ContactEmail == email);
        }

        public async Task<Customer> GetCustomerWithTransactionByEmailAndId(string email, long id) {
            return await context.Customers.Include(x => x.Transactions).SingleOrDefaultAsync(x => x.ContactEmail == email && x.Id == id);
        }

        public async Task<Customer> GetCustomerWithTransactionById(long id) {
            return await context.Customers.Include(x => x.Transactions).SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
