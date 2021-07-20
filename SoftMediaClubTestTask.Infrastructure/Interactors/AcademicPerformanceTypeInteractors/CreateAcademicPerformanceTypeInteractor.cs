using SoftMediaClubTestTask.Application.Interfaces.Commands.AcademicPerformanceTypeCommands;
using SoftMediaClubTestTask.Application.Interfaces.Commands.StudentCommands;
using SoftMediaClubTestTask.Application.Interfaces.Queries.AcademicPerformanceTypeQueries;
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
    public class CreateAcademicPerformanceTypeInteractor : ICreateAcademicPerformanceTypeUseCase
    {
        private readonly IGetAcademicPerformanceTypeByCodeQuery _getAcademicPerformanceTypeByCodeQuery;
        private readonly ICreateAcademicPerformanceTypeCommand _createAcademicPerformanceTypeCommand;
        private const string ACADEMIC_PERFORMANCE_TYPE_ALREADY_EXISTS_ERROR = "Academic performance type by code {0} already exists";
        public CreateAcademicPerformanceTypeInteractor(IGetAcademicPerformanceTypeByCodeQuery getAcademicPerformanceTypeByCodeQuery,
            ICreateAcademicPerformanceTypeCommand createAcademicPerformanceTypeCommand)
        {
            _getAcademicPerformanceTypeByCodeQuery = getAcademicPerformanceTypeByCodeQuery;
            _createAcademicPerformanceTypeCommand = createAcademicPerformanceTypeCommand;
        }

        public async Task ExecuteAsync(AcademicPerformanceTypeDto academicPerformanceType)
        {
            if (academicPerformanceType == null)
                throw new ArgumentNullException(nameof(academicPerformanceType));

            if (academicPerformanceType.Id != 0)
                throw new ArgumentException($"Property {nameof(academicPerformanceType.Id)} must have zero value", nameof(academicPerformanceType));

            await CheckThatAcademicPerformanceTypeBySameCodeNotExists(academicPerformanceType.Code);
            var performanceTypeEntity = new AcademicPerformanceType
            { 
                Code = academicPerformanceType.Code,
                Description = academicPerformanceType.Description
            };

            await _createAcademicPerformanceTypeCommand.ExecuteAsync(performanceTypeEntity);
            academicPerformanceType.Id = performanceTypeEntity.Id;
        }

        private async Task CheckThatAcademicPerformanceTypeBySameCodeNotExists(string code)
        {
            AcademicPerformanceType academicPerformanceType = await _getAcademicPerformanceTypeByCodeQuery.ExecuteAsync(code);
            if (academicPerformanceType != null)
            {
                string errorMessage = string.Format(ACADEMIC_PERFORMANCE_TYPE_ALREADY_EXISTS_ERROR, code);
                throw new BadArgumentException(errorMessage);
            }
        }
    }
}
