using Microsoft.AspNetCore.Mvc;
using TODOAPI.Responses;
using TODOAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
     .ConfigureApiBehaviorOptions(options =>
     {
         options.InvalidModelStateResponseFactory = context =>
         {
             var errors = context.ModelState
                 .Where(e => e.Value != null &&
                             e.Value.Errors.Count > 0)
                 .ToDictionary(
                     e => e.Key,
                     e => e.Value!.Errors
                               .Select(x => x.ErrorMessage)
                               .ToArray()
                 );

             var errorResponse = new ErrorResponse
             {
                 StatusCode = 400,
                 Message = "Validation failed",
                 Errors = errors,
                 Timestamp = DateTime.Now
             };

             return new BadRequestObjectResult(errorResponse);
         };
     });
builder.Services.AddSingleton<ITodoService, TodoService>();
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
