﻿using EmployeeManagment.Models;

namespace EmployeeManagment.API.Models
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> Search(string empName, Gender? gender);
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployeeById(int employeeId);
        Task<Employee> GetEmployeeByEmail(string email);
        Task<Employee> AddEmployee(Employee employee);
        Task<Employee> UpdateEmployee(Employee employee);
        Task<Employee> DeleteEmployee(int employeeId);
    }
}
