using SoftMediaClubTestTask.Application.Interfaces.Commands.StudentCommands;
using SoftMediaClubTestTask.Application.Interfaces.Queries.StudentQueries;
using SoftMediaClubTestTask.Application.Queries.Interfaces.AcademicPerformanceTypeQueries;
using SoftMediaClubTestTask.Application.UseCases.Students;
using SoftMediaClubTestTask.Domain.Entities;
using SoftMediaClubTestTask.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftMediaClubTestTask.Infrastructure.Interactors.StudentInteractors
{
    public class DeleteStudentInteractor : IDeleteStudentUseCase
    {
        private readonly IGetAcademicPerformanceTypeQuery _getAcademicPerformanceTypeQuery;
        private readonly IGetStudentQuery _getStudentQuery;
        private readonly IDeleteStudentCommand _deleteStudentCommand;
        public DeleteStudentInteractor(IGetAcademicPerformanceTypeQuery getAcademicPerformanceTypeQuery, IDeleteStudentCommand deleteStudentCommand,
            IGetStudentQuery getStudentQuery)
        {
            _getAcademicPerformanceTypeQuery = getAcademicPerformanceTypeQuery;
            _deleteStudentCommand = deleteStudentCommand;
            _getStudentQuery = getStudentQuery;
        }

        public async Task ExecuteAsync(int id)
        {
            Student student = await GetStudentAsync(id);
            await _deleteStudentCommand.ExecuteAsync(student);
        }

        private async Task<Student> GetStudentAsync(int id)
        {
            Student student = await _getStudentQuery.ExecuteAsync(id);
            if (student == null)
                throw new EntityNotFoundException(nameof(Student), id);

            return student;
        }
    }
}
