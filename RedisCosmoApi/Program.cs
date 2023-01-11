using RedisCosmoApi.Infrastructure;
using RedisCosmoApi.Interfaces;
using RedisCosmoApi.ServiceExtensions;
using RedisCosmoApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddThirdParty(builder.Configuration);
builder.Services.AddScoped<IUserDetails, UserServices>();
builder.Services.AddScoped<IRedisClient, RedisClient>();

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