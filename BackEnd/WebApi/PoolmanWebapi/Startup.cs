using System;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OData;
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

            services.AddCors();
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
                b.MapRoute("default", "api/{controller}/{action}");
                b.MapRoute("defaultApi", "api/{controller}/{id}");
                b.Count().Filter().OrderBy().Expand().Select().MaxTop(null);
                b.MapODataServiceRoute("odata", null, GetEdmModel());
            });
        }

        private IEdmModel GetEdmModel()
        {
            var builder = new ODataConventionModelBuilder();
            builder.EnableLowerCamelCase();

            builder.EntitySet<RssFeedDto>("DailyReading").EntityType.Filter(QueryOptionSetting.Allowed);
            builder.EntityType<RssFeedDto>().Filter("id");

            //builder.EntitySet<RssFeedDto>("DailyReading").EntityType.Filter(QueryOptionSetting.Allowed);
            //var searchFunction = builder.Function("getRssFeedsCurrentDate");
            //searchFunction.Parameter<string>("searchText");
            //searchFunction.ReturnsCollectionFromEntitySet<RssFeedDto>("RssFeedsCurrentDate");

            return builder.GetEdmModel();
        }
    }
}
