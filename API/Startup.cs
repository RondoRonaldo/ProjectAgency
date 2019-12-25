using AutoMapper;
using BLL.Infrastructure;
using BLL.Interfaces;
using BLL.Services;
using DAL.EF;
using DAL.Entities;
using DAL.Identity;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace API
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
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllersWithViews();


            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IDistrictService, DistrictService>();
            services.AddScoped<IUnitOfWork, IdentityUnitOfWork>();
            services.AddScoped<DbContext, ApplicationContext>();
            services.AddScoped<IRequestService, RequestService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddControllers().AddNewtonsoftJson();
            ConfigureIdentity(services);
            ConfigureCookies(services);
            ConfigureCors(services);
            services.AddMvc();


            var mappingConfig = new MapperConfiguration(mc => { mc.AddProfile(new AutoMapperProfile()); });

            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        private void ConfigureCors(IServiceCollection services)
        {
            services.AddCors(options =>
                options.AddPolicy("AllowOrigins",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200")
                            .AllowAnyMethod()
                            .AllowAnyHeader().
                            AllowCredentials().
                            WithExposedHeaders();
                    }));
        }

        private void ConfigureIdentity(IServiceCollection services)
        {
            services
                .AddIdentity<ApplicationUserEntity, IdentityRole>(options =>
                {
                    options.User.RequireUniqueEmail = true;

                    options.Password.RequiredLength = 8;
                    options.Password.RequireNonAlphanumeric = false;

                    options.SignIn.RequireConfirmedEmail = false;
                    options.SignIn.RequireConfirmedPhoneNumber = false;
                })
                .AddUserManager<ApplicationUserManager>()
                .AddUserStore<UserStore<ApplicationUserEntity>>()
                .AddRoleManager<ApplicationRoleManager>()
                .AddRoleStore<RoleStore<IdentityRole>>()
                .AddSignInManager<SignInManager<ApplicationUserEntity>>();
        }

        private void ConfigureCookies(IServiceCollection services)
        {
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = false;
                options.Cookie.SecurePolicy = CookieSecurePolicy.None;
                options.Cookie.Name = "appAuth";
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment()) app.UseSpaStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors("AllowOrigins");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    "default",
                    "{controller}/{action=Index}/{id?}");
            });
        }
    }
}