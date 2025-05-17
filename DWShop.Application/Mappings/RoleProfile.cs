using AutoMapper;
using DWShop.Application.Features.Identity.Commands.AddRole;
using DWShop.Application.Features.Identity.Commands.GetRoles;
using DWShop.Application.Features.Identity.Commands.Roles;
using DWShop.Application.Responses.Identity;
using Microsoft.AspNetCore.Identity;

namespace DWShop.Application.Mappings
{
	public class RoleProfile : Profile
	{
		public RoleProfile()
		{
			CreateMap<RegisterRoleCommand, IdentityRole>().ReverseMap();

			CreateMap<RoleResponse, IdentityRole>().ReverseMap();

			CreateMap<AddRoleCommand, IdentityRole>().ReverseMap();

			CreateMap<GetRolesCommand, IdentityRole>().ReverseMap();
		}
	}
}
