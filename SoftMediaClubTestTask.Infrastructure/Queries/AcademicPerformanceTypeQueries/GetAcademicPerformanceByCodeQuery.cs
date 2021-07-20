using Microsoft.EntityFrameworkCore;
using SoftMediaClubTestTask.Application.Interfaces.Queries.AcademicPerformanceTypeQueries;
using SoftMediaClubTestTask.Domain.Entities;
using SoftMediaClubTestTask.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftMediaClubTestTask.Infrastructure.Queries.AcademicPerformanceTypeQueries
{
    public class GetAcademicPerformanceTypeByCodeQuery : IGetAcademicPerformanceTypeByCodeQuery
    {
        private readonly DbSet<AcademicPerformanceType> _table;
        public GetAcademicPerformanceTypeByCodeQuery(ApplicationDbContext applicationDbContext)
        {
            _table = applicationDbContext.AcademicPerformanceTypes;
        }

        public Task<AcademicPerformanceType> ExecuteAsync(string code)
        {
            if (code == null)
                throw new ArgumentNullException(nameof(code));

            if (code.Trim() == string.Empty)
                throw new ArgumentException("Argument cannot be empty or contains only spaces", nameof(code));

            return _table.Where(a => a.Code == code).SingleOrDefaultAsync();
        }
    }
}
