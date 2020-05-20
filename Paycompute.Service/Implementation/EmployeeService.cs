using Microsoft.EntityFrameworkCore;
using Paycompute.Entity;
using Paycompute.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paycompute.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _context;
        public EmployeeService(ApplicationDbContext _context)
        {
            this._context = _context;
        }

        public async Task CreateAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int employeeId)
        {
            var employee = GetById(employeeId);
            _context.Remove(employee);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Employee> GetALL() => _context.Employees;


        public Employee GetById(int employeeId) => _context.Employees.Where(e => e.Id == employeeId).FirstOrDefault();


        public decimal StudentLoanRepaymentAmount(int Id, decimal totalAmount)
        {
            throw new NotImplementedException();
        }

        public decimal UnionFees(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Employee employee)
        {
            _context.Update(employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int employeeId)
        {
            var employee = GetById(employeeId);
            _context.Update(employee);
            await _context.SaveChangesAsync();
        }
    }
}
