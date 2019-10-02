using Assignment.API.Core.Services.Validation;
using Xunit;

namespace Assignment.Test.UnitTests.Validations {

    public class CustomerValidationTest {

        [Fact]
        public void GetCustomerById_ShouldAllow_PositiveInteger() {
            var id = 1;
            var validate = new CustomerValidationService();

            var result = validate.ValidateId(id);

            Assert.True(result.Success);
        }

        [Fact]
        public void GetCustomerById_ShouldNotAllow_Zero() {
            var id = 0;
            var validate = new CustomerValidationService();

            var result = validate.ValidateId(id);

            Assert.False(result.Success);
        }

        [Fact]
        public void GetCustomerById_ShouldNotAllow_NegativeInteger() {
            var id = -1;
            var validate = new CustomerValidationService();

            var result = validate.ValidateId(id);

            Assert.False(result.Success);
        }

        [Fact]
        public void GetCustomerByEmail_ShouldAllow_ValidEmail() {
            var email1 = "customer@customer";
            var email2 = "customer@customer.com";
            var validate = new CustomerValidationService();

            var result1 = validate.ValidateEmail(email1);
            var result2 = validate.ValidateEmail(email2);

            Assert.True(result1.Success);
            Assert.True(result2.Success);
        }

        [Fact]
        public void GetCustomerByEmail_ShouldNotAllow_EmptyString() {
            var email = string.Empty;
            var validate = new CustomerValidationService();

            var result = validate.ValidateEmail(email);

            Assert.False(result.Success);
        }

        [Fact]
        public void GetCustomerByEmail_ShouldNotAllow_InvalidEmail() {
            var email = "Hello, World";
            var validate = new CustomerValidationService();

            var result = validate.ValidateEmail(email);

            Assert.False(result.Success);
        }

        [Fact]
        public void GetCustomerByEmailAndId_ShouldAllow_ValidEmailAndId() {
            var email = "customer@customer.com";
            var id = 1;
            var validate = new CustomerValidationService();

            var result = validate.ValidateEmailAndId(email, id);

            Assert.True(result.Success);
        }

        [Fact]
        public void GetCustomerByEmailAndId_ShouldNotAllow_ValidEmailAndInvalidId() {
            var email = "customer@customer.com";
            var id = 0;
            var validate = new CustomerValidationService();

            var result = validate.ValidateEmailAndId(email, id);

            Assert.False(result.Success);
        }

        [Fact]
        public void GetCustomerByEmailAndId_ShouldNotAllow_InvalidEmailAndValidId() {
            var email = "customer @ customer.com";
            var id = 2;
            var validate = new CustomerValidationService();

            var result = validate.ValidateEmailAndId(email, id);

            Assert.False(result.Success);
        }

        [Fact]
        public void GetCustomerByEmailAndId_ShouldNotAllow_InvalidEmailAndId() {
            var email = "not correct";
            var id = -5;
            var validate = new CustomerValidationService();

            var result = validate.ValidateEmailAndId(email, id);

            Assert.False(result.Success);
        }

        [Fact]
        public void GetCustomerByEmailAndId_ShouldNotAllow_EmptyEmailAndId() {
            var email = default(string);
            var id = default(int);
            var validate = new CustomerValidationService();

            var result = validate.ValidateEmailAndId(email, id);

            Assert.False(result.Success);
        }

        [Fact]
        public void GetCustomerByEmailAndId_ShouldReturnNoInquiryCriteria_EmptyEmailAndId() {
            var email = default(string);
            var id = default(int);
            var validate = new CustomerValidationService();

            var result = validate.ValidateEmailAndId(email, id);

            Assert.Equal("No inquiry criteria", result.Message);
        }

    }
}
