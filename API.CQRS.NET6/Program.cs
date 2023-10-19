
using CQRS.Infrastructure.Context;
using MediatR;
using Microsoft.AspNetCore.ResponseCompression;
using System.IO.Compression;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args); 

builder.Services.AddControllers();

builder.Services.AddMediatR(
    new Assembly[]
    {
        Assembly.Load("CQRS.API"),
        Assembly.Load("CQRS.Domain"),
        Assembly.Load("CQRS.Insfrastructure"),
    }
);

builder.Services.Configure<GzipCompressionProviderOptions>(options => options.Level = CompressionLevel.Optimal);
builder.Services.AddResponseCompression(options =>
{
    options.Providers.Add<GzipCompressionProvider>();
    options.EnableForHttps = true;
});

builder.Services.AddDbContext<APIContext>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
