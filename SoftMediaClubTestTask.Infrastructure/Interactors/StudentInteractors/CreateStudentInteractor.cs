using SoftMediaClubTestTask.Application.Interfaces.Commands.StudentCommands;
using SoftMediaClubTestTask.Application.Interfaces.Queries.StudentQueries;
using SoftMediaClubTestTask.Application.Models;
using SoftMediaClubTestTask.Application.Queries.Interfaces.AcademicPerformanceTypeQueries;
using SoftMediaClubTestTask.Application.UseCases.Students;
using SoftMediaClubTestTask.Domain.Entities;
using SoftMediaClubTestTask.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftMediaClubTestTask.Infrastructure.Interactors.StudentInteractors
{
    public class CreateStudentInteractor : ICreateStudentUseCase
    {
        private static string ACADEMIC_PERFORMANCE_TYPE_NOT_FOUND_ERROR = "Academic performance type {0} not found";
        private readonly IGetAcademicPerformanceTypeQuery _getAcademicPerformanceTypeQuery;
        private readonly IGetStudentQuery _getStudentQuery;
        private readonly ICreateStudentCommand _createStudentCommand;
        public CreateStudentInteractor(IGetAcademicPerformanceTypeQuery getAcademicPerformanceTypeQuery, ICreateStudentCommand createStudentCommand,
            IGetStudentQuery getStudentQuery)
        {
            _getAcademicPerformanceTypeQuery = getAcademicPerformanceTypeQuery;
            _createStudentCommand = createStudentCommand;
            _getStudentQuery = getStudentQuery;
        }

        public async Task ExecuteAsync(StudentDto student)
        {
            if (student == null)
                throw new ArgumentNullException(nameof(student));

            if (student.Id != 0)
                throw new ArgumentException($"Property {nameof(student.Id)} must have zero value", nameof(student));

            await CheckThatAcademicPerformanceTypeExists(student.AcademicPerformanceTypeId);
            var studentEntity = new Student
            { 
                AcademicPerformanceTypeId = student.AcademicPerformanceTypeId,
                Lastname = student.Lastname,
                Firstname = student.Firstname,
                Middlename = student.Middlename,
                DateOfBirth = student.DateOfBirth
            };

            await _createStudentCommand.ExecuteAsync(studentEntity);
            student.Id = studentEntity.Id;
        }

        private async Task CheckThatAcademicPerformanceTypeExists(int academicPerformanceTypeId)
        {
            AcademicPerformanceType academicPerformanceType = await _getAcademicPerformanceTypeQuery.ExecuteAsync(academicPerformanceTypeId);
            if (academicPerformanceType == null)
            {
                string errorMessage = string.Format(ACADEMIC_PERFORMANCE_TYPE_NOT_FOUND_ERROR, academicPerformanceTypeId);
                throw new BadArgumentException(errorMessage);
            }
        }

        private async Task<Student> GetStudentAsync(int id)
        {
            Student student = await _getStudentQuery.ExecuteAsync(id);
            if (student == null)
                throw new EntityNotFoundException(nameof(Student), id);

            return student;
        }
    }
}
