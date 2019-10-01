using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment.API.Core.Models.DTO;
using Assignment.API.Core.Models.Results;
using Assignment.API.Core.Services.Validation;
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
        private ICustomerValidationService customerValidationService { get; }

        public CustomerController(ICustomerService customerService, ICustomerValidationService customerValidationService) {
            this.customerService = customerService;
            this.customerValidationService = customerValidationService;
        }

        [HttpGet("GetCustomerById")]
        public async Task<ActionResult<Result<CustomerDTO>>> GetCustomerById([FromQuery] long Id) {

            var validateResult = customerValidationService.ValidateId(Id);

            if (!validateResult.Success) {
                var errorResult = Result<CustomerDTO>.ResultFail(validateResult);
                return BadRequest(errorResult);
            }

            var customer = await customerService.GetCustomerWith5TransactionsById(Id);

            if (customer != null) {
                var DTO = customer.ToDTO();
                var result = Result<CustomerDTO>.ResultSuccess(DTO);

                return result;
            }

            return NotFound();
        }

        [HttpGet("GetCustomerByEmail")]
        public async Task<ActionResult<Result<CustomerDTO>>> GetCustomerByEmail([FromQuery] string Email) {

            var validateResult = customerValidationService.ValidateEmail(Email);

            if (!validateResult.Success) {
                var errorResult = Result<CustomerDTO>.ResultFail(validateResult);
                return BadRequest(errorResult);
            }

            var customer = await customerService.GetCustomerWith5TransactionsByEmail(Email);

            if (customer != null) {
                var DTO = customer.ToDTO();
                var result = Result<CustomerDTO>.ResultSuccess(DTO);

                return result;
            }

            return NotFound();
        }

        [HttpGet("GetCustomerByEmailAndId")]
        public async Task<ActionResult<Result<CustomerDTO>>> GetCustomerByEmailAndId([FromQuery] string Email, long Id) {

            var validateResult = customerValidationService.ValidateIsEmptyEmailAndId(Email, Id);

            if (!validateResult.Success) {
                var errorResult = Result<CustomerDTO>.ResultFail(validateResult);
                return BadRequest(errorResult);
            }

            validateResult = customerValidationService.ValidateEmailAndId(Email, Id);

            if (!validateResult.Success) {
                var errorResult = Result<CustomerDTO>.ResultFail(validateResult);
                return BadRequest(errorResult);
            }

            var customer = await customerService.GetCustomerWith5TransactionsByEmailAndId(Email, Id);

            if (customer != null) {
                var DTO = customer.ToDTO();
                var result = Result<CustomerDTO>.ResultSuccess(DTO);

                return result;
            }

            return NotFound();
        }

    }
}