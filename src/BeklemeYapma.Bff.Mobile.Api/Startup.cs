using BeklemeYapma.Bff.Core.Data;
using BeklemeYapma.Bff.Core.Data.Implementations;
using BeklemeYapma.Bff.Core.Infrastructure.Mapper;
using BeklemeYapma.Bff.Mobile.Api.Filters;
using BeklemeYapma.Bff.Mobile.Api.Services;
using BeklemeYapma.Bff.Mobile.Api.Services.Implementations;
using BeklemeYapma.Bff.Mobile.Api.Infrastructure.Mapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NLog.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;
using System.IO.Compression;
using AutoMapper;

namespace BeklemeYapma.Bff.Mobile.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                    .AddMvcOptions(o =>
                    {
                        o.InputFormatters.RemoveType<XmlDataContractSerializerInputFormatter>();
                        o.InputFormatters.RemoveType<XmlSerializerInputFormatter>();

                        o.OutputFormatters.RemoveType<HttpNoContentOutputFormatter>();
                        o.OutputFormatters.RemoveType<StreamOutputFormatter>();
                        o.OutputFormatters.RemoveType<StringOutputFormatter>();
                        o.OutputFormatters.RemoveType<XmlDataContractSerializerOutputFormatter>();
                        o.OutputFormatters.RemoveType<XmlSerializerOutputFormatter>();

                        o.Filters.Add<ValidateModelStateFilter>();
                        o.Filters.Add<GlobalExceptionFilter>();
                    })
                    .AddJsonOptions(o =>
                    {
                        o.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                        o.SerializerSettings.Formatting = Formatting.Indented;
                        o.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
                        o.SerializerSettings.DateParseHandling = DateParseHandling.DateTime;
                        o.SerializerSettings.NullValueHandling = NullValueHandling.Include;
                    });

            services.AddCors();
            services.Configure<GzipCompressionProviderOptions>(options => options.Level = CompressionLevel.Optimal);
            services.AddResponseCompression();

            //Services
            services.AddSingleton<IRestaurantsService, RestaurantsService>();

            //Data
            services.AddSingleton<IRestaurantsRepository, RestaurantsRepository>();

            //Mapper
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(typeof(MobileMapperConfiguration));
            });
            AutoMapperConfiguration.Init(config);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "BeklemeYapma.Bff.Mobile.Api", Version = "v1" });
                c.DescribeAllEnumsAsStrings();
                c.DescribeStringEnumsInCamelCase();
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            loggerFactory.AddNLog();
            NLog.LogManager.LoadConfiguration("nlog.config");

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "BeklemeYapma.Bff.Mobile.Api");
                c.RoutePrefix = string.Empty;
            });

            app.UseResponseCompression();
            app.UseCors(
                options => options.AllowAnyMethod()
                                  .AllowAnyOrigin()
                                  .AllowAnyHeader()
            );

            app.UseMvc();
        }
    }
}