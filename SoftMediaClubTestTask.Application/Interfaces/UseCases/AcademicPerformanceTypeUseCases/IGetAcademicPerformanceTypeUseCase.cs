using SoftMediaClubTestTask.Application.Models;
using System;
using System.Threading.Tasks;

namespace SoftMediaClubTestTask.Application.UseCases.AcademicPerformanceTypes
{
    public interface IGetAcademicPerformanceTypeUseCase
    {
        Task<AcademicPerformanceTypeDto> ExecuteAsync(int id);
    }
}
