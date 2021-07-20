using Microsoft.EntityFrameworkCore;
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
    public class DeleteStudentCommand : IDeleteStudentCommand
    {
        private readonly DbSet<Student> _table;
        private readonly ApplicationDbContext _applicationDbContext;
        public DeleteStudentCommand(ApplicationDbContext applicationDbContext)
        {
            _table = applicationDbContext.Students;
            _applicationDbContext = applicationDbContext;
        }

        public async Task ExecuteAsync(Student student)
        {
            if (student == null)
                throw new ArgumentNullException(nameof(student));

            student.DeleteDate = DateTime.Now;
            _table.Update(student);
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
