using Assignment.API.Infrastructure.EF.Repositories;
using StructureMap;

namespace Assignment.API.IoC {
    public class StructureMapRegistry : Registry {

        public StructureMapRegistry() {

            For<ICustomerRepository>().Use<CustomerRepository>();

        }
    }
}
