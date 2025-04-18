
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Multishop.Order.Persistence.Context;
using Multishop.Order.Persistence.Repositories;
using MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Application.Services;

namespace MultiShop.Order.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            {
                opt.Authority = builder.Configuration["IdentityServerUrl"];
                opt.Audience = "ResourceOrder";
                opt.RequireHttpsMetadata = false;
            });
            #region 
            // Add services to the container.
            builder.Services.AddScoped<GetAddressQueryHandler>();
            builder.Services.AddScoped<CreateAddressCommandHandler>();
            builder.Services.AddScoped<GetAddressByIdQueryHandler>();
            builder.Services.AddScoped<RemoveAddressCommandHandler>();
            builder.Services.AddScoped<UpdateAddressCommandHandler>();

            builder.Services.AddScoped<GetOrderDetailQueryHandler>();
            builder.Services.AddScoped<CreateOrderDetailCommandHandler>();
            builder.Services.AddScoped<GetOrderDetailByIdQueryHandler>();
            builder.Services.AddScoped<RemoveOrderDetailCommandHandler>();
            builder.Services.AddScoped<UpdateOrderDetailCommandHandler>();


            builder.Services.AddDbContext<OrderContext>();
            #endregion

            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddApplicationService(builder.Configuration);

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
