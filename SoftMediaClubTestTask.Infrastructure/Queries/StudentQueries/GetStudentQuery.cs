using Microsoft.EntityFrameworkCore;
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
    public class GetStudentQuery : IGetStudentQuery
    {
        private readonly DbSet<Student> _table;
        public GetStudentQuery(ApplicationDbContext applicationDbContext)
        {
            _table = applicationDbContext.Students;
        }

        public async Task<Student> ExecuteAsync(int id)
        {
            return await _table.FindAsync(id);
        }
    }
}
