
using Microsoft.EntityFrameworkCore;
using SAE501_Blazor_API.Models.DataManager;
using SAE501_Blazor_API.Models.EntityFramework;
using SAE501_Blazor_API.Models.EntityFramework.RoomObjects;
using SAE501_Blazor_API.Models.Repositories;
using SAE501_Blazor_API.Utils;
using System.Reflection;
using System.Text.Json.Serialization;

namespace SAE501_Blazor_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container
            builder.Configuration.AddEnvironmentVariables("AZURE_");
            // AZURE_JWTSECRET__SECRETKEY => builder.Configuration["JwtSecret:SecretKey"]

            builder.Services.AddControllers(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true)
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                    options.JsonSerializerOptions.Converters.Add(new RoomObjectJSONConverter());
                });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //DataContext
            builder.Services.AddDbContext<DataContext>(options =>
            options.UseNpgsql($"Server={builder.Configuration["Server"]};port={builder.Configuration["Port"]};Database={builder.Configuration["Db"]};uid={builder.Configuration["uid"]};password={builder.Configuration["Password"]};"));

            //Local DataContext
            //builder.Services.AddDbContext<DataContext>(options => options.UseNpgsql("Server=localhost;port=5432;Database=SAE_DB;uid=postgres;password=postgres;"));

            //DataRepositories
            builder.Services.AddScoped<IBuildingRepository, BuildingManager>();
            builder.Services.AddScoped<IRoomRepository, RoomManager>();
            builder.Services.AddScoped<IRoomTypeRepository, RoomTypeManager>();
            builder.Services.AddScoped<IRoomObjectRepository, RoomObjectsManager>();

            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

            //CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("NewPolicy", builder =>
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

            var app = builder.Build();

            //Cors policy
            app.UseRouting();
            app.UseCors("NewPolicy");

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                
            }
            //à remettre dans le if, en version finale, Swagger doit être désactivé
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
