using SoftMediaClubTestTask.Application.Interfaces.Queries.Base;
using SoftMediaClubTestTask.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftMediaClubTestTask.Application.Interfaces.Queries.AcademicPerformanceTypeQueries
{
    public interface IGetAcademicPerformanceTypesQuery : IGetListOfEntitiesQuery<AcademicPerformanceType>
    {
    }
}
