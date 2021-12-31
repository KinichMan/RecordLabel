using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RecordLabel.src.Shared.Domain.Bus.Command;
using RecordLabel.src.Shared.Infrastructure.Bus.Command;
using RecordLabel.src.Directory.Artist.Application.Command.UploadArtitst;
using RecordLabel.src.Shared.Infrastructure.Bus.Command.Middleware;

namespace RecordLabel
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


            services.AddScoped<UploadArtistsCommand>();
            services.AddScoped<UploadArtistsCommandHandler>();
            services.AddScoped<UploadArtistsUseCase>();

       
            services.AddScoped<ICommandBus, CommandBus>();
            services.AddScoped<TransactionMiddleware>();



            services.AddMvcCore().AddVersionedApiExplorer(o => o.GroupNameFormat = "'v'VVV");
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddApiVersioning(config =>
            {
                config.ReportApiVersions = true;
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.ApiVersionReader = new HeaderApiVersionReader("api-version");
            });

            services.AddSwaggerGen(
                options =>
                {

                    var provider = services.BuildServiceProvider()
                                        .GetRequiredService<IApiVersionDescriptionProvider>();

                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerDoc(
                            description.GroupName,
                            new Info()
                            {
                                Title = $"Sample API {description.ApiVersion}",
                                Version = description.ApiVersion.ToString()
                            });
                    }
                }
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApiVersionDescriptionProvider provider)
        {
            app.Use((context, next) =>
            {
                ICommandBus commandBus = context.RequestServices.GetRequiredService<ICommandBus>();
                ICommandHandler<ICommand> commandHandler = (ICommandHandler<ICommand>) context.RequestServices.GetRequiredService<UploadArtistsCommandHandler>();
                commandBus.AddMiddleware(context.RequestServices.GetRequiredService<TransactionMiddleware>());
                commandBus.Subscribe(commandHandler);

                return next();
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseAuthentication();
            app.UseSwagger();
            app.UseSwaggerUI(
                options =>
                {
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint(
                            $"/swagger/{description.GroupName}/swagger.json",
                            description.GroupName.ToUpperInvariant());
                    }
                });
            app.UseCors("AllowAllOrigins");
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
