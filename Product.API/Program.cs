
using Microsoft.EntityFrameworkCore;
using Product.Application.Services;
using Product.Domain.Interfaces;
using Product.Persistence.Data;
using Product.Persistence.Repositories;
using System;

namespace Product.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ProductServiceDbContext>(
            option => option.UseSqlite(
            builder.Configuration.GetConnectionString("productServiceCS")));

            builder.Services.AddScoped<IProductItemServices, ProductItemServices>();
            builder.Services.AddScoped<IProductItemRepository, ProductItemRepository>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
