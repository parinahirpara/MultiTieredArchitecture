using MA.Data.Interfaces;
using MA.Data.Models;

namespace MA.Business
{
    public class EmployeeService : IEmployeeService
    {

        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await _unitOfWork.GetRepository<Employee>().GetAll();
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _unitOfWork.GetRepository<Employee>().GetById(id);
        }

        public async Task AddEmployee(Employee employee)
        {
            await _unitOfWork.GetRepository<Employee>().Add(employee);
        }

        public async Task UpdateEmployee(Employee employee)
        {
            await _unitOfWork.GetRepository<Employee>().Update(employee);
        }

        public async Task DeleteEmployee(int id)
        {
            await _unitOfWork.GetRepository<Employee>().Delete(id);
        }
    }
}
