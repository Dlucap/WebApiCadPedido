using CadPedido.Api.Extensions;
using CadPedido.Business.Models;
using CadPedido.Data.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CadPedido.Api.Configurations
{
  public static class DependecyInjectionConfig
  {
    public static IServiceCollection ResolveDependecies(this IServiceCollection services)
    {
      #region Repository     
      services.AddScoped<ApiDbContext>();
      //services.AddScoped<IProdutoRepository, ProdutoRepository>();
      //services.AddScoped<IClienteRepository, ClienteRepository>();
      //services.AddScoped<IPedidoRepository, PedidoRepository>();
      //services.AddScoped<IPedidoItemRepository, PedidoItemRepository>();

      #endregion Repository

      #region Services
      //services.AddScoped<IClienteService, ClienteService>();
      //services.AddScoped<IPedidoService, PedidoService>();
      //services.AddScoped<IPedidoItemService, PedidoItemService>();
      //services.AddScoped<IProdutoService, ProdutoService>();
      #endregion Services

      services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
      services.AddScoped<IUser, AspNetUser>();

      //services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

      return services;
    }
  }
}
