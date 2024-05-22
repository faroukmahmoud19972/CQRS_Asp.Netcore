using Ecommerce.Application.Shared;
using Ecommerce.Presistance.Shared;
using Ecommerce.infrastructure.Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureApplicatonService();
builder.Services.ConfigurePresistanceService(builder.Configuration);
builder.Services.configureInfrastructureService(builder.Configuration);


//Configure CORS : 
builder.Services.AddCors(
    opt => opt.AddPolicy(
        "CorsPolicy", p =>
        {
            p.AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin();
        }));


var app = builder.Build();
app.UseDeveloperExceptionPage();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();
