using EmployeeCensus.Application.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EmployeeCensus.Application.Employees.Commands
{
    public class DeleteEmployeeCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }

        public DeleteEmployeeCommand(Guid id)
        {
            Id = id;
        }
    }

    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DeleteEmployeeCommandHandler> _logger;

        public DeleteEmployeeCommandHandler(IUnitOfWork unitOfWork, ILogger<DeleteEmployeeCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var employee = await _unitOfWork.EmployeeRepository.FirstOrDefaultAsync(e => e.Id == request.Id) 
                    ?? throw new InvalidOperationException("Employee not found");

                employee.IsDeleted = true;

                _unitOfWork.EmployeeRepository.Update(employee);
                await _unitOfWork.SaveChangesAsync();

                return await Task.FromResult(Unit.Value);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting the employee");
                throw;
            }
        }
    }
}
