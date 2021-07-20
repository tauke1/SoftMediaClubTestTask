using SoftMediaClubTestTask.Application.Models;
using System;
using System.Threading.Tasks;

namespace SoftMediaClubTestTask.Application.UseCases.AcademicPerformanceTypes
{
    public interface IUpdateAcademicPerformanceTypeUseCase
    {
        Task ExecuteAsync(AcademicPerformanceTypeDto student);
    }
}
