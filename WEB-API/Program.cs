using Microsoft.EntityFrameworkCore;
using WEB_API.Entities;

var builder = WebApplication.CreateBuilder(args);

var myAllowSpecificOrigins = "_myAllowSpecificOrigins";

//// Add services to the container.
//builder.Services.AddCors(opciones =>
//{
//    opciones.AddDefaultPolicy(builder =>
//    {
//        builder.WithOrigins("https://angularfront-gs.stackblitz.io").AllowAnyMethod().AllowAnyHeader().WithExposedHeaders();
//        builder.WithOrigins("http://angularfront-gs.stackblitz.io").AllowAnyMethod().AllowAnyHeader().WithExposedHeaders();
//        builder.WithOrigins("http://localhost:7136").AllowAnyMethod().AllowAnyHeader().WithExposedHeaders();
//        builder.WithOrigins("https://angularfront-gs.stackblitz.io/users").AllowAnyMethod().AllowAnyHeader().WithExposedHeaders();
//    });
//});

// Enable CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins,
        builder =>
        {
            builder.WithOrigins("https://angularfront-gs.stackblitz.io")
            .AllowAnyMethod()
            .AllowAnyHeader();

            builder.WithOrigins("http://localhost:7136")
           .AllowAnyMethod()
           .AllowAnyHeader();
        });
});

builder.Services.AddDbContext<ClienteDBContext>(options => options.UseInMemoryDatabase("Clientes"));

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

app.UseCors(myAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
