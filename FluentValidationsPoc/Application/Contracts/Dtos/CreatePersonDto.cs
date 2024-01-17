namespace Contracts.Dtos;
public class CreatePersonDto
{
    public string? Name { get; set; }

    public DateTime BirthDate { get; set; }

    public int Rating { get; set; }
}
