using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Paycompute.Entity;

namespace Paycompute.Service
{
    public interface IEmployeeService
    {
        Task CreateAsync(Employee employee);
        Task UpdateAsync(Employee employee);
        Task UpdateAsync(int employeeId);
        Employee GetById(int employeeId);
        Task DeleteAsync(int employeeId);
        IEnumerable<Employee> GetALL();
        decimal UnionFees(int Id);
        decimal StudentLoanRepaymentAmount(int Id, decimal totalAmount);
       
      
    }
}
