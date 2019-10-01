using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment.API.Core.Models.DTO;
using Assignment.API.Core.Models.Results;
using Assignment.API.Infrastructure.EF.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.API.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private ICustomerService customerService { get; }
        public CustomerController(ICustomerService customerService) {
            this.customerService = customerService;
        }

        [HttpGet("GetCustomerById")]
        public async Task<ActionResult<Result<CustomerDTO>>> GetCustomerById([FromQuery] long customerId) {

            var customer = await customerService.GetCustomerWith5TransactionsById(customerId);

            if (customer != null) {
                var DTO = customer.ToDTO();
                var result = Result<CustomerDTO>.ResultSuccess(DTO);

                return result;
            }

            return NotFound();
        }

        [HttpGet("GetCustomerByEmail")]
        public async Task<ActionResult<Result<CustomerDTO>>> GetCustomerByEmail([FromQuery] string email) {

            var customer = await customerService.GetCustomerWith5TransactionsByEmail(email);

            if (customer != null) {
                var DTO = customer.ToDTO();
                var result = Result<CustomerDTO>.ResultSuccess(DTO);

                return result;
            }

            return NotFound();
        }

        [HttpGet("GetCustomerByEmailAndId")]
        public async Task<ActionResult<Result<CustomerDTO>>> GetCustomerByEmailAndId([FromQuery] string email, long id) {

            var customer = await customerService.GetCustomerWith5TransactionsByEmailAndId(email, id);

            if (customer != null) {
                var DTO = customer.ToDTO();
                var result = Result<CustomerDTO>.ResultSuccess(DTO);

                return result;
            }

            return NotFound();
        }

    }
}