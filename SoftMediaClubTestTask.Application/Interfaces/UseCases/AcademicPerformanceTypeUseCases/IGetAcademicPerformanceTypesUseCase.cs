using SoftMediaClubTestTask.Application.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SoftMediaClubTestTask.Application.UseCases.AcademicPerformanceTypes
{
    public interface IGetAcademicPerformanceTypesUseCase
    {
        Task<IList<AcademicPerformanceTypeDto>> ExecuteAsync();
    }
}
