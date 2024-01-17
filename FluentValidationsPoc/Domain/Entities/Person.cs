namespace Entities;
public class Person : EntityBase
{
    public string? Name { get; set; }

    public DateTime BirthDate { get; set; }

    public int Rating { get; set; }
}
