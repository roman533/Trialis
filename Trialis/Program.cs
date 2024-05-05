using Trialis.Domain.Interfaces;
using Trialis.Domain.Repositories;
using Trialis.Domain.RepositoryInterfaces;
using Trialis.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

// Add Services and Repositories
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();

builder.Services.AddScoped<IKlausurService, KlausurService>();
builder.Services.AddScoped<IKlausurRepository, KlausurRepository>();

builder.Services.AddScoped<IProfessorService, ProfessorService>();
builder.Services.AddScoped<IProfessorRepository, ProfessorRepository>();

builder.Services.AddScoped<IPruefungsaufgabeService, PruefungsaufgabeService>();
builder.Services.AddScoped<IPruefungsaufgabeRepository, PruefungsaufgabeRepository>();

builder.Services.AddScoped<IStudienfachService, StudienfachService>();
builder.Services.AddScoped<IStudienfachRepository, StudienfachRepository>();

builder.Services.AddScoped<IStudienfachAnalyseService, StudienfachAnalyseService>();
builder.Services.AddScoped<IStudienfachAnalyseRepository, StudienfachAnalyseRepository>();

builder.Services.AddControllers();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
/*
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
*/

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();