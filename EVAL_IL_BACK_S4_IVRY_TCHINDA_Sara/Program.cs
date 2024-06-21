using EVAL_IL_BACK_S4_IVRY_TCHINDA_Sara.Data;
using EVAL_IL_BACK_S4_IVRY_TCHINDA_Sara.Models;
using EVAL_IL_BACK_S4_IVRY_TCHINDA_Sara.Repositories;
using EVAL_IL_BACK_S4_IVRY_TCHINDA_Sara.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IRepository<Folder>, FolderRepository>();
builder.Services.AddScoped<IRepository<XFile>, XFileRepository>();
builder.Services.AddScoped<FolderService>();
builder.Services.AddScoped<XFileService>();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:3000")
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

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

app.UseCors(); // Ensure CORS middleware is used

app.UseAuthorization();

app.MapControllers();

app.Run();
