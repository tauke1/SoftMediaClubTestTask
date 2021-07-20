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
    public class GetStudentInteractor : IGetStudentUseCase
    {
        private readonly IGetStudentQuery _getStudentQuery;
        public GetStudentInteractor(IGetStudentQuery getStudentQuery)
        {
            _getStudentQuery = getStudentQuery; 
        }

        public async Task<StudentDto> ExecuteAsync(int id)
        {
            Student studentEntity = await _getStudentQuery.ExecuteAsync(id);
            if (studentEntity == null)
                throw new EntityNotFoundException(nameof(Student), id);

            return new StudentDto
            {
                Id = studentEntity.Id,
                AcademicPerformanceTypeId = studentEntity.AcademicPerformanceTypeId,
                DateOfBirth = studentEntity.DateOfBirth,
                Firstname = studentEntity.Firstname,
                Lastname = studentEntity.Lastname,
                Middlename = studentEntity.Middlename
            }; ;
        }
    }
}
