using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
// ReSharper disable UnusedMethodReturnValue.Global

namespace EnumerableExamplesEntity;

public class SchoolService
{
    private readonly SchoolContext _schoolContext;

    public SchoolService(SchoolContext p_schoolContext)
    {
        _schoolContext = p_schoolContext;
    }

    public async Task AddStudent(string name, int grade)
    {
        _schoolContext.Students.Add(new Student
        {
            Id = 0,
            Name = name,
            Grade = grade
        });

        await _schoolContext.SaveChangesAsync();
    }

    public async Task<Student[]> GetStudents()
    {
        return await _schoolContext.Students.ToArrayAsync();
    }

    public Student[] GetStudentsFilter(Expression<Func<Student, bool>> filter)
    {
        return _schoolContext.Students.Where(filter).ToArray();
    }

    public Student[] GetStudentsFilter(Func<Student, bool> filter)
    {
        return _schoolContext.Students.Where(filter).ToArray();
    }

    public IEnumerable<Student> GetStudentsEnumerable()
    {
        return _schoolContext.Students;
    }
}
