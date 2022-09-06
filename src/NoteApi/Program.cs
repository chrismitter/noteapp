using Hellang.Middleware.ProblemDetails;
using NoteApi.Controllers;
using NoteApi.Exceptions;
using NoteApi.Repositories;
using Serilog;

Log.Logger = new LoggerConfiguration().CreateLogger();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddProblemDetails(options =>
{
    options.OnBeforeWriteDetails = (ctx, problemDetails) =>
    {
        Log.Logger.Error("ProblemDetails: {@problemDetails}", problemDetails);
    };
    options.MapToStatusCode<NoteNotFoundException>(StatusCodes.Status404NotFound);
    options.MapToStatusCode<NoteAlreadyExistsException>(StatusCodes.Status400BadRequest);
})
    .AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<INoteService, NoteService>();
builder.Services.AddSingleton<INoteRepository, NoteRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();

namespace NoteApi
{
    public partial class Program { }
}
