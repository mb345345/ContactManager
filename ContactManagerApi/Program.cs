namespace ContactManagerApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

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
