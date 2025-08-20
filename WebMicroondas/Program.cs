using Microsoft.EntityFrameworkCore;
using WebMicroondas.data;
using WebMicroondas.Services.Microondas;
using WebMicroondas.Services.Programa;
using WebMicroondas.Services.ProgramasEstaticos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<ProgramasInterface, ProgramasService>();
builder.Services.AddScoped<ProgramasEstaticosService>();
builder.Services.AddScoped<MicroondasService>();
builder.Services.AddScoped<ProgramasRegistry>();

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
