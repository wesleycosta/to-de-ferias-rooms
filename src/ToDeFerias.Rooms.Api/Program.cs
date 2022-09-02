using ToDeFerias.Rooms.Api.Configurations;
using ToDeFerias.Rooms.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddApiConfiguration(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

app.ApplyMigrate();

app.Run();
