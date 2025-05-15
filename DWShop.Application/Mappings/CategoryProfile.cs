using AutoMapper;
using DWShop.Application.Features.Category.Commands.Create;
using DWShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWShop.Application.Mappings
{
	internal class CategoryProfile : Profile
	{
		public CategoryProfile()
		{
			CreateMap<Category, CreateCategoryCommand>().ReverseMap();
		}
	}
}
