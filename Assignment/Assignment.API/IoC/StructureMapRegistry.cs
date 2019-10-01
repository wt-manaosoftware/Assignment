using Assignment.API.Infrastructure.EF.Repositories;
using Assignment.API.Infrastructure.EF.Services;
using StructureMap;

namespace Assignment.API.IoC {
    public class StructureMapRegistry : Registry {

        public StructureMapRegistry() {

            For<ICustomerRepository>().Use<CustomerRepository>();
            For<ICustomerService>().Use<CustomerService>();

        }
    }
}
