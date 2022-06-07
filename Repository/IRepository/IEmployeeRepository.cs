using APIRedarbor.Models;
using System.Collections.Generic;

namespace APIRedarbor.Repository.IRepository
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Employee CreateEmployee(Employee employee);
        ICollection<Employee> GetAllEmployees();
        bool ExistEmployee(int idEmployee);
        Employee GetEmployeeById(int idEmployee);
        bool UpdateEmployee(Employee employee);
        bool DeleteEmployeeById(int idEmployee);
    }
}