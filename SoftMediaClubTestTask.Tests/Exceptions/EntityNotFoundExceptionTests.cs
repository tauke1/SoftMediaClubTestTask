using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using SoftMediaClubTestTask.Domain.Exceptions;
using SoftMediaClubTestTask.Infrastructure.Data;
using SoftMediaClubTestTask.Infrastructure.Interactors.StudentInteractors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftMediaClubTestTask.Tests.Exceptions
{
    class EntityNotFoundExceptionTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void CreateEntityNotFoundExceptionByCertainEntityTypeAndEntityId_ExceptionMessageCorrespondsToEntityTypeAndEntityId()
        {
            // arrange
            var entityType = "Student";
            var entityId = 1;
            var exception = new EntityNotFoundException(entityType, entityId);
            var exceptedExceptionMessage = $"Entity with type {entityType} and primary key {entityId} not found";

            // act
            var exceptionMessage = exception.Message;

            // assert
            Assert.AreEqual(exceptedExceptionMessage, exceptionMessage);
        }
    }
}
