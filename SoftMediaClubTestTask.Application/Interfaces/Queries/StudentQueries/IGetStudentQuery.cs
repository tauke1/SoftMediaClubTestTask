using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftMediaClubTestTask.Application.Interfaces.Queries.Base;
using SoftMediaClubTestTask.Domain.Entities;

namespace SoftMediaClubTestTask.Application.Interfaces.Queries.StudentQueries
{
    public interface IGetStudentQuery : IGetEntityQuery<Student, int>
    {
    }
}
