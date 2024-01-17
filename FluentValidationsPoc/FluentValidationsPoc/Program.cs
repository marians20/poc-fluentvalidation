// See https://aka.ms/new-console-template for more information

using Contracts.Dtos;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Services;
using Services.Extensions;
using Services.Mappers;
using Services.Validators;

Console.WriteLine("Hello, World!");

var services = new ServiceCollection();
services
    .RegisterFluentValidation(typeof(PersonDtoValidator))
    .RegisterAutoMapper(typeof(PersonMapper))
    .RegisterServices();

var provider = services.BuildServiceProvider();

var dto = new PersonDto
{
    Id = Guid.NewGuid(),
    Name = "Farafastoaca",
    BirthDate = DateTime.Today.AddYears(-22)
};

var validator = provider.GetRequiredService<IValidator<PersonDto>>();

var result = validator.Validate(dto);

Console.WriteLine(result.Messages());