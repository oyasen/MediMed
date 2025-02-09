using MediMed.Data;
using MediMed.Dto;
using MediMed.Repo.Implementation;
using MediMed.Repo.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("constr")));
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddScoped<IHealthTipRepo,HealthTipRepo>();
builder.Services.AddScoped<INurseRepo,NurseRepo>();
builder.Services.AddScoped<IPatientRepo,PatientRepo>();

var app = builder.Build();


    app.UseSwagger();
    app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
