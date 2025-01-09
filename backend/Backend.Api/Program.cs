
namespace Backend.Api
{
    public class Program
    {
        private static string _policyName="_corsPolicy";
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
         
         
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(_policyName,
                    policy =>
                    {
                        string[]? allowedOrigins = builder.Configuration.GetSection("AllowedCorsOrigins").Get<string[]>();
                        if (allowedOrigins != null && allowedOrigins.Any())
                        {
                            policy.WithOrigins(allowedOrigins)
                                .AllowAnyMethod()
                                .AllowAnyHeader();
                        }
                    });
            });

            var app = builder.Build();

            //// Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseCors(_policyName);
            app.MapControllers();

            app.Run();
        }
    }
}
