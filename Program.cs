using Arquitectura_BACKEND.BookStore.application.interfaces.services;
using Arquitectura_BACKEND.BookStore.application.services;
using Arquitectura_BACKEND.BookStore.domain.contracts;
using Arquitectura_BACKEND.BookStore.infrastructure.Persistance.connection;
using Arquitectura_BACKEND.BookStore.infrastructure.Persistance.repositories;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddScoped<SqlServerConnection>();

builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddScoped<IBookRepository, BookRepository>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseCors("AllowAll");

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
