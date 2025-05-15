using DWShop.Application.Features.Basket.Commands.Create;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWShop.Application.Validations.Basket.Command.Create
{
	public class CreateBasketCommandValidator : AbstractValidator<CreateBasketCommand>
	{
		public CreateBasketCommandValidator() 
		{
			RuleFor(x => x.TotalPrice).GreaterThan(0);
		}
	}
}
