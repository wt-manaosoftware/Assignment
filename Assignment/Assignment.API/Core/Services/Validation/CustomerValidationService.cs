using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Assignment.API.Core.Models.Results;

namespace Assignment.API.Core.Services.Validation {
    public class CustomerValidationService : ICustomerValidationService {

        public ValidationResult ValidateEmail(string Email) {
            if (string.IsNullOrEmpty(Email) || !IsValidEmail(Email))
                return new ValidationResult(false, "Email", "Invalid Email");

            return new ValidationResult();
        }

        public ValidationResult ValidateEmailAndId(string Email, long Id) {
            var validateId = ValidateId(Id);
            var validateEmail = ValidateEmail(Email);

            if (!validateId.Success) {
                return validateId;
            } else if (!validateEmail.Success) {
                return validateEmail;
            }

            return new ValidationResult();
        }

        public ValidationResult ValidateId(long Id) {
            if (Id < 1 || Id.ToString().Length > 10)
                return new ValidationResult(false, "Id", "Invalid Customer ID");

            return new ValidationResult();
        }

        public ValidationResult ValidateIsEmptyEmailAndId(string Email, long Id) {
            var validateId = ValidateId(Id);
            var validateEmail = ValidateEmail(Email);

            if (string.IsNullOrEmpty(Email) && Id == 0)
                return new ValidationResult(false, "Id", "No inquiry criteria");


            return new ValidationResult();
        }

        private bool IsValidEmail(string Email) {
            try {
                MailAddress email = new MailAddress(Email);
                return email.Address == Email;
            } catch (FormatException) {
                return false;
            }
        }
    }

}
