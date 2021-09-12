﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.DbContexts;

namespace University.Infrastructure
{
    public static class ServiceExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
           services.AddDbContext<StudentGradeContext>(opts => opts.UseSqlServer(configuration.GetConnectionString("sqlConnection")));

        public static IServiceCollection AddAuthenticationConfiguration(this IServiceCollection services,
           AppSettings appSettings)
        {
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
            return services;
        }
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(config =>
            {
                config.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Input the jwt like Bearer{your token}",
                    Name = "Authorization",
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });
                config.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                {
                   new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                    Name = "Bearer",
                },
                    new List<string>()
                }
                });
            });
        }
    }
}
