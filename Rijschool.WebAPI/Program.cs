using Rijschool.WebAPI.Repositories;

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

            // Repositories
            builder.Services.AddSingleton<ExamenRepository>();
            builder.Services.AddSingleton<InstructeurRepository>();
            builder.Services.AddSingleton<LeerlingRepository>();
            builder.Services.AddSingleton<RijlesRepository>();
            builder.Services.AddSingleton<ZiekmeldingRepository>();

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
