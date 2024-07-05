using EmployeeCensus.Application.Employees.Commands;
using EmployeeCensus.Application.Employees.Models;
using EmployeeCensus.Application.Employees.Queries;
using EmployeeCensus.Application.Interfaces;
using EmployeeCensus.Domain.Entities;
using EmployeesControl.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EmployeeCensus.Presentation.Controllers
{
    [Authorize]
    public class EmployeesController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILogger<EmployeesController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public EmployeesController(IMediator mediator, ILogger<EmployeesController> logger, IUnitOfWork unitOfWork)
        {
            _mediator = mediator;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("/")]
        public async Task<IActionResult> GetEmployeeList([FromQuery] GetEmployeeListQuery query)
        {
            try
            {
                var employees = await _mediator.Send(query);

                return View(employees);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching the employee list");

                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }

        [HttpGet("add")]
        public async Task<IActionResult> AddEmployee()
        {
            ViewBag.Departments = await _unitOfWork.DepartmentRepository.GetAllAsync();
            return View();
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddEmployee([FromForm] CreateEmployeeDto model)
        {
            if (ModelState.IsValid)
            {
                var command = new CreateEmployeeCommand(model);
                await _mediator.Send(command);
                return RedirectToAction("GetEmployeeList");
            }
            ViewBag.Departments = await _unitOfWork.DepartmentRepository.GetAllAsync();
            return View(model);
        }

        [HttpGet("edit/{id}")]
        public async Task<IActionResult> EditEmployee([FromRoute] Guid id)
        {
            var employee = await _mediator.Send(new GetEmployeeQuery(id));
            if (employee == null)
                return NotFound();

            ViewBag.Departments = await _unitOfWork.DepartmentRepository.GetAllAsync();
            return View(employee);
        }

        [HttpPost("edit")]
        public async Task<IActionResult> EditEmployeePost([FromForm] UpdateEmployeeDto updateEmployee)
        {
            if (ModelState.IsValid)
            {
                var updateEmployeeCommand = new UpdateEmployeeCommand(updateEmployee);
                await _mediator.Send(updateEmployeeCommand);
                return RedirectToAction("GetEmployeeList");
            }
            ViewBag.Departments = await _unitOfWork.DepartmentRepository.GetAllAsync();
            return View(updateEmployee);
        }

        [HttpPost("delete/{id}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] Guid id)
        {
            var deleteEmployeeCommand = new DeleteEmployeeCommand(id);
            await _mediator.Send(deleteEmployeeCommand);
            return RedirectToAction("GetEmployeeList");
        }
    }
}
