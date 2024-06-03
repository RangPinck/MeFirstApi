
using Microsoft.EntityFrameworkCore;
using VeterinarClinicApi.Interfaces;
using VeterinarClinicApi.Models;
using VeterinarClinicApi.Repositories;

namespace VeterinarClinicApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddScoped<IServicedoctorRepository, ServicedoctorRepository>();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //builder.Services.AddDbContext<VCDbContext>(options =>
            builder.Services.AddDbContext<GoncharovaContext>(options =>
            {
                options.UseNpgsql(
                    builder.Configuration.GetConnectionString("DefaultConnection")
                    );
            });

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

            //app.MapGet("/", (GoncharovaContext db) => db.Users.ToList());

            app.Run();
        }
    }
}
