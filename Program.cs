
using Microsoft.EntityFrameworkCore;
using TaskManger.Repositories;
using TaskManger.Mapping;
namespace TaskManger
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<Models.AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            
            builder.Services.AddControllers()
    .AddJsonOptions(opts => { opts.JsonSerializerOptions.PropertyNamingPolicy = null; });

            builder.Services.AddScoped<ITaskRepo, TaskRepo>();
            builder.Services.AddAutoMapper(typeof(Program));
            //builder.Services.AddAutoMapper(typeof(AutoMapper));

            //builder.Services.AddFluentValidationAutoValidation();
            //builder.Services.AddFluentValidationClientsideAdapters();


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
