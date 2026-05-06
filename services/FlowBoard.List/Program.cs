using Microsoft.EntityFrameworkCore;
using FlowBoard.List.Data;
using FlowBoard.List.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ListDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("ListDb")));

builder.Services.AddScoped<IListService, ListServiceImpl>();

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
