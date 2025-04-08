using Microsoft.EntityFrameworkCore;
using WebApiTaskTracker.Application.Servises;
using WebApiTaskTracker.Domain.Interfaces.Repositories;
using WebApiTaskTracker.Domain.Interfaces.Services;
using WebApiTaskTracker.Infrastructure.Data;
using WebApiTaskTracker.Infrastructure.Repositories;

namespace WebApiTaskTracker.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IUserServices, UserServices>();
            builder.Services.AddScoped<IBoardServices, BoardServices>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IBoardRepository, BoardRepository>();
            builder.Services.AddScoped<IUserBoardRepository, UserBoardRepository>();
            builder.Services.AddScoped<IValidatorService, ValidatorService>();
            builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();

            builder.Services.AddDbContext<TaskTrackerContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}