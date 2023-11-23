using CBTeam.Application.Contracts;
using FluentValidation;


namespace CBTeam.Application.Validators
{
	public class GetUserLisValidator : AbstractValidator<GetUserListRequest>
	{
		public GetUserLisValidator() 
		{
			RuleFor(r => r.Query)
				.NotEmpty()
				.NotNull()
				.NotEqual("xxx")
				.EmailAddress()
				.WithMessage("La query no es valida");
		}	
	}
}
