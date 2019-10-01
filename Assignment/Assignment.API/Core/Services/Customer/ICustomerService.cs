using Assignment.API.Core.DomainModels;
using System.Threading.Tasks;

namespace Assignment.API.Infrastructure.EF.Services {
    public interface ICustomerService {

        Task<Customer> GetCustomerWith5TransactionsById(long id);
        Task<Customer> GetCustomerWith5TransactionsByEmail(string email);
        Task<Customer> GetCustomerWith5TransactionsByEmailAndId(string email, long id);
    }
}
