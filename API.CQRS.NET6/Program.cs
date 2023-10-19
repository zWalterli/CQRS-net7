
using MediatR;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args); 

builder.Services.AddControllers();

builder.Services.AddMediatR(
    new Assembly[]
    {
        Assembly.Load("CQRS.API"),
        Assembly.Load("CQRS.Domain"),
    }
);

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
