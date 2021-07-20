using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoftMediaClubTestTask.API.Models;
using SoftMediaClubTestTask.Application.Models;
using SoftMediaClubTestTask.Application.UseCases.AcademicPerformanceTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftMediaClubTestTask.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcademicPerformanceTypesController : ControllerBase
    {
        private readonly ICreateAcademicPerformanceTypeUseCase _createAcademicPerformanceTypeUseCase;
        private readonly IUpdateAcademicPerformanceTypeUseCase _updateAcademicPerformanceTypeUseCase;
        private readonly IDeleteAcademicPerformanceTypeUseCase _deleteAcademicPerformanceTypeUseCase;
        private readonly IGetAcademicPerformanceTypeUseCase _getAcademicPerformanceTypeUseCase;
        private readonly IGetAcademicPerformanceTypesUseCase _getAcademicPerformanceTypesUseCase;
        public AcademicPerformanceTypesController(
            ICreateAcademicPerformanceTypeUseCase createAcademicPerformanceTypeUseCase,
            IUpdateAcademicPerformanceTypeUseCase updateAcademicPerformanceTypeUseCase,
            IDeleteAcademicPerformanceTypeUseCase deleteAcademicPerformanceTypeUseCase,
            IGetAcademicPerformanceTypeUseCase getAcademicPerformanceTypeUseCase,
            IGetAcademicPerformanceTypesUseCase getAcademicPerformanceTypesUseCase)
        {
            _createAcademicPerformanceTypeUseCase = createAcademicPerformanceTypeUseCase;
            _updateAcademicPerformanceTypeUseCase = updateAcademicPerformanceTypeUseCase;
            _deleteAcademicPerformanceTypeUseCase = deleteAcademicPerformanceTypeUseCase;
            _getAcademicPerformanceTypesUseCase = getAcademicPerformanceTypesUseCase;
            _getAcademicPerformanceTypeUseCase = getAcademicPerformanceTypeUseCase;
        }

        /// <summary>
        /// Get all academic performance types
        /// </summary>
        /// <returns></returns>
        [HttpGet, ProducesResponseType(typeof(List<AcademicPerformanceType>), 200)]
        public async Task<IActionResult> GetAll()
        {
            IList<AcademicPerformanceTypeDto> academicPerformanceTypes = await _getAcademicPerformanceTypesUseCase.ExecuteAsync();
            return Ok(academicPerformanceTypes.Select(a => new AcademicPerformanceType
            {
                Id = a.Id,
                Description = a.Description,
                Code = a.Code,
            }).ToList());
        }

        /// <summary>
        /// Get academic performance type
        /// </summary>
        /// <param name="id">Identificator</param>
        /// <returns></returns>
        [HttpGet("{id}"), ProducesResponseType(typeof(AcademicPerformanceType), 200)]
        public async Task<IActionResult> Get(int id)
        {
            AcademicPerformanceTypeDto academicPerformanceType = await _getAcademicPerformanceTypeUseCase.ExecuteAsync(id);
            return Ok(new AcademicPerformanceType
            {
                Id = academicPerformanceType.Id,
                Description = academicPerformanceType.Description,
                Code = academicPerformanceType.Code,
            }); ;
        }

        /// <summary>
        /// Create academic performance type
        /// </summary>
        /// <param name="academicPerformanceType"></param>
        /// <returns></returns>
        [HttpPost, ProducesResponseType(typeof(AcademicPerformanceType), 200)]
        public async Task<IActionResult> Create([FromBody] AcademicPerformanceType academicPerformanceType)
        {
            AcademicPerformanceTypeDto academicPerformanceTypeDto = new AcademicPerformanceTypeDto
            {
                Code = academicPerformanceType.Code,
                Description = academicPerformanceType.Description,
            };

            await _createAcademicPerformanceTypeUseCase.ExecuteAsync(academicPerformanceTypeDto);
            academicPerformanceType.Id = academicPerformanceTypeDto.Id;
            return Ok(academicPerformanceType);
        }

        /// <summary>
        /// Update academic performance type
        /// </summary>
        /// <param name="id">Identificator</param>
        /// <param name="academicPerformanceType"></param>
        /// <returns></returns>
        [HttpPut("{id}"), ProducesResponseType(typeof(AcademicPerformanceType), 200)]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] AcademicPerformanceType academicPerformanceType)
        {
            if (id != academicPerformanceType.Id)
                return BadRequest();

            AcademicPerformanceTypeDto academicPerformanceTypeDto = new AcademicPerformanceTypeDto
            {
                Id = academicPerformanceType.Id,
                Code = academicPerformanceType.Code,
                Description = academicPerformanceType.Description,
            };

            await _updateAcademicPerformanceTypeUseCase.ExecuteAsync(academicPerformanceTypeDto);
            return Ok(academicPerformanceType);
        }

        /// <summary>
        /// Delete academic performance type
        /// </summary>
        /// <param name="id">Identificator</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _deleteAcademicPerformanceTypeUseCase.ExecuteAsync(id);
            return Ok();
        }
    }
}
