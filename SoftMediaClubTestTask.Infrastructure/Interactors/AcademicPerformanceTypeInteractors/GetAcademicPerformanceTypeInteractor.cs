using SoftMediaClubTestTask.Application.Interfaces.Queries.StudentQueries;
using SoftMediaClubTestTask.Application.Models;
using SoftMediaClubTestTask.Application.Queries.Interfaces.AcademicPerformanceTypeQueries;
using SoftMediaClubTestTask.Application.UseCases.AcademicPerformanceTypes;
using SoftMediaClubTestTask.Application.UseCases.Students;
using SoftMediaClubTestTask.Domain.Entities;
using SoftMediaClubTestTask.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftMediaClubTestTask.Infrastructure.Interactors.AcademicPerformanceTypeInteractors
{
    public class GetAcademicPerformanceTypeInteractor : IGetAcademicPerformanceTypeUseCase
    {
        private readonly IGetAcademicPerformanceTypeQuery _getAcademicPerformanceTypeQuery;
        public GetAcademicPerformanceTypeInteractor(IGetAcademicPerformanceTypeQuery getAcademicPerformanceTypeQuery)
        {
            _getAcademicPerformanceTypeQuery = getAcademicPerformanceTypeQuery; 
        }

        public async Task<AcademicPerformanceTypeDto> ExecuteAsync(int id)
        {
            AcademicPerformanceType performanceTypeEntity = await _getAcademicPerformanceTypeQuery.ExecuteAsync(id);
            if (performanceTypeEntity == null)
                throw new EntityNotFoundException(nameof(AcademicPerformanceType), id);

            return new AcademicPerformanceTypeDto
            {
                Id = performanceTypeEntity.Id,
                Code = performanceTypeEntity.Code,
                Description = performanceTypeEntity.Description
            }; ;
        }
    }
}
