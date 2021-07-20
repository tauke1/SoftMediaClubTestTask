using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using SoftMediaClubTestTask.Domain.Entities;
using SoftMediaClubTestTask.Infrastructure.Data;
using SoftMediaClubTestTask.Infrastructure.Queries.StudentQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftMediaClubTestTask.Tests.Queries
{
    class GetStudentsQueryTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task GetStudents_ReturnsRightListOfUsers()
        {
            // arrange
            var students = new List<Student> {
                new Student
                {
                    DateOfBirth = new DateTime(1980, 1, 1),
                    Firstname = "Test",
                    Lastname = "Test",
                    Middlename = "Test",
                },
                new Student
                {
                    DateOfBirth = new DateTime(1981, 1, 1),
                    Firstname = "Test1",
                    Lastname = "Test1",
                    Middlename = "Test1",
                }
            };

            var performanceType = new AcademicPerformanceType
            {
                Code = "A",
                Description = "Отлично",
            };

            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            builder.UseInMemoryDatabase(databaseName: "test");
            DbContextOptions<ApplicationDbContext> options = builder.Options;
            using (var context = new ApplicationDbContext(options))
            {
                context.Database.EnsureDeleted();
                context.AcademicPerformanceTypes.Add(performanceType);
                await context.SaveChangesAsync();
                foreach (Student student in students)
                {
                    student.AcademicPerformanceTypeId = performanceType.Id;
                    context.Students.Add(student);
                }

                await context.SaveChangesAsync();
                var query = new GetStudentsQuery(context);

                // act
                IList<Student> studentsFromDb = await query.ExecuteAsync();

                // assert
                Assert.IsNotNull(studentsFromDb);
                Assert.AreEqual(students, studentsFromDb);
            }
        }
    }
}
