using System;
using System.Threading.Tasks;

namespace SoftMediaClubTestTask.Application.UseCases.Students
{
    public interface IDeleteStudentUseCase
    {
        Task ExecuteAsync(int id);
    }
}
