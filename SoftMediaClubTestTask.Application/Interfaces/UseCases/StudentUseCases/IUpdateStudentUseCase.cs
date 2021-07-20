using SoftMediaClubTestTask.Application.Models;
using System;
using System.Threading.Tasks;

namespace SoftMediaClubTestTask.Application.UseCases.Students
{
    public interface IUpdateStudentUseCase
    {
        Task ExecuteAsync(StudentDto student);
    }
}
