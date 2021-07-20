using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using SoftMediaClubTestTask.Application.Interfaces.Commands.StudentCommands;
using SoftMediaClubTestTask.Application.Interfaces.Queries.StudentQueries;
using SoftMediaClubTestTask.Application.Models;
using SoftMediaClubTestTask.Application.Queries.Interfaces.AcademicPerformanceTypeQueries;
using SoftMediaClubTestTask.Domain.Entities;
using SoftMediaClubTestTask.Domain.Exceptions;
using SoftMediaClubTestTask.Infrastructure.Data;
using SoftMediaClubTestTask.Infrastructure.Interactors.StudentInteractors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftMediaClubTestTask.Tests.UseCases
{
    class CreateStudentUseCaseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task CreateStudent_SuccessAndCheckThatStudentIdIsEqualsToOne()
        {
            // arrange
            var expectedStudentId = 1;
            var performanceType = new AcademicPerformanceType {
                Code = "A",
                Description = "Отлично",
                Id = 1
            };
            var student = new StudentDto
            {
                Middlename = "Test",
                Firstname = "Test",
                Lastname = "Test",
                DateOfBirth = new DateTime(1980, 1 ,1),
                AcademicPerformanceTypeId = 1
            };

            #region mocking
            var getAcademicPerformanceTypeQueryMock = new Mock<IGetAcademicPerformanceTypeQuery>();
            getAcademicPerformanceTypeQueryMock
                .Setup(m => m.ExecuteAsync(student.AcademicPerformanceTypeId))
                .ReturnsAsync(performanceType);
            var getStudentQueryMock = new Mock<IGetStudentQuery>();
            getStudentQueryMock.Setup(m => m.ExecuteAsync(student.Id)).ReturnsAsync(default(Student));
            var createStudentCommandMock = new Mock<ICreateStudentCommand>();
            createStudentCommandMock.Setup(m => m.ExecuteAsync(It.IsAny<Student>())).Callback<Student>(s => s.Id = 1);
            #endregion
            var interactor = new CreateStudentInteractor(getAcademicPerformanceTypeQueryMock.Object, createStudentCommandMock.Object, getStudentQueryMock.Object);

            // act
            await interactor.ExecuteAsync(student);

            // assert
            Assert.AreEqual(expectedStudentId, student.Id);
        }

        [Test]
        public void CreateStudentWithNotExistingAcademicPerformanceType_FailsOnBadArgumentException()
        {
            // arrange
            var student = new StudentDto
            {
                Middlename = "Test",
                Firstname = "Test",
                Lastname = "Test",
                DateOfBirth = new DateTime(1980, 1, 1),
                AcademicPerformanceTypeId = 2
            };

            #region mocking
            var getAcademicPerformanceTypeQueryMock = new Mock<IGetAcademicPerformanceTypeQuery>();
            getAcademicPerformanceTypeQueryMock
                .Setup(m => m.ExecuteAsync(student.AcademicPerformanceTypeId))
                .ReturnsAsync(default(AcademicPerformanceType));
            var getStudentQueryMock = new Mock<IGetStudentQuery>();
            getStudentQueryMock
                .Setup(m => m.ExecuteAsync(student.Id))
                .ReturnsAsync(default(Student));
            var createStudentCommandMock = new Mock<ICreateStudentCommand>();
            createStudentCommandMock
                .Setup(m => m.ExecuteAsync(It.IsAny<Student>()))
                .Callback<Student>(s => s.Id = 1);
            #endregion
            var interactor = new CreateStudentInteractor(getAcademicPerformanceTypeQueryMock.Object, createStudentCommandMock.Object, getStudentQueryMock.Object);

            // act and assert
            Assert.ThrowsAsync<BadArgumentException>(async () => await interactor.ExecuteAsync(student));
        }
    }
}
