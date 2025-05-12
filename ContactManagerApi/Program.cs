using ContactManagerBll;
using ContactManagerBll.Interfaces;
using ContactManagerDal;
using ContactManagerDal.Interfaces;

namespace ContactManagerApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Configuration
                .AddJsonFile("appsettings.json", optional: false)
                .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
                .AddUserSecrets<Program>(optional: true) // For local dev secrets
                .AddEnvironmentVariables(); // For container and Azure

            // di registration
            builder.Services.AddScoped<ICompanyManager, CompanyManager>();

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddScoped<ICompanyDal, CompanyDal>(sp => new CompanyDal(connectionString));

            // add cors policy
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    // vite dev server
                    policy.WithOrigins("http://localhost:5173") 
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            builder.Services.AddControllers();

            var app = builder.Build();

            // enable cors middleware
            app.UseCors(); 

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
