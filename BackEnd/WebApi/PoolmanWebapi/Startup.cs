using System;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OData.Edm;
using Poolman.Repository;


namespace PoolmanWebapi
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
            //services.AddAuthentication(AzureADB2CDefaults.BearerAuthenticationScheme)
            //    .AddAzureADB2CBearer(options => Configuration.Bind("AzureAdB2C", options));
            services.AddOData();


            services.AddCors(o => o.AddPolicy("AllowOrigin", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddODataQueryFilter();
            services.AddDbContext<CatholicFeedDataContext>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            app.UseCors(options => options
                               .AllowAnyHeader()
                               .AllowAnyMethod()
                               .AllowAnyOrigin()
                               .AllowCredentials()

                               );

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc(b =>
            {
                b.MapODataServiceRoute("odata", "odata", GetEdmModel(app.ApplicationServices));
                b.EnableDependencyInjection();
                b.Select()
                .Expand()
                .Filter()
                .OrderBy(QueryOptionSetting.Allowed)
                .MaxTop(2000)
                .Count();

            });
        }

        private IEdmModel GetEdmModel(IServiceProvider serviceProvider)
        {
            var builder = new ODataConventionModelBuilder(serviceProvider);
            builder.EnableLowerCamelCase();

            builder.EntitySet<DailyReadingDTO>("DailyReading")
                .EntityType
                .Filter(QueryOptionSetting.Allowed)
                .Count()
                .OrderBy()
                .Page()
                .Select();
            builder.EntityType<DailyReadingDTO>().Filter("type");

            builder.EntitySet<SaintDTO>("Saint")
                .EntityType
                .Filter(QueryOptionSetting.Allowed)
                .Count()
                .OrderBy()
                .Page()
                .Select();
            builder.EntityType<SaintDTO>().Filter("id");


            return builder.GetEdmModel();
        }
    }
}
