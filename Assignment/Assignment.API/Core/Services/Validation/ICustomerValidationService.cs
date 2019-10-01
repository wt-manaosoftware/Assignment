using Assignment.API.Core.Models.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.API.Core.Services.Validation {

    public interface ICustomerValidationService {

        ValidationResult ValidateId(long Id);
        ValidationResult ValidateEmail(string Email);
        ValidationResult ValidateEmailAndId(string Email, long Id);
    }
}
