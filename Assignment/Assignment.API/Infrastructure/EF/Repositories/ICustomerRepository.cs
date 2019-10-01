using Assignment.API.Core.DomainModels;
using System.Threading.Tasks;

namespace Assignment.API.Infrastructure.EF.Repositories {

    public interface ICustomerRepository {

        Task<Customer> GetCustomerWithTransactionById(int id);
        Task<Customer> GetCustomerWithTransactionByEmail(string email);
        Task<Customer> GetCustomerWithTransactionByEmailAndId(string email, int id);
    }
}
