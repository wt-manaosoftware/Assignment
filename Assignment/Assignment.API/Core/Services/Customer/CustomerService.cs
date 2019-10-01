using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment.API.Core.DomainModels;

namespace Assignment.API.Infrastructure.EF.Services {

    public class CustomerService : ICustomerService {

        public Task<Customer> GetCustomerByEmailAndIdWithTransaction(string email, int id) {
            throw new NotImplementedException();
        }

        public Task<Customer> GetCustomerByEmailWithTransaction(string email) {
            throw new NotImplementedException();
        }

        public Task<Customer> GetCustomerByIdWithTransaction(int Id) {
            throw new NotImplementedException();
        }
    }
}
