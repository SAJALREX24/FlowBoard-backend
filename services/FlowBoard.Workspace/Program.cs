using Microsoft.EntityFrameworkCore;
using FlowBoard.Workspace.Data;// "Also bring in my own Data folder so I can use the WorkspaceDbContext class."
using FlowBoard.Workspace.Services;

// using in C# = "import this library." 
/*Microsoft.EntityFrameworkCore is the library that lets us talk to SQL Server.
 Without this line,the word UseSqlServer below would be unrecognized.
*/
var builder = WebApplication.CreateBuilder(args);//"Start a new web application builder. Call it builder."


builder.Services.AddControllers();//"Tell my app: I'm going to use Controller classes to handle incoming requests."

builder.Services.AddEndpointsApiExplorer();
// "Enable automatic discovery of all my API endpoints, so tools like Swagger can find them."
builder.Services.AddSwaggerGen();
//"Generate interactive API documentation automatically."

builder.Services.AddDbContext<WorkspaceDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WorkspaceDb")));

builder.Services.AddScoped<IWorkspaceService, WorkspaceServiceImpl>();

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