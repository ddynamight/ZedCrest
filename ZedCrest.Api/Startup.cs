using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using ZedCrest.Data.Interfaces;
using ZedCrest.Data.Repositories;

namespace ZedCrest.Api
{
     public class Startup
     {
          public Startup(IConfiguration configuration)
          {
               Configuration = configuration;
          }

          public IConfiguration Configuration { get; }

          // This method gets called by the runtime. Use this method to add services to the container.
          public void ConfigureServices(IServiceCollection services)
          {
               services.AddScoped<IValueCheckerRepository, ValueCheckerRepository>();


               services.AddControllers();

               services.AddSwaggerGen(c =>
               {
                    c.SwaggerDoc("v1", new OpenApiInfo
                    {
                         Version = "v1",
                         Title = "ZedCrest API",
                         Description = "This is the ZedCrest API",
                         TermsOfService = new Uri("https://wwww.zedcrest.com/terms-of-service"),
                         License = new OpenApiLicense
                         {
                              Name = "ZedCrest License",
                              Url = new Uri("https://www.zedcrest.com/license")
                         },
                         Contact = new OpenApiContact
                         {
                              Email = "ismail@ismailumar.com.ng",
                              Name = "Ismail Umar",
                              Url = new Uri("https://www.ismailumar.com.ng"),
                         },
                    });

                    // Set the comments path for the Swagger JSON and UI.
                    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                    c.IncludeXmlComments(xmlPath, false);
               });

               services.Configure<ApiBehaviorOptions>(options =>
               {
                    options.SuppressConsumesConstraintForFormFileParameters = false;
                    options.SuppressInferBindingSourcesForParameters = false;
                    options.SuppressModelStateInvalidFilter = false;
               });
          }

          // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
          public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
          {
               if (env.IsDevelopment())
               {
                    app.UseDeveloperExceptionPage();
               }
               else
               {
                    app.UseExceptionHandler(appBuilder =>
                    {
                         appBuilder.Run(async context =>
                         {
                              var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();
                              if (exceptionHandlerFeature != null)
                              {
                                   var logger = loggerFactory.CreateLogger("Global exception logger");
                                   logger.LogError(500,
                                        exceptionHandlerFeature.Error,
                                        exceptionHandlerFeature.Error.Message);
                              }
                              context.Response.StatusCode = 500;
                              await context.Response.WriteAsync("An unexpected fault happened. Try again later.").ConfigureAwait(false);
                         });
                    });
               }


               app.UseSwagger();

               if (!env.IsProduction())
               {
                    app.UseSwaggerUI(c =>
                    {
                         c.SwaggerEndpoint("/swagger/v1/swagger.json", "ZEDCREST API V1");
                         c.RoutePrefix = string.Empty;
                    });
               }

               app.UseHttpsRedirection();
               app.UseRouting();
               app.UseAuthorization();
               app.UseEndpoints(endpoints =>
               {
                    endpoints.MapControllers();
               });
          }
     }
}
