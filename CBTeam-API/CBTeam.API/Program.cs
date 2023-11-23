using CBTeam.Application;
using CBTeam.Infraestructure;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.addInfrastructure(connectionString);
builder.Services.InstallApplication();

builder.Services.AddControllers();
builder.Services.AddCors(option=> 
option.AddPolicy("Default", 
				policy => {
					policy.AllowAnyOrigin()
					.AllowAnyOrigin()
					.AllowAnyMethod();
				     	  }));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();
app.UseCors("Default");
app.MapControllers();
app.Run();
