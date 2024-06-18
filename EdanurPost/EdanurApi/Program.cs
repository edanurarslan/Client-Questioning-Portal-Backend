using Abstract.Services;
using Application.Services;
using Infracture.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICommentServices, CommentBusiness>();
builder.Services.AddScoped<IUserServices, UserBusiness>();
builder.Services.AddScoped<IPostServices, PostBusiness>();

// Add DbContext

builder.Services.AddDbContext<EdanurContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("EdanurConnection"));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
