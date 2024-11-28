using Serilog;

namespace WebApplication2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Serilog-Konfiguration ohne appsettings.json
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console() // Logs in die Konsole
                .WriteTo.File(
                    path: "Logs/log-.txt", // Logs in Dateien schreiben (rotierende Logs)
                    rollingInterval: RollingInterval.Day, // Tägliche Rotation der Logs
                    outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} {Level:u3}] {Message:lj}{NewLine}{Exception}" // Format der Logs
                )
                .Enrich.FromLogContext() // Kontextinformationen hinzufügen
                .CreateLogger();

            try
            {
                Log.Information("Application starting up");

                var builder = WebApplication.CreateBuilder(args);

                // Serilog als Logging-Provider registrieren
                builder.Host.UseSerilog();

                // Services hinzufügen
                builder.Services.AddControllers();
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen();

                var app = builder.Build();

                // Middleware hinzufügen
                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }

                app.UseHttpsRedirection();

                app.UseAuthorization();

                // Serilog-Logging-Middleware
                app.UseSerilogRequestLogging();

                app.MapControllers();

                app.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application failed to start");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}
