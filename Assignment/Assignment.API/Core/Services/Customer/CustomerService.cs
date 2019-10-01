using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment.API.Core.DomainModels;
using Assignment.API.Infrastructure.EF.Repositories;

namespace Assignment.API.Infrastructure.EF.Services {

    public class CustomerService : ICustomerService {

        private ICustomerRepository customerRepository { get; }

        public CustomerService(ICustomerRepository customerRepository) {
            this.customerRepository = customerRepository;
        }

        public async Task<Customer> GetCustomerWith5TransactionsById(long id) {
            Customer customer = await customerRepository.GetCustomerWithTransactionById(id);

            if (customer != null) {
                customer.Transactions = customer.Transactions.OrderByDescending(x => x.TransactionDate).Take(5).ToList();
            }

            return customer;
        }

        public async Task<Customer> GetCustomerWith5TransactionsByEmail(string email) {
            Customer customer = await customerRepository.GetCustomerWithTransactionByEmail(email);

            if (customer != null) {
                customer.Transactions = customer.Transactions.OrderByDescending(x => x.TransactionDate).Take(5).ToList();
            }

            return customer;
        }

        public async Task<Customer> GetCustomerWith5TransactionsByEmailAndId(string email, long id) {
            Customer customer = await customerRepository.GetCustomerWithTransactionByEmailAndId(email, id);

            if (customer != null) {
                customer.Transactions = customer.Transactions.OrderByDescending(x => x.TransactionDate).Take(5).ToList();
            }

            return customer;
        }

    }
}
