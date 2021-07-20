using Microsoft.EntityFrameworkCore;
using SoftMediaClubTestTask.Application.Interfaces.Queries.AcademicPerformanceTypeQueries;
using SoftMediaClubTestTask.Application.Interfaces.Queries.Base;
using SoftMediaClubTestTask.Domain.Entities;
using SoftMediaClubTestTask.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftMediaClubTestTask.Infrastructure.Queries.AcademicPerformanceTypeQueries
{
    public class GetAcademicPerformanceTypesQuery : IGetAcademicPerformanceTypesQuery
    {
        private readonly DbSet<AcademicPerformanceType> _table;
        public GetAcademicPerformanceTypesQuery(ApplicationDbContext applicationDbContext) 
        {
            _table = applicationDbContext.AcademicPerformanceTypes;
        }

        public async Task<IList<AcademicPerformanceType>> ExecuteAsync()
        {
            return await _table.ToListAsync();
        }

    }
}
