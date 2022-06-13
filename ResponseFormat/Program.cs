using Microsoft.AspNetCore.Builder;
using Newtonsoft.Json;
using ResponseFormat;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ResultFilter>();
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStatusCodePages(async statusCodeContext =>
{
    // using static System.Net.Mime.MediaTypeNames;
    statusCodeContext.HttpContext.Response.ContentType = "application/json";

    switch (statusCodeContext.HttpContext.Response.StatusCode)
    {
       
        case 404:
            var result = new Result {
                Code = 404,
                Message = "Not Found",
                Data = "......"
            };
            await statusCodeContext.HttpContext.Response.WriteAsync(
                JsonConvert.SerializeObject(result)
            ) ;
            break;
        
        case 415:
                        var result1 = new Result {
                            Code = 415,
                            Message = " Unsupported Media Type",
                            Data = "......"
                        };
                        await statusCodeContext.HttpContext.Response.WriteAsync(
                            JsonConvert.SerializeObject(result1)
                        ) ;
            break;
            
        case 400:
        var result2 = new Result {
            Code = 400,
            Message = "Bad Request",
            Data = "......"
        };
        await statusCodeContext.HttpContext.Response.WriteAsync(
            JsonConvert.SerializeObject(result2)
        ) ;
        break;
        
        
        case 405:
            var result3 = new Result
            {
                Code = 405,
                Message = "Method Not Allowed",
                Data = "....."
            };
            await statusCodeContext.HttpContext.Response.WriteAsync(
                JsonConvert.SerializeObject(result3)
            ) ;
            break;
    }

});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();