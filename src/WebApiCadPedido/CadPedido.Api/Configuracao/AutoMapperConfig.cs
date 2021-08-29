using AutoMapper;
using CadPedido.Api.ApiModel;
using CadPedido.Business.Models;

namespace CadPedido.Api.Configurations
{
  public class AutoMapperConfig : Profile 
  {
    public AutoMapperConfig()
    {
      //TODO: CONFIGURAR  O AUTOMAPPER      
      CreateMap<Cliente,ClienteApiModel>().ReverseMap();
      CreateMap<Pedido, PedidoApiModel>().ReverseMap();
      CreateMap<PedidoItem, PedidoItemApiModel>().ReverseMap();
      CreateMap<Produto, ProdutoApiModel>().ReverseMap(); 
           
      // Mapeando relações entre entidades
      CreateMap<PedidoApiModel, Pedido>()
         .ForMember(dest => dest.PedidoItem, opt => opt.MapFrom(src => src.PedidoItem)).ReverseMap();

    }
  }
}
