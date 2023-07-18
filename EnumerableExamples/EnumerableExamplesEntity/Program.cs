using System;
using System.Linq;
using System.Linq.Expressions;
using EnumerableExamplesEntity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

var config = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();

var services = new ServiceCollection();

services.AddLogging(builder => builder.AddConsole());
services.AddSqlServer<SchoolContext>(config["Conn"]);
services.AddTransient<SchoolService>();

var sp = services.BuildServiceProvider();

var logger = sp.GetRequiredService<ILogger<Program>>();
var school = sp.GetRequiredService<SchoolService>();

logger.LogMessage("GetStudents all");

await school.GetStudents();

Func<Student, bool> func = student => student.Grade > 7;
Expression<Func<Student, bool>> expression = student => student.Grade > 7;

logger.LogMessage("GetStudents func");

school.GetStudentsFilter(func);

logger.LogMessage("GetStudents expression");

school.GetStudentsFilter(expression);

logger.LogMessage("GetStudents enumerable");

var students = school.GetStudentsEnumerable().Where(func).ToArray();
