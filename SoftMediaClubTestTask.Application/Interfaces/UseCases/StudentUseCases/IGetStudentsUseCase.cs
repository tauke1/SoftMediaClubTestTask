using SoftMediaClubTestTask.Application.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SoftMediaClubTestTask.Application.UseCases.Students
{
    public interface IGetStudentsUseCase
    {
        Task<IList<StudentDto>> ExecuteAsync();
    }
}
