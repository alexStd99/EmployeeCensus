using EmployeeCensus.Domain.Entities;
using EmployeeCensus.Application.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using EmployeeCensus.Application.Employees.Models;

namespace EmployeeCensus.Application.Employees.Commands
{
    public class CreateEmployeeCommand : IRequest<Unit>
    {
        public CreateEmployeeDto CreateEmployeeDto { get; set; }

        public CreateEmployeeCommand(CreateEmployeeDto employee)
        {
            CreateEmployeeDto = employee;
        }
    }

    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetEmployeeListQueryHandler> _logger;

        public CreateEmployeeCommandHandler(IUnitOfWork unitOfWork, ILogger<GetEmployeeListQueryHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<Unit> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _unitOfWork.EmployeeRepository.InsertAsync(PrepareCreateEmployee(request.CreateEmployeeDto));
                await _unitOfWork.SaveChangesAsync();
                return await Task.FromResult(Unit.Value);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching the employee list");
                throw;
            }
        }

        private Employee PrepareCreateEmployee(CreateEmployeeDto createEmployee) => new Employee
        {
            FirstName = createEmployee.FirstName,
            LastName = createEmployee.LastName,
            Age = createEmployee.Age,
            Gender = createEmployee.Gender,
            DepartmentId = createEmployee.DepartmentId,
            EditDate = DateTime.UtcNow,
        };
    }
}
