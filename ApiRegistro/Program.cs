using APIREGISTRO.Data;
using APIREGISTRO.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
{
    
}

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySQL(connectionString));

builder.Services.AddCors(options =>
{
    options.AddPolicy("ProdutosApp", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IProdutoInterface, ProdutoService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHttpsRedirection();
}

app.UseRouting();
app.UseAuthorization();
app.UseCors("ProdutosApp");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();


