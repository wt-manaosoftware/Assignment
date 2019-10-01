using Assignment.API.Core.DomainModels;
using System.Threading.Tasks;

namespace Assignment.API.Infrastructure.EF.Services {
    public interface ICustomerService {

        Task<Customer> GetCustomerByIdWithTransaction(int Id);
        Task<Customer> GetCustomerByEmailWithTransaction(string email);
        Task<Customer> GetCustomerByEmailAndIdWithTransaction(string email, int id);
    }
}
