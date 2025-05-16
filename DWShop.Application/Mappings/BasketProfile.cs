using AutoMapper;
using DWShop.Application.Features.Basket.Commands.Create;
using DWShop.Application.Responses.Basket;
using DWShop.Domain.Entities;

namespace DWShop.Application.Mappings
{
	public class BasketProfile : Profile
	{
		public BasketProfile()
		{
			CreateMap<Basket, CreateBasketCommand>().ReverseMap();

			CreateMap<Basket, BasketResponse>().ReverseMap();
		}
	}
}
