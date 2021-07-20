using SoftMediaClubTestTask.Application.Interfaces.Commands.StudentCommands;
using SoftMediaClubTestTask.Domain.Entities;
using SoftMediaClubTestTask.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftMediaClubTestTask.Infrastructure.Commands.StudentCommands
{
    public class UpdateStudentCommand : IUpdateStudentCommand
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public UpdateStudentCommand(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task ExecuteAsync(Student student) 
        {
            if (student == null)
                throw new ArgumentNullException(nameof(student));


            _applicationDbContext.Students.Update(student);
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
