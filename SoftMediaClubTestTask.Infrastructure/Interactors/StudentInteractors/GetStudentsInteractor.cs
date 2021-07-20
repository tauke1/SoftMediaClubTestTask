using SoftMediaClubTestTask.Application.Interfaces.Queries.StudentQueries;
using SoftMediaClubTestTask.Application.Models;
using SoftMediaClubTestTask.Application.UseCases.Students;
using SoftMediaClubTestTask.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftMediaClubTestTask.Infrastructure.Interactors.StudentInteractors
{
    public class GetStudentsInteractor : IGetStudentsUseCase
    {
        private readonly IGetStudentsQuery _getStudentsQuery;
        public GetStudentsInteractor(IGetStudentsQuery getStudentsQuery)
        {
            _getStudentsQuery = getStudentsQuery;
        }

        public async Task<IList<StudentDto>> ExecuteAsync()
        {
            IList<Student> students = await _getStudentsQuery.ExecuteAsync();
            return students.Select(s => new StudentDto {
                Id = s.Id,
                AcademicPerformanceTypeId = s.AcademicPerformanceTypeId,
                DateOfBirth = s.DateOfBirth,
                Firstname = s.Firstname,
                Lastname = s.Lastname,
                Middlename = s.Middlename
            }).ToList();
        }
    }
}
