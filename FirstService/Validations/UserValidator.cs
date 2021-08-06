using FluentValidation;
using ServicesDTO;
using System;

namespace FirstService.Validations
{
    public class UserValidator : AbstractValidator<UserDTO>
	{
		public UserValidator()
		{
			RuleFor(x => x.UserId).NotEmpty();
			RuleFor(x => x.FirstName).NotEmpty();
			RuleFor(x => x.LastName).NotEmpty();
			RuleFor(x => x.Email).EmailAddress();
			RuleFor(x => x.MobilePhoneNumber).NotEmpty();
			RuleFor(x => x.OrganizationId).NotEmpty();

		}

        private object RuleFor(Func<object, object> p)
        {
            throw new NotImplementedException();
        }
    }
}
