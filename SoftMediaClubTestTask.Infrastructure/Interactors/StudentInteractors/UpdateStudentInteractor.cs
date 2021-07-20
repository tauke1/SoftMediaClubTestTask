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
    public class UpdateStudentInteractor : IUpdateStudentUseCase
    {
        private static string ACADEMIC_PERFORMANCE_TYPE_NOT_FOUND_ERROR = "Academic performance type {0} not found";
        private readonly IGetAcademicPerformanceTypeQuery _getAcademicPerformanceTypeQuery;
        private readonly IGetStudentQuery _getStudentQuery;
        private readonly IUpdateStudentCommand _updateStudentCommand;
        public UpdateStudentInteractor(IGetAcademicPerformanceTypeQuery getAcademicPerformanceTypeQuery, IUpdateStudentCommand updateStudentCommand,
            IGetStudentQuery getStudentQuery)
        {
            _getAcademicPerformanceTypeQuery = getAcademicPerformanceTypeQuery;
            _updateStudentCommand = updateStudentCommand;
            _getStudentQuery = getStudentQuery;
        }

        public async Task ExecuteAsync(StudentDto student)
        {
            if (student == null)
                throw new ArgumentNullException(nameof(student));

            if (student.Id == 0)
                throw new ArgumentException($"Property {nameof(student.Id)} must have zero value", nameof(student));

            await CheckThatAcademicPerformanceTypeExistsAsync(student.AcademicPerformanceTypeId);
            Student studentEntity = await GetStudentAsync(student.Id);
            studentEntity.AcademicPerformanceTypeId = student.AcademicPerformanceTypeId;
            studentEntity.Lastname = student.Lastname;
            studentEntity.Firstname = student.Firstname;
            studentEntity.Middlename = student.Middlename;
            studentEntity.DateOfBirth = student.DateOfBirth;
            await _updateStudentCommand.ExecuteAsync(studentEntity);
        }

        private async Task CheckThatAcademicPerformanceTypeExistsAsync(int academicPerformanceTypeId)
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
