using Microsoft.EntityFrameworkCore;

namespace EnumerableExamplesEntity;

public class SchoolContext : DbContext
{
    public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
    {
    }

    public required DbSet<Student> Students { get; set; }
}

public class Student
{
    public required long Id { get; set; }

    public required string Name { get; set; }

    public required int Grade { get; set; }
}
