using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using SoftMediaClubTestTask.Domain.Entities;
using SoftMediaClubTestTask.Infrastructure.Commands.StudentCommands;
using SoftMediaClubTestTask.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftMediaClubTestTask.Tests.Commands
{
    public class DeleteStudentInteractorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task DeleteStudent_DeleteDateIsFilled()
        {
            // arrange
            Student student = new Student
            {
                DateOfBirth = new DateTime(1980, 1, 1),
                Firstname = "Test",
                Lastname = "Test",
                Middlename = "Test",
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
                student.AcademicPerformanceTypeId = performanceType.Id;
                context.Students.Add(student);
                await context.SaveChangesAsync();
                var command = new DeleteStudentCommand(context);
                
                // act
                await command.ExecuteAsync(student);

                // assert
                Assert.IsNotNull(student.DeleteDate);
                List<Student> studentsInDb = context.Students.ToList();
                Assert.IsEmpty(studentsInDb);
            }

        }
    }
}
