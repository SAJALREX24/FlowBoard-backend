using Microsoft.EntityFrameworkCore;
using FlowBoard.Label.Data;
using FlowBoard.Label.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<LabelDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("LabelDb")));

builder.Services.AddScoped<ILabelService, LabelServiceImpl>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
