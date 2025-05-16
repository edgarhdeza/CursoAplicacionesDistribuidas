using AutoMapper;
using DWShop.Application.Features.Identity.Commands.Register;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWShop.Application.Mappings
{
	public class IdentityProfile : Profile
	{
		public IdentityProfile() 
		{
			CreateMap<RegisterUserCommand, IdentityUser>().ReverseMap();
		}
	}
}
