using Microsoft.EntityFrameworkCore;
using SoftMediaClubTestTask.Application.Interfaces.Commands.AcademicPerformanceTypeCommands;
using SoftMediaClubTestTask.Application.Interfaces.Commands.StudentCommands;
using SoftMediaClubTestTask.Domain.Entities;
using SoftMediaClubTestTask.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftMediaClubTestTask.Infrastructure.Commands.AcademicPerformanceTypeCommands
{
    public class DeleteAcademicPerformanceTypeCommand : IDeleteAcademicPerformanceTypeCommand
    {
        private readonly DbSet<AcademicPerformanceType> _table;
        private readonly ApplicationDbContext _applicationDbContext;
        public DeleteAcademicPerformanceTypeCommand(ApplicationDbContext applicationDbContext)
        {
            _table = applicationDbContext.AcademicPerformanceTypes;
            _applicationDbContext = applicationDbContext;
        }

        public async Task ExecuteAsync(AcademicPerformanceType academicPerformanceType)
        {
            if (academicPerformanceType == null)
                throw new ArgumentNullException(nameof(academicPerformanceType));

            _table.Remove(academicPerformanceType);
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
