using SoftMediaClubTestTask.Application.Interfaces.Commands.AcademicPerformanceTypeCommands;
using SoftMediaClubTestTask.Application.Interfaces.Commands.StudentCommands;
using SoftMediaClubTestTask.Application.Interfaces.Queries.AcademicPerformanceTypeQueries;
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
    public class UpdateAcademicPerformanceTypeInteractor : IUpdateAcademicPerformanceTypeUseCase
    {
        private const string ACADEMIC_PERFORMANCE_TYPE_ALREADY_EXISTS_ERROR = "Academic performance type by code {0} already exists";
        private readonly IGetAcademicPerformanceTypeQuery _getAcademicPerformanceTypeQuery;
        private readonly IGetAcademicPerformanceTypeByCodeQuery _getAcademicPerformanceTypeByCodeQuery;
        private readonly IUpdateAcademicPerformanceTypeCommand _updateAcademicPerformanceTypeCommand;
        public UpdateAcademicPerformanceTypeInteractor(IGetAcademicPerformanceTypeQuery getAcademicPerformanceTypeQuery, IGetAcademicPerformanceTypeByCodeQuery getAcademicPerformanceTypeByCodeQuery,
            IUpdateAcademicPerformanceTypeCommand updateAcademicPerformanceTypeCommand)
        {
            _getAcademicPerformanceTypeByCodeQuery = getAcademicPerformanceTypeByCodeQuery;
            _getAcademicPerformanceTypeQuery = getAcademicPerformanceTypeQuery;
            _updateAcademicPerformanceTypeCommand = updateAcademicPerformanceTypeCommand;
        }

        public async Task ExecuteAsync(AcademicPerformanceTypeDto academicPerformanceType)
        {
            if (academicPerformanceType == null)
                throw new ArgumentNullException(nameof(academicPerformanceType));

            if (academicPerformanceType.Id == 0)
                throw new ArgumentException($"Property {nameof(academicPerformanceType.Id)} must have zero value", nameof(academicPerformanceType));

            AcademicPerformanceType performanceTypeEntity = await GetAcademicPerformanceTypeAsync(academicPerformanceType.Id);
            await CheckThatAcademicPerformanceTypeBySameCodeAndDifferentIdNotExists(academicPerformanceType.Code, academicPerformanceType.Id);
            performanceTypeEntity.Code = academicPerformanceType.Code;
            performanceTypeEntity.Description = academicPerformanceType.Description;
            await _updateAcademicPerformanceTypeCommand.ExecuteAsync(performanceTypeEntity);
        }

        private async Task<AcademicPerformanceType> GetAcademicPerformanceTypeAsync(int id)
        {
            AcademicPerformanceType academicPerformanceType = await _getAcademicPerformanceTypeQuery.ExecuteAsync(id);
            if (academicPerformanceType == null)
            {
                throw new EntityNotFoundException(nameof(AcademicPerformanceType), id);
            }

            return academicPerformanceType;
        }

        private async Task CheckThatAcademicPerformanceTypeBySameCodeAndDifferentIdNotExists(string code, int id)
        {
            AcademicPerformanceType academicPerformanceType = await _getAcademicPerformanceTypeByCodeQuery.ExecuteAsync(code);
            if (academicPerformanceType != null && academicPerformanceType.Id != id)
            {
                string errorMessage = string.Format(ACADEMIC_PERFORMANCE_TYPE_ALREADY_EXISTS_ERROR, code);
                throw new BadArgumentException(errorMessage);
            }
        }
    }
}
