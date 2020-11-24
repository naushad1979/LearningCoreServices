using FluentValidation;
using System.Threading;

namespace Account.Api.Models.Validators
{
	public class UserRegistrationValidator : AbstractValidator<UserRegistration>
	{
		private const string emailRegx = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
		 @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
		 @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
		public UserRegistrationValidator()
		{
			RuleFor(x => x.Email)
				.NotEmpty().WithMessage("Email address is required.")
				.EmailAddress().WithMessage("A valid email address is required.")
				.Matches(emailRegx).WithMessage("A valid email address is required.");
			RuleFor(x => x.Name).NotEmpty().WithMessage("Name is mandatory!");
			RuleFor(x => x.Password).NotEmpty().WithMessage("Password is mandatory!");
			RuleFor(x => x.Mobile).NotEmpty().WithMessage("Mobile number is mandatory!");
		}
	}
}
