using FluentValidation.AspNetCore;
using Services;
using Services.Mappers;
using Services.Validators;
using WebApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .RegisterAutoMapper(typeof(PersonMapper))
    .RegisterFluentValidation(typeof(FullNameValidator))
    .RegisterServices();

// builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddFluentValidationAutoValidation();

builder.Services
    .AddMvc(opts =>
    {
        opts.Filters.Add<InputValidationActionFilter>();
    })
    .AddFluentValidation(mvcConfiguration =>
        mvcConfiguration.RegisterValidatorsFromAssemblyContaining(typeof(FullNameValidator)));

var app = builder.Build();

app.UseMiddleware<ValidateInputMiddleware>();
app.UseMiddleware<ErrorHandlerMiddleware>();

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
