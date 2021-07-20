using Microsoft.EntityFrameworkCore;
using SoftMediaClubTestTask.Application.Interfaces.Queries.Base;
using SoftMediaClubTestTask.Application.Interfaces.Queries.StudentQueries;
using SoftMediaClubTestTask.Domain.Entities;
using SoftMediaClubTestTask.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftMediaClubTestTask.Infrastructure.Queries.StudentQueries
{
    public class GetStudentsQuery : IGetStudentsQuery
    {
        private readonly DbSet<Student> _table;
        public GetStudentsQuery(ApplicationDbContext applicationDbContext) 
        {
            _table = applicationDbContext.Students;
        }

        public async Task<IList<Student>> ExecuteAsync()
        {
            return await _table.ToListAsync();
        }

    }
}
