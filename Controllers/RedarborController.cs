using APIRedarbor.Models;
using APIRedarbor.Models.Dtos;
using APIRedarbor.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Redarbor.Controllers
{
    [Route("api/Redarbor")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ApiExplorerSettings(GroupName = "ApiRedarbor")]
    public class RedarborController : ControllerBase
    {
        private readonly IEmployeeRepository _repoEmployee;
        private readonly IMapper _mapper;
        public RedarborController(IEmployeeRepository repoEmployee, IMapper mapper)
        {
            _repoEmployee = repoEmployee;
            _mapper = mapper;
        }

        /// <summary>
        /// Listar todos los empleados
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetAllEmployees()
        {
            var listEmployees = _repoEmployee.GetAllEmployees();
            var listEmployeesDto = new List<EmployeeDto>();

            if (listEmployees == null) return NotFound();

            foreach (var employee in listEmployees)
            {
                listEmployeesDto.Add(_mapper.Map<EmployeeDto>(employee));
            }

            return Ok(listEmployeesDto);
        }

        /// <summary>
        /// Listar empleado especifico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}", Name = "GetEmployee")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetEmployee(int id)
        {
            var employee = _repoEmployee.GetEmployeeById(id);

            if (employee == null) return NotFound();

            var employeeDto = _mapper.Map<EmployeeDto>(employee);


            return Ok(employeeDto);
        }

        /// <summary>
        /// Insertar empleado
        /// </summary>
        /// <param name="employeeDto"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(EmployeeDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult AddEmployee([FromBody] EmployeeDto employeeDto)
        {
            if (employeeDto == null) return BadRequest(ModelState);

            var itemSaved = _repoEmployee.CreateEmployee(_mapper.Map<Employee>(employeeDto));

            if (itemSaved.Id == 0)
            {
                ModelState.AddModelError("", $"Algo salio mal guardando el registro {employeeDto}");
                return StatusCode(400, ModelState);
            }

            return Ok(itemSaved);
        }

        /// <summary>
        /// Actualizar empleado
        /// </summary>
        /// <param name="id"></param>
        /// <param name="employeeDto"></param>
        /// <returns></returns>
        [HttpPut("{id:int}", Name = "UpdateEmployee")]
        [ProducesResponseType(201, Type = typeof(EmployeeDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateEmployee(int id, [FromBody] EmployeeDto employeeDto)
        {
            if (employeeDto == null || id != employeeDto.Id) return BadRequest(ModelState);

            if (!_repoEmployee.ExistEmployee(employeeDto.Id)) return BadRequest("El empleado no existe");

            var itemEmployee = _mapper.Map<Employee>(employeeDto);

            if (!_repoEmployee.UpdateEmployee(itemEmployee))
            {
                ModelState.AddModelError("", "Algo salio mal actualizando el empleado");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        /// <summary>
        /// Eliminar empleado (Actualiza a estado eliminado)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("DeleteEmployee/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteEmployee(int id)
        {
            if (!_repoEmployee.ExistEmployee(id)) return NotFound();

            if (!_repoEmployee.DeleteEmployeeById(id))
            {
                ModelState.AddModelError("", "Algo salio mal borrando el empleado");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        /// <summary>
        /// Eliminar Permanentemente
        /// </summary>
        /// <param name="idDelete"></param>
        /// <returns></returns>
        [HttpDelete("DeleteDBEmployee/{idDelete}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteDBEmployee(int idDelete)
        {
            if (!_repoEmployee.ExistEmployee(idDelete)) return NotFound();

            if (!_repoEmployee.DeleteDBEmployeeById(idDelete))
            {
                ModelState.AddModelError("", "Algo salio mal borrando completamente el empleado");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
