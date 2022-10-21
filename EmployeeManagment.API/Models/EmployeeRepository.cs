﻿using EmployeeManagment.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagment.API.Models
{
    public class EmployeeRepository:IEmployeeRepository
    {
        private AppDbContext _appDbContext;
        public EmployeeRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _appDbContext.Employees.ToListAsync();
        }
        public async Task<Employee> GetEmployeeById(int employeeId)
        {
            return await _appDbContext.Employees
                .Include(x=>x.Department)
                .FirstOrDefaultAsync(x => x.EmployeeId == employeeId);
        }
        public async Task<Employee> GetEmployeeByEmail(string email)
        {
            return await _appDbContext.Employees.FirstOrDefaultAsync(x => x.Email == email);
        }
        public async Task<Employee> AddEmployee(Employee employee)
        {
            var result = await _appDbContext.Employees.AddAsync(employee);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<Employee> DeleteEmployee(int employeeId)
        {
            var result = await _appDbContext.Employees.FirstOrDefaultAsync(x => x.EmployeeId == employeeId);
            if(result != null)
            {
                 _appDbContext.Employees.Remove(result);
                await _appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var result = await _appDbContext.Employees.FirstOrDefaultAsync(x=>x.EmployeeId == employee.EmployeeId);
            if(result != null)
            {
                result.EmployeeId = employee.EmployeeId;
                result.FirstName = employee.FirstName;
                result.LastName = employee.LastName;
                result.DateOfBirth = employee.DateOfBirth;
                result.Gender = employee.Gender;
                result.Email = employee.Email;
                result.PhotoPath = employee.PhotoPath;

                await _appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
        public async Task<IEnumerable<Employee>> Search(string empName, Gender? gender)
        {
            IQueryable<Employee> query = _appDbContext.Employees;
            if (!string.IsNullOrEmpty(empName))
            {
                query = query.Where(e=>e.FirstName.Contains(empName) || e.LastName.Contains(empName));
            }
            if (gender != null)
            {
                query = query.Where(e => e.Gender == gender);
            }
            return await query.ToListAsync();
        }
    }
}
