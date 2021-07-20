using SoftMediaClubTestTask.Application.Interfaces.Commands.Base;
using SoftMediaClubTestTask.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftMediaClubTestTask.Application.Interfaces.Commands.StudentCommands
{
    public interface IDeleteStudentCommand : IDeleteCommand<Student, int>
    {
    }
}
