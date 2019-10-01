using Assignment.API.Core.DomainModels;
using System;
using System.Threading.Tasks;

namespace Assignment.API.Infrastructure.EF.Repositories {

    public class CustomerRepository : ICustomerRepository {

        public Task<Customer> GetCustomerWithTransactionByEmail(string email) {
            throw new NotImplementedException();
        }

        public Task<Customer> GetCustomerWithTransactionByEmailAndId(string email, int id) {
            throw new NotImplementedException();
        }

        public Task<Customer> GetCustomerWithTransactionById(int id) {
            throw new NotImplementedException();
        }
    }
}
