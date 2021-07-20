using SoftMediaClubTestTask.Application.Interfaces.Queries.AcademicPerformanceTypeQueries;
using SoftMediaClubTestTask.Application.Interfaces.Queries.StudentQueries;
using SoftMediaClubTestTask.Application.Models;
using SoftMediaClubTestTask.Application.UseCases.AcademicPerformanceTypes;
using SoftMediaClubTestTask.Application.UseCases.Students;
using SoftMediaClubTestTask.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftMediaClubTestTask.Infrastructure.Interactors.AcademicPerformanceTypeInteractors
{
    public class GetAcademicPerformanceTypesInteractor : IGetAcademicPerformanceTypesUseCase
    {
        private readonly IGetAcademicPerformanceTypesQuery _getAcademicPerformanceTypesQuery;
        public GetAcademicPerformanceTypesInteractor(IGetAcademicPerformanceTypesQuery getAcademicPerformanceTypesQuery)
        {
            _getAcademicPerformanceTypesQuery = getAcademicPerformanceTypesQuery;
        }

        public async Task<IList<AcademicPerformanceTypeDto>> ExecuteAsync()
        {
            IList<AcademicPerformanceType> academicPerformanceTypes = await _getAcademicPerformanceTypesQuery.ExecuteAsync();
            return academicPerformanceTypes.Select(a => new AcademicPerformanceTypeDto
            {
                Id = a.Id,
                Code = a.Code,
                Description = a.Description
            }).ToList();
        }
    }
}
