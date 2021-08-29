using CadPedido.Api.Configuracao;
using CadPedido.Api.Configurations;
using CadPedido.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CadPedido.Api
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public IServiceCollection _services { get; set; }

    public void ConfigureServices(IServiceCollection services)
    {
      var stringSqlconnection = Configuration.GetConnectionString("CadPedidoApi");

      services.AddDbContext<ApiDbContext>(options =>
       options.UseSqlServer(stringSqlconnection));

      services.AddIdentityConfig(Configuration);

      services.AddAutoMapper(typeof(Startup));

      services.WebApiConfig();

      services.AddSwaggerConfig();

      services.AddControllers();

      services.ResolveDependecies();

      _services = services;

    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env/*, IApiVersionDescriptionProvider provider*/)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApiCadPedido v1"));
        app.UseDeveloperExceptionPage();
      }
     
      app.UseMvcConfig();
     // app.UseSwaggerConfig(provider);
      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
