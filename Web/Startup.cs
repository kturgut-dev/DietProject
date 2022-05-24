using DietProject.Business.Validations;
using DietProject.Core.DataAccess;
using DietProject.Core.Entities;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Web.Extensions;
using Web.Hubs;

namespace Web
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
            // Add framework services.
            services
                .AddControllersWithViews()
                .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null)
                .AddFluentValidation(options =>
                {
                    options.RegisterValidatorsFromAssemblyContaining<Startup>();
                });

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins("http://localhost:55867/")
                        .AllowCredentials();
                });
            });

            services.AddTransient<IValidator<User>, UsersValidation>();

            services.AddDbContextFactory<DietProjectContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DietProject")));

            services.AddAuth();

            services.AddSignalR();

            services.AddHttpContextAccessor();

            Chat.AcitveUsers = new System.Collections.Generic.List<Models.SocketUser>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DietProjectContext db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            //http://www.binaryintellect.net/articles/87446533-54b3-41ad-bea9-994091686a55.aspx
            //if ((db.Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator).Exists())
            //    db.Database.Migrate();
            //else
            //db.Database.EnsureCreated();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuth();

            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapHub<Chat>("/chathub");
            });

        }
    }
}
