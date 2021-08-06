using FirstService.Validations;
using ServicesDTO;
using System.Linq;
using Xunit;

namespace FirstService.Tests
{
    public class FirstService_UserValidation
    {
        [Fact]
        public void HasError_UserIdIsNull_ReturnTrue()
        {
            var user = new UserDTO();
            var validator = new UserValidator();
            var hasError = validator.Validate(user).Errors.Any(o => o.PropertyName == "UserId");
            Assert.True(hasError);
        }
        [Fact]
        public void HasError_FirstNameIsEmpty_ReturnTrue()
        {
            var user = new UserDTO()
            {
                FirstName = string.Empty
            };
            var validator = new UserValidator();
            var hasError = validator.Validate(user).Errors.Any(o => o.PropertyName == "FirstName");
            Assert.True(hasError);
        }

        [Fact]
        public void HasError_LastNameIsEmpty_ReturnTrue()
        {
            var user = new UserDTO()
            {
                LastName = string.Empty
            };
            var validator = new UserValidator();
            var hasError = validator.Validate(user).Errors.Any(o => o.PropertyName == "LastName");
            Assert.True(hasError);
        }

        [Fact]
        public void HasError_SecondNameIsEmpty_ReturnFalse()
        {
            var user = new UserDTO()
            {
                SecondName = string.Empty
            };
            var validator = new UserValidator();
            var hasError = validator.Validate(user).Errors.Any(o => o.PropertyName == "SecondName");
            Assert.False(hasError);
        }

        [Fact]
        public void HasError_MobilePhoneNumberIsEmpty_ReturnTrue()
        {
            var user = new UserDTO()
            {
                MobilePhoneNumber = string.Empty
            };
            var validator = new UserValidator();
            var hasError = validator.Validate(user).Errors.Any(o => o.PropertyName == "MobilePhoneNumber");
            Assert.True(hasError);
        }

        [Fact]
        public void HasError_EmailIsInvalid_ReturnTrue()
        {
            var user = new UserDTO()
            {
                Email = string.Empty
            };
            var validator = new UserValidator();
            var hasError = validator.Validate(user).Errors.Any(o => o.PropertyName == "Email");
            Assert.True(hasError);
        }
    }
}
