using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SoftMediaClubTestTask.Application.Interfaces.Commands.AcademicPerformanceTypeCommands;
using SoftMediaClubTestTask.Application.Interfaces.Commands.StudentCommands;
using SoftMediaClubTestTask.Domain.Entities;
using SoftMediaClubTestTask.Infrastructure.Data;

namespace SoftMediaClubTestTask.Infrastructure.Commands.AcademicPerformanceTypeCommands
{
    public class CreateAcademicPerformanceTypeCommand : ICreateAcademicPerformanceTypeCommand
    {
        private readonly DbSet<AcademicPerformanceType> _table;
        private readonly ApplicationDbContext _applicationDbContext;
        public CreateAcademicPerformanceTypeCommand(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            _table = applicationDbContext.AcademicPerformanceTypes;
        }

        public async Task ExecuteAsync(AcademicPerformanceType academicPerformanceType)
        {
            if (academicPerformanceType == null)
                throw new ArgumentNullException(nameof(academicPerformanceType));

            await _table.AddAsync(academicPerformanceType);
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
