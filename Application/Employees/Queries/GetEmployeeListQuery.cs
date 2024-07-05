using EmployeeCensus.Application.Employees.Models;
using EmployeeCensus.Application.Employees.Queries;
using EmployeeCensus.Application.Interfaces;
using EmployeeCensus.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EmployeeCensus.Application.Employees.Queries
{
    public class GetEmployeeListQuery : IRequest<IEnumerable<GetEmployeeResponseDto>>
    {
        public string? SearchTerm { get; init; }
    }
}

public class GetEmployeeListQueryHandler : IRequestHandler<GetEmployeeListQuery, IEnumerable<GetEmployeeResponseDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<GetEmployeeListQueryHandler> _logger;

    public GetEmployeeListQueryHandler(IUnitOfWork unitOfWork, ILogger<GetEmployeeListQueryHandler> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<IEnumerable<GetEmployeeResponseDto>> Handle(GetEmployeeListQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var employees = await _unitOfWork.EmployeeRepository.GetEmployeesWhithDepartamentAsync(request.SearchTerm);
            return MapToGetEmployeesResponse(employees);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while fetching the employee list");
            throw;
        }
    }

    private IEnumerable<GetEmployeeResponseDto> MapToGetEmployeesResponse(IEnumerable<Employee> employees) 
        => employees.Select(employee => new GetEmployeeResponseDto
        {
            Id = employee.Id,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Age = employee.Age,
            Gender = employee.Gender,
            DepartmentName = employee.Department.Name
        });
}