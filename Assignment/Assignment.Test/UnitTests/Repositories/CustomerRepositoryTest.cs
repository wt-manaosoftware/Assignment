using Assignment.API.Core.DomainModels;
using Assignment.API.Infrastructure.EF.Repositories;
using Assignment.API.Infrastructure.EF.Services;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Assignment.Test.UnitTests.Repositories {
    public class CustomerRepositoryTest {

        [Fact]
        public async Task GetCustomerById_ShouldReturnCustomer_WhenGetByExistId() {
            var id = 1;
            var customer = new Customer();
            var mockCustomerRepository = new Mock<ICustomerRepository>();
            mockCustomerRepository.Setup(r => r.GetCustomerWithTransactionById(id)).ReturnsAsync(customer);
            var customerService = new CustomerService(mockCustomerRepository.Object);

            var result = await customerService.GetCustomerWith5TransactionsById(id);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetCustomerByEmail_ShouldReturnCustomer_WhenGetByExistEmail() {
            var email = "customer@customer.com";
            var customer = new Customer();
            var mockCustomerRepository = new Mock<ICustomerRepository>();
            mockCustomerRepository.Setup(r => r.GetCustomerWithTransactionByEmail(email)).ReturnsAsync(customer);
            var customerService = new CustomerService(mockCustomerRepository.Object);

            var result = await customerService.GetCustomerWith5TransactionsByEmail(email);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetCustomerByEmailAndId_ShouldReturnCustomer_WhenGetByExistEmailAndId() {
            var email = "valid@email";
            var id = 2;
            var customer = new Customer();
            var mockCustomerRepository = new Mock<ICustomerRepository>();
            mockCustomerRepository.Setup(r => r.GetCustomerWithTransactionByEmailAndId(email, id)).ReturnsAsync(customer);
            var customerService = new CustomerService(mockCustomerRepository.Object);

            var result = await customerService.GetCustomerWith5TransactionsByEmailAndId(email, id);

            Assert.NotNull(result);
        }

    }
}
