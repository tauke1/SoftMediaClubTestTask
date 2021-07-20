using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoftMediaClubTestTask.API.Models;
using SoftMediaClubTestTask.Application.UseCases.Students;
using SoftMediaClubTestTask.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftMediaClubTestTask.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly ICreateStudentUseCase _createStudentUseCase;
        private readonly IUpdateStudentUseCase _updateStudentUseCase;
        private readonly IDeleteStudentUseCase _deleteStudentUseCase;
        private readonly IGetStudentUseCase _getStudentUseCase;
        private readonly IGetStudentsUseCase _getStudentsUseCase;
        public StudentsController(
            ICreateStudentUseCase createStudentUseCase,
            IUpdateStudentUseCase updateStudentUseCase,
            IDeleteStudentUseCase deleteStudentUseCase,
            IGetStudentUseCase getStudentUseCase,
            IGetStudentsUseCase getStudentsUseCase)
        {
            _createStudentUseCase = createStudentUseCase;
            _updateStudentUseCase = updateStudentUseCase;
            _deleteStudentUseCase = deleteStudentUseCase;
            _getStudentsUseCase = getStudentsUseCase;
            _getStudentUseCase = getStudentUseCase;
        }

        /// <summary>
        /// Get list of students
        /// </summary>
        /// <returns></returns>
        [HttpGet, ProducesResponseType(typeof(List<Student>), 200)]
        public async Task<IActionResult> GetAll()
        {
            IList<StudentDto> students = await _getStudentsUseCase.ExecuteAsync();
            return Ok(students.Select(s => new Student
            {
                Id = s.Id,
                Firstname = s.Firstname,
                Lastname = s.Lastname,
                AcademicPerformanceTypeId = s.AcademicPerformanceTypeId,
                DateOfBirth = s.DateOfBirth,
                Middlename = s.Middlename
            }).ToList());
        }

        /// <summary>
        /// Get student
        /// </summary>
        /// <param name="id">Identificator</param>
        /// <returns></returns>
        [HttpGet("{id}"), ProducesResponseType(typeof(Student), 200)]
        public async Task<IActionResult> Get(int id)
        {
            StudentDto student = await _getStudentUseCase.ExecuteAsync(id);
            return Ok(new Student
            {
                Id = student.Id,
                Firstname = student.Firstname,
                Lastname = student.Lastname,
                AcademicPerformanceTypeId = student.AcademicPerformanceTypeId,
                DateOfBirth = student.DateOfBirth,
                Middlename = student.Middlename
            }); ;
        }

        /// <summary>
        /// Create student
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPost, ProducesResponseType(typeof(Student), 200)]
        public async Task<IActionResult> Create([FromBody] Student student)
        {
            StudentDto studentDto = new StudentDto
            {
                Firstname = student.Firstname,
                Lastname = student.Lastname,
                AcademicPerformanceTypeId = student.AcademicPerformanceTypeId,
                DateOfBirth = student.DateOfBirth,
                Middlename = student.Middlename
            };

            await _createStudentUseCase.ExecuteAsync(studentDto);
            student.Id = studentDto.Id;
            return Ok(student);
        }

        /// <summary>
        /// Update student
        /// </summary>
        /// <param name="id">Identificator</param>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPut("{id}"), ProducesResponseType(typeof(Student), 200)]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Student student)
        {
            if (id != student.Id)
                return BadRequest();

            StudentDto studentDto = new StudentDto
            {
                Id = student.Id,
                Firstname = student.Firstname,
                Lastname = student.Lastname,
                AcademicPerformanceTypeId = student.AcademicPerformanceTypeId,
                DateOfBirth = student.DateOfBirth,
                Middlename = student.Middlename
            };

            await _updateStudentUseCase.ExecuteAsync(studentDto);
            return Ok(student);
        }

        /// <summary>
        /// Delete student
        /// </summary>
        /// <param name="id">Identificator</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _deleteStudentUseCase.ExecuteAsync(id);
            return Ok();
        }
    }
}
