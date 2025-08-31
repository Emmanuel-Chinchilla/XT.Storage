using XT.StorageController.Classes;
using XT.StorageController.Interfaces;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins, policy =>
    {
        policy
            .WithOrigins("https://localhost:7010", "http://localhost:7110")
            .AllowCredentials()                   
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

ConfigureDependencyInjection(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void ConfigureDependencyInjection(WebApplicationBuilder builder)
{
    builder.Services.AddTransient<IData>(provider => new Data(provider.GetRequiredService<IConfiguration>()));
}
