using AutoMapper;
using Core.Repositories;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Data;
using Social_Media_Apis.Errors;
using Social_Media_Apis.Helpers;
using Social_Media_Apis.Middelware;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost3000",
        policy => policy.WithOrigins("http://localhost:3000")
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

// Add services to the container.

//builder.Services.AddControllers();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
        options.JsonSerializerOptions.MaxDepth = 64; // Optional: Increase if needed
    });
builder.Services.AddDbContext<SocialMediaContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.Configure<ApiBehaviorOptions>(
    Options => Options.InvalidModelStateResponseFactory = (ActionContext) =>
    {
        var errors = ActionContext.ModelState.Where(p => p.Value.Errors.Count > 0)
        .SelectMany(p => p.Value.Errors)
        .Select(p => p.ErrorMessage).ToArray();
        var ApiValidationErrors=new ApiValidationErrorResponse(errors);
        return new BadRequestObjectResult(ApiValidationErrors);
    }
) ;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseCors("AllowLocalhost3000");
#region UpdateDatabase
var scope=app.Services.CreateScope();
var service=scope.ServiceProvider;
var loggerFactory=service.GetRequiredService<ILoggerFactory>();
try
{
    var DbContext = service.GetRequiredService<SocialMediaContext>();
    await DbContext.Database.MigrateAsync();
    await DataSeeds.SeedsAsync(DbContext);
}
catch (Exception ex)
{
    var logger = loggerFactory.CreateLogger<Program>();
    logger.LogError(ex, "An Error Occured During Migration");
}
#endregion

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseStaticFiles();
app.UseMiddleware<ExceptionMiddelware>();
app.UseStatusCodePagesWithRedirects("/error/{0}");

app.Run();
