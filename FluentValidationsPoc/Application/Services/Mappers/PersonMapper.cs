using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Contracts.Dtos;
using Entities;

namespace Services.Mappers;
public sealed class PersonMapper : Profile
{
    public PersonMapper()
    {
        CreateMap<CreatePersonDto, Person>();
        CreateMap<Person, PersonDto>().ReverseMap();
    }
}
