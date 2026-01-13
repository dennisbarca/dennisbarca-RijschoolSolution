using Rijschool.Applicatie.Repositories;
using Rijschool.Applicatie.Interfaces;
using Microsoft.AspNetCore.Cors.Infrastructure;



namespace Rijschool.WebAPI
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

            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.WithOrigins("https://localhost:7106") // Blazor mag requests doen
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            // Repositories
            builder.Services.AddSingleton<IExamenRepository, ExamenRepository>();
            builder.Services.AddSingleton<IInstructeurRepository, InstructeurRepository>();
            builder.Services.AddSingleton<ILeerlingRepository, LeerlingRepository>();
            builder.Services.AddSingleton<IRijlesRepository, RijlesRepository>();
            builder.Services.AddSingleton<IZiekmeldingRepository, ZiekmeldingRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
