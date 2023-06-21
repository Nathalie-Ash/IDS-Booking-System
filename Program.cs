using IDS.Core.Interfaces;
using IDS.Core.Models.Auth;
using IDS.Data;
using IDSBookingSystem.Extension;
using IDSBookingSystem.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace IDSBookingSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configure the application services and middleware
            ConfigureServices(builder.Services, builder.Configuration);

            var app = builder.Build();

            // Configure the request pipeline
            Configure(app);

         
        }

        private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("Jwt").Get<JwtSettings>();
            services.AddControllers();
            services.AddAutoMapper(typeof(Program));
            services.AddEndpointsApiExplorer();
            services.AddDbContext<IDSDbContext>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "IDSBookingSystem", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT containing userid claim",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                });
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddIdentity<CustomUser, CustomRole>()
    .AddEntityFrameworkStores<IDSDbContext>()
    .AddDefaultTokenProviders();
            services.AddControllersWithViews();
           
            services.AddDbContext<IDSDbContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                x => x.MigrationsAssembly("IDS.Data")));


            var jwtSettings = configuration.GetSection("Jwt").Get<JwtSettings>();
            services.Configure<JwtSettings>(configuration.GetSection("Jwt"));
            services.AddAuthorization()
                        .AddAuthentication(options =>
                        {
                            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                        })
                        .AddJwtBearer(options =>
                        {
                            options.RequireHttpsMetadata = false;
                            options.TokenValidationParameters = new TokenValidationParameters
                            {
                                ValidIssuer = jwtSettings.Issuer,
                                ValidAudience = jwtSettings.Issuer,
                                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret)),
                                ClockSkew = TimeSpan.Zero
                            };
                        });

        }

        private static void Configure(WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "IDSBookingSystem");
                });
            }
            app.UseAuthorization();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
