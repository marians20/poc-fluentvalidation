// // ------------------------------------------------------------------------------------
// IPeopleService.cs
// (c) 2024
// By maria
// // ------------------------------------------------------------------------------------

using Contracts.Dtos;

namespace Contracts.Services;

public interface IPeopleService
{
    Guid Create(CreatePersonDto person);
    Task<IEnumerable<PersonDto>> GetAllAsync();
}