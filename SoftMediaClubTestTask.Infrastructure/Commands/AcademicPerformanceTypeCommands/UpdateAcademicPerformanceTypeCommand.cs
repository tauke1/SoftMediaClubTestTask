using Microsoft.EntityFrameworkCore;
using SoftMediaClubTestTask.Application.Interfaces.Commands.AcademicPerformanceTypeCommands;
using SoftMediaClubTestTask.Domain.Entities;
using SoftMediaClubTestTask.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftMediaClubTestTask.Infrastructure.Commands.AcademicPerformanceTypeCommands
{
    public class UpdateAcademicPerformanceTypeCommand : IUpdateAcademicPerformanceTypeCommand
    {
        private readonly DbSet<AcademicPerformanceType> _table;
        private readonly ApplicationDbContext _applicationDbContext;
        public UpdateAcademicPerformanceTypeCommand(ApplicationDbContext applicationDbContext)
        {
            _table = applicationDbContext.AcademicPerformanceTypes;
            _applicationDbContext = applicationDbContext;
        }

        public async Task ExecuteAsync(AcademicPerformanceType academicPerformanceType) 
        {
            if (academicPerformanceType == null)
                throw new ArgumentNullException(nameof(academicPerformanceType));

            _table.Update(academicPerformanceType);
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
