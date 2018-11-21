using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using challenge.Application.automapper;
using challenge.Application.main.users;
using challenge.EF;
using challenge.EF.repositories;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using challenge.EF.entities;
using challenge.Application.main;
using challenge.Application.main.categories;
using challenge.Application.main.subcategories;
using challenge.Application;
using challenge.Application.main.challenges;
using challenge.Application.main.userChallenges;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using challenge.Application.helpers;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace challenge.Web
{
    public class Startup
    {
        IConfigurationRoot _config;
        private IHostingEnvironment _env;
        public IConfiguration _configuration { get; }

        public Startup(IHostingEnvironment env, IConfiguration configuration)
        {
            var builder = new ConfigurationBuilder()
                //konfiguracinis failas
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            _env = env;
            _config = builder.Build();
            _configuration = configuration;

            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(x => x.AddProfile(new MappingsProfile()));
            //uzregistruojam konteksto klase
            services.AddDbContext<challengeContext>(options =>
            options.UseSqlServer(_configuration.GetConnectionString("ChallengeDatabase")));

            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });


            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IUsersService, UsersService>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryService, CategoryService>();

            services.AddScoped<ISubcategoryRepository, SubcategoryRepository>();
            services.AddScoped<ISubcategoryService, SubcategoryService>();

            services.AddScoped<IChallengeRepository, ChallengeRepository>();
            services.AddScoped<IChallengeService, ChallengeService>();

            services.AddScoped<IUserChallengeRepository, UserChallengeRepository>();
            services.AddScoped<IUserChallengesService, UserChallengesService>();

            services.AddCors();
            services.AddMvc();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder =>
                builder.WithOrigins("http://localhost:4200")
           .AllowAnyHeader()
           .AllowAnyMethod()
           .AllowCredentials());

            app.UseAuthentication();

            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
