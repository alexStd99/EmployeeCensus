using EmployeeCensus.Application.Employees.Models;
using EmployeeCensus.Application.Interfaces;
using EmployeeCensus.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EmployeeCensus.Application.Employees.Commands
{
    public class UpdateEmployeeCommand : IRequest<Unit>
    {
        public UpdateEmployeeDto UpdateEmployeeDto { get; set; }

        public UpdateEmployeeCommand(UpdateEmployeeDto employee)
        {
            UpdateEmployeeDto = employee;
        }
    }

    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UpdateEmployeeCommandHandler> _logger;

        public UpdateEmployeeCommandHandler(IUnitOfWork unitOfWork, ILogger<UpdateEmployeeCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var employee = await _unitOfWork.EmployeeRepository.FirstOrDefaultAsync(e => e.Id == request.UpdateEmployeeDto.Id) 
                    ?? throw new InvalidOperationException("Employee not found");

                UpdateEmployeeEntity(employee, request.UpdateEmployeeDto);

                _unitOfWork.EmployeeRepository.Update(employee);
                await _unitOfWork.SaveChangesAsync();

                return await Task.FromResult(Unit.Value);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating the employee");
                throw;
            }
        }
        private void UpdateEmployeeEntity (Employee employee, UpdateEmployeeDto updateEmployeeDt) 
        {
            employee.FirstName = updateEmployeeDt.FirstName;
            employee.LastName = updateEmployeeDt.LastName;
            employee.Age = updateEmployeeDt.Age;
            employee.Gender = updateEmployeeDt.Gender;
            employee.DepartmentId = updateEmployeeDt.DepartmentId;
            employee.EditDate = DateTime.UtcNow;
        }
    }
}
