using webapi.Database;
using webapi.Middlewares;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

internal class Program
{
    private static void Main(string[] args)
    {
        var configurationBuilder = new ConfigurationBuilder();
        configurationBuilder.AddJsonFile(path: "appsettings.json", optional: false, reloadOnChange: true);
        var iConfigurationRoot = configurationBuilder.Build();

        var iLoggerFactory = LoggerFactory.Create((iLoggingBuilder) =>
        {
            iLoggingBuilder.AddConfiguration(iConfigurationRoot);
            iLoggingBuilder.AddConsole();
        });

        var builder = WebApplication.CreateBuilder(args);

        // Setup Configuration
        builder.Configuration.AddConfiguration(iConfigurationRoot);

        // Add services to the container.

        var iMvcBuilder = builder.Services.AddControllers();

        iMvcBuilder.AddJsonOptions((JsonOptions) =>
        {
            var serializerOptions = JsonOptions.JsonSerializerOptions;
#if DEBUG
            serializerOptions.WriteIndented = true;
#else
            serializerOptions.WriteIndented = false;
#endif
        });

#warning workaround till the query model source generators are made
        builder.Services.Configure<ApiBehaviorOptions>(options =>
        {
            options.SuppressModelStateInvalidFilter = true;
        });

        // Adds Swagger functionality
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            options.CustomSchemaIds(type =>
            {
                // This prevents namespace conflicts in certain scenarios
                return type.Name;
            });
        });

        builder.Services.AddHttpClient();

        builder.Services.AddSingleton(iLoggerFactory);

        builder.Services.AddSqlite<DatabaseContext>(iConfigurationRoot.GetConnectionString(nameof(DatabaseContext)));
        builder.Services.AddDbContext<DatabaseContext>((dbContextOptionsBuilder) =>
        {
#if DEBUG
            dbContextOptionsBuilder.EnableDetailedErrors();
            dbContextOptionsBuilder.EnableSensitiveDataLogging();
            dbContextOptionsBuilder.UseLoggerFactory(iLoggerFactory);
#endif
        });


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseHttpLogging();
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCors();

        app.UseMiddleware<CustomMiddleware>();

        app.UseCors((policyBuilder) => 
        {
            policyBuilder.AllowAnyHeader();
            policyBuilder.AllowAnyMethod();
            policyBuilder.AllowAnyOrigin();
        });

        // app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}