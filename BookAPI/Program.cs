
using BookAPI.Data;
using BookAPI.Repositories;
using BookAPI.Repositories.Interfaces;
using BookAPI.Services;
using BookAPI.DTOs;
using BookAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.ModelBuilder;
using Microsoft.AspNetCore.OData;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;

namespace BookAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<BookContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddEndpointsApiExplorer();
            //swagger authen
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BookAPI", Version = "v1" });

                // Cấu hình hỗ trợ Bearer token
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Nhập token theo dạng: Bearer {your JWT token}"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
            });

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddScoped<IBookRepository, BookRepository>();
            builder.Services.AddScoped<IBookService, BookService>();
            //Cấu hình Authentication với Jwt Bearer
            builder.Services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        ValidAudience = builder.Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                    };
                });

            var odataBuilder = new ODataConventionModelBuilder();
            odataBuilder.EntitySet<BookReadDTO>("Books");
            // Add services to the container.

            builder.Services.AddControllers().AddOData(options => options
              .AddRouteComponents("odata", odataBuilder.GetEdmModel())
              .SetMaxTop(100)
               .Count()
               .Filter()
               .OrderBy()
               .Expand()
               .Select());
            


            var app = builder.Build();

            
                app.UseSwagger();
                app.UseSwaggerUI();
            

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
