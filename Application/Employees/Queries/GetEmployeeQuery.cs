using EmployeeCensus.Application.Employees.Models;
using EmployeeCensus.Application.Interfaces;
using EmployeeCensus.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EmployeeCensus.Application.Employees.Queries
{
    public class GetEmployeeQuery : IRequest<UpdateEmployeeDto>
    {
        public GetEmployeeQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }

    public class GetEmployeeQueryHandler : IRequestHandler<GetEmployeeQuery, UpdateEmployeeDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetEmployeeListQueryHandler> _logger;

        public GetEmployeeQueryHandler(IUnitOfWork unitOfWork, ILogger<GetEmployeeListQueryHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<UpdateEmployeeDto> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var employee = await _unitOfWork.EmployeeRepository.GetEmployeeWhithDepartamentForUpdateAsync(request.Id)
                    ?? throw new InvalidOperationException("Employee not found");
                return MapToGetEmployeeResponse(employee);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching the employee list");
                throw;
            }
        }

        private UpdateEmployeeDto MapToGetEmployeeResponse(Employee employee)
        => new()
        {
            Id = employee.Id,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Age = employee.Age,
            Gender = employee.Gender,
            DepartmentId = employee.Department.Id
        };
    }
}
