
using Microsoft.EntityFrameworkCore;
using SAE501_Blazor_API.Models.DataManager;
using SAE501_Blazor_API.Models.EntityFramework;
using SAE501_Blazor_API.Models.Repositories;

namespace SAE501_Blazor_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //DataContext
            builder.Services.AddDbContext<DataContext>(options =>
                options.UseNpgsql("Server=localhost;port=5432;Database=SAE_DB; uid=postgres; password=postgres;"));

            //DataRepositories
            builder.Services.AddScoped<IDataRepository<Building>, BuildingManager>();
            builder.Services.AddScoped<IDataRepository<Door>, DoorManager>();
            builder.Services.AddScoped<IDataRepository<Furniture>, FurnitureManager>();
            builder.Services.AddScoped<IDataRepository<FurnitureType>, FurnitureTypeManager>();
            builder.Services.AddScoped<IDataRepository<Room>, RoomManager>();
            builder.Services.AddScoped<IDataRepository<RoomType>, RoomTypeManager>();
            builder.Services.AddScoped<IDataRepository<Sensor>, SensorManager>();
            builder.Services.AddScoped<IDataRepository<Wall>, WallManager>();
            builder.Services.AddScoped<IDataRepository<Window>, WindowManager>();

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
