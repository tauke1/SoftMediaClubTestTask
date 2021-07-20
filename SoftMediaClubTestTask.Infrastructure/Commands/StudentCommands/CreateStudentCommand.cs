using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SoftMediaClubTestTask.Application.Interfaces.Commands.StudentCommands;
using SoftMediaClubTestTask.Domain.Entities;
using SoftMediaClubTestTask.Infrastructure.Data;

namespace SoftMediaClubTestTask.Infrastructure.Commands.StudentCommands
{
    public class CreateStudentCommand : ICreateStudentCommand
    {
        private readonly DbSet<Student> _table;
        private readonly ApplicationDbContext _applicationDbContext;
        public CreateStudentCommand(ApplicationDbContext applicationDbContext)
        {
            _table = applicationDbContext.Students;
            _applicationDbContext = applicationDbContext;
        }

        public async Task ExecuteAsync(Student student)
        {
            if (student == null)
                throw new ArgumentNullException(nameof(student));

            student.CreateDate = DateTime.Now;
            await _table.AddAsync(student);
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
