using DataTables.AspNet.Core;
using MA.Data.Interfaces;
using MA.Data.Models;
using Microsoft.EntityFrameworkCore;

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
            // Perform any business logic validation here before adding the employee
            await _unitOfWork.GetRepository<Employee>().Add(employee);
        }

        public async Task UpdateEmployee(Employee employee)
        {
            // Perform any business logic validation here before updating the employee
            await _unitOfWork.GetRepository<Employee>().Update(employee);
        }

        public async Task DeleteEmployee(int id)
        {
            // Perform any business logic validation here before deleting the employee
            await _unitOfWork.GetRepository<Employee>().Delete(id);
        }
        //public async Task<DataTablesResponse<Employee>> GetEmployeesForDataTable(IDataTablesRequest request)
        //{
        //    var response = new DataTablesResponse<Employee>();
        //    try
        //    {
        //        var query = _unitOfWork.GetRepository<Employee>().Query();
        //        if (!string.IsNullOrEmpty(request.Search?.Value))
        //        {
        //            var searchTerm = request.Search.Value.ToLower();
        //            query = query.Where(e =>
        //                e.firstname.ToLower().Contains(searchTerm) ||
        //                e.lastname.ToLower().Contains(searchTerm) ||
        //                e.email.ToLower().Contains(searchTerm));
        //        }

        //        // Apply pagination
        //        query = query.Skip(request.Start).Take(request.Length);

        //        // Assuming you want to return all employees in the database
        //        var totalRecords = await _unitOfWork.GetRepository<Employee>().Query().CountAsync();
        //        var filteredRecords = await query.CountAsync();
        //        var employees = await query.ToListAsync();
        //        response.Draw = request.Draw;
        //        response.RecordsTotal = totalRecords;
        //        response.RecordsFiltered = filteredRecords;
        //        response.Data = employees;
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle exception
        //        // You might want to log the error
        //        response.Error = $"Internal server error: {ex.Message}";
        //    }

        //    return response;


        //}


    }
}
