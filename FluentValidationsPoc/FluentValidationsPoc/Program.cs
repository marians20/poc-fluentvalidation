// See https://aka.ms/new-console-template for more information

using FluentValidationsPoc;
using System.Text.Json;

Console.WriteLine("Hello, World!");

var dto = new PersonDto
{
    Id = Guid.NewGuid(),
    Name = null,
    BirthDate = DateTime.Today.AddYears(-22)
};

var validator = new PersonDtoValidator();

var result = validator.Validate(dto);

Console.WriteLine(JsonSerializer.Serialize(result, new JsonSerializerOptions
{
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
}));