using Microsoft.EntityFrameworkCore;
using FlowBoard.Comment.Data;
using FlowBoard.Comment.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CommentDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("CommentDb"), x => x.MigrationsHistoryTable("__EFMigrationsHistory_Comment")));

builder.Services.AddScoped<ICommentService, CommentServiceImpl>();


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



