using System.Text.Json;
using AutoMapper;
using Bogus;
using Contracts.Dtos;
using Contracts.Services;
using Microsoft.Extensions.Logging;
using Person = Entities.Person;

namespace Services.Services;
internal sealed class PeopleService : IPeopleService
{
    private readonly ILogger<PeopleService> logger;
    private readonly IMapper mapper;
    public PeopleService(IMapper mapper, ILogger<PeopleService> logger)
    {
        this.mapper = mapper;
        this.logger = logger;
    }

    public Guid Create(CreatePersonDto person)
    {
        logger.LogInformation($"Creating person {JsonSerializer.Serialize(person)}");
        return Guid.NewGuid();
    }

    public Task<IEnumerable<PersonDto>> GetAllAsync()
    {
        var faker = new Faker<Person>()
            .RuleFor(p => p.Id, f => f.Random.Guid())
            .RuleFor(p => p.Name, f => f.Person.FullName)
            .RuleFor(p => p.BirthDate, f => f.Person.DateOfBirth);

        var entities = faker.Generate(10);

        var dtos = mapper.Map<IEnumerable<PersonDto>>(entities);
        return Task.FromResult(dtos);
    }
}
