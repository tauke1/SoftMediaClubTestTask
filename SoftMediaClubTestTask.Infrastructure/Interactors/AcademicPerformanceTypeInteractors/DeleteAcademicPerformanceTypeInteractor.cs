using SoftMediaClubTestTask.Application.Interfaces.Commands.AcademicPerformanceTypeCommands;
using SoftMediaClubTestTask.Application.Interfaces.Commands.StudentCommands;
using SoftMediaClubTestTask.Application.Interfaces.Queries.StudentQueries;
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
    public class DeleteAcademicPerformanceTypeInteractor : IDeleteAcademicPerformanceTypeUseCase
    {
        private readonly IGetAcademicPerformanceTypeQuery _getAcademicPerformanceTypeQuery;
        private readonly IDeleteAcademicPerformanceTypeCommand _deleteAcademicPerformanceTypeCommand;
        public DeleteAcademicPerformanceTypeInteractor(IGetAcademicPerformanceTypeQuery getAcademicPerformanceTypeQuery, IDeleteAcademicPerformanceTypeCommand deleteAcademicPerformanceTypeCommand)
        {
            _getAcademicPerformanceTypeQuery = getAcademicPerformanceTypeQuery;
            _deleteAcademicPerformanceTypeCommand = deleteAcademicPerformanceTypeCommand;
        }

        public async Task ExecuteAsync(int id)
        {
            AcademicPerformanceType academicPerformanceType = await GetAcademicResponseTypeAsync(id);
            await _deleteAcademicPerformanceTypeCommand.ExecuteAsync(academicPerformanceType);
        }

        private async Task<AcademicPerformanceType> GetAcademicResponseTypeAsync(int id)
        {
            AcademicPerformanceType academicPerformanceType = await _getAcademicPerformanceTypeQuery.ExecuteAsync(id);
            if (academicPerformanceType == null)
                throw new EntityNotFoundException(nameof(AcademicPerformanceType), id);

            return academicPerformanceType;
        }
    }
}
