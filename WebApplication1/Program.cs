using Microsoft.EntityFrameworkCore;
using WebApplication1.Store;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//para conectar a base de dato
builder.Services.AddDbContext<ApplicationDbContext>(option=>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("Default Connection"));
});

//enable cors
builder.Services.AddCors(p => p.AddPolicy("corspolicy", build =>
{
    build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

//enable singledoman
//multipl domain pongo para single o multiple el direccion que va a usar api, por ej http://localhost:3000/ en withOrigin("http://localhost:3000/")
//any domain pongo * en withorigins(*)

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//enable cors
app.UseCors("corspolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
