using Microsoft.EntityFrameworkCore;

using api_mimic.Database;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new() {
        Title = "Mimic API Documentation",
        Version = "1.0.0",
        Description = "This is a Simple API project",
        License = new() {
            Name = "MIT",
            Url = new Uri("https://opensource.org/licenses/MIT"),
        },
    }
    );
});
builder.Services.AddMvc();
builder.Services.AddDbContext<MimicContext>(opt => {
    opt.UseSqlite("Data Source=Database/Mimic.db");
});
builder.Services.AddApiVersioning(opt =>
{
    opt.DefaultApiVersion = new ApiVersion(1, 0);
    opt.AssumeDefaultVersionWhenUnspecified = true;
    opt.ReportApiVersions = true;
});


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
