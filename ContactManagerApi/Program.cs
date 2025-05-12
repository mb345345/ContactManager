using ContactManagerBll;
using ContactManagerBll.Interfaces;
using ContactManagerDal;
using ContactManagerDal.Interfaces;
using System.Drawing;

namespace ContactManagerApi
{
    public class Program
    {
        /// <summary>
        /// #todo - implement an error page which indicates the cause of any config errors
        /// </summary>
        /// <param name="args"></param>
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

            // get url of web front end eg. "http://localhost:5173"
            var clientUrl = builder.Configuration["ClientUrl"];

            // add cors policy
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    // vite dev server
                    policy.WithOrigins(clientUrl)
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
