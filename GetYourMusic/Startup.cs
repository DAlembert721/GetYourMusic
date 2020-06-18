using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using GetYourMusic.Domain.Models.Locations;
using GetYourMusic.Domain.Persistence.Contexts;
using GetYourMusic.Domain.Repositories;
using GetYourMusic.Domain.Services;
using GetYourMusic.Persistence;
using GetYourMusic.Persistence.Repositories;
using GetYourMusic.Services;
using GetYourMusic.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace GetYourMusic
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
            services.AddCors();
            services.AddControllers();
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseMySQL(Configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v3", new OpenApiInfo { Title = "GetYourMusic API", Version = "v3" });


            });

            services.AddScoped<IRegionRepository, RegionRepository>();
            services.AddScoped<IRegionService, RegionService>();

            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<ICityService, CityService>();

            services.AddScoped<IDistrictRepository, DistrictRepository>();
            services.AddScoped<IDistrictService, DistrictService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IAccountService, AccountService>();

            services.AddScoped<IContractRepository, ContractRepository>();
            services.AddScoped<IContractService, ContractService>();

            services.AddScoped<IOrganizerRepository, OrganizerRepository>();
            services.AddScoped<IOrganizerService, OrganizerService>();

            services.AddScoped<IMusicianRepository, MusicianRepository>();
            services.AddScoped<IMusicianService, MusicianService>();

            services.AddScoped<IMusicianGenreRepository, MusicianGenreRepository>();
            services.AddScoped<IMusicianGenreService, MusicianGenreService>();

            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IGenreService, GenreService>();

            services.AddScoped<ISearchRepository, SearchRepository>();
            services.AddScoped<ISearchService, SearchService>();

            services.AddScoped<IMusicianInstrumentRepository, MusicianInstrumentRepository>();
            services.AddScoped<IMusicianInstrumentService, MusicianInstrumentService>();

            services.AddScoped<IInstrumentRepository, InstrumentRepository>();
            services.AddScoped<IInstrumentService, InstrumentService>();

            services.AddScoped<IPublicationRepository, PublicationRepository>();
            services.AddScoped<IPublicationService, PublicationService>();

            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<ICommentService, CommentService>();

            services.AddScoped<IQualificationRepository, QualificationRepository>();
            services.AddScoped<IQualificationService, QualificationService>();

            services.AddScoped<IFollowRepository, FollowRepository>();
            services.AddScoped<IFollowService, FollowService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddAutoMapper(typeof(Startup));

            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            // Configure Authentication System Based on Bearer JWT
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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("./swagger/v3/swagger.json", "GetYourMusic V3");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}
