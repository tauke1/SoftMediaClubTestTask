using Microsoft.EntityFrameworkCore;
using SoftMediaClubTestTask.Application.Interfaces.Queries.StudentQueries;
using SoftMediaClubTestTask.Application.Queries.Interfaces.AcademicPerformanceTypeQueries;
using SoftMediaClubTestTask.Domain.Entities;
using SoftMediaClubTestTask.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftMediaClubTestTask.Infrastructure.Queries.AcademicPerformanceTypeQueries
{
    public class GetAcademicPerformanceTypeQuery : IGetAcademicPerformanceTypeQuery
    {
        private readonly DbSet<AcademicPerformanceType> _table;
        public GetAcademicPerformanceTypeQuery(ApplicationDbContext applicationDbContext)
        {
            _table = applicationDbContext.AcademicPerformanceTypes;
        }

        public async Task<AcademicPerformanceType> ExecuteAsync(int id)
        {
            return await _table.FindAsync(id);
        }
    }
}
