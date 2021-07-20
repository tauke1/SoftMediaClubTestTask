using System;
using System.Threading.Tasks;

namespace SoftMediaClubTestTask.Application.UseCases.AcademicPerformanceTypes
{
    public interface IDeleteAcademicPerformanceTypeUseCase
    {
        Task ExecuteAsync(int id);
    }
}
