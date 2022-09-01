namespace FluentValidationsPoc;

internal class PersonDto
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public DateTime BirthDate { get; set; }

    public int Rating { get; set; }
}