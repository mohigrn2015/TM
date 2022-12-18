using TM.Entity;
using TM.BLL;
using TM.DAL;

var builder = WebApplication.CreateBuilder(args);

DataContext.ConnectionStrings = builder.Configuration.GetConnectionString("tmdbConnection");

builder.Services.AddControllers();

builder.Services.AddBll().AddDAL();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.MapControllers();

app.Run();
