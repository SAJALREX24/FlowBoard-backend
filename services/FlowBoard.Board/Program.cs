using Microsoft.EntityFrameworkCore;
using FlowBoard.Board.Data;
using FlowBoard.Board.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BoardDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("BoardDb"), x => x.MigrationsHistoryTable("__EFMigrationsHistory_Board")));

builder.Services.AddScoped<IBoardService, BoardServiceImpl>();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    /* Database migration disabled for debugging */
}


app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();



