
using BookingsystemAPI.Data;
using BookingsystemAPI.DTOs;
using BookingsystemAPI.Services;
using BookingsystemModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

namespace BookingsystemAPI
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
            builder.Services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                });

                options.OperationFilter<SecurityRequirementsOperationFilter>();
            });
            builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
            builder.Services.AddScoped<ICustomer<Customer>,CustomerRepository>();
            builder.Services.AddScoped<IAppointment<Appointment>, AppointmentRepository>();
            builder.Services.AddScoped<IHistory<History>, HistoryRepository>();

            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.
                Serialization.ReferenceHandler.IgnoreCycles;
            });

            builder.Services.AddDbContext<BookingsystemDbContext>( options => options.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));

            builder.Services.AddAuthorization();

            //builder.Services.AddIdentityApiEndpoints<IdentityUser>()
                //.AddEntityFrameworkStores<BookingsystemDbContext>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            
            //app.MapIdentityApi<IdentityUser>(); // Tillag av mig f�r identifiering

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
