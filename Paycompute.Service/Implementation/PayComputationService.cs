using Paycompute.Entity;
using Paycompute.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paycompute.Service.Implementation
{
    public class PayComputationService : IPayComputationService
    {
        private readonly ApplicationDbContext _context;
        private decimal contractualEarnings;
        private decimal overtimeHours;
        public PayComputationService(ApplicationDbContext context)
        {
            _context = context;
        }
        public decimal ContractualEarnings(decimal contractualHours, decimal hoursWorked, decimal hourlyRate)
        {
            if (hoursWorked < contractualHours)
            {
                contractualEarnings = hoursWorked * hourlyRate;
            }
            else
            {
                contractualEarnings = contractualHours * hourlyRate;
            }
            return contractualEarnings;
        }

        public async Task CreateAsync(PaymentRecord paymentRecord)
        {
            await _context.PaymentRecords.AddAsync(paymentRecord);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<PaymentRecord> GetAll() => _context.PaymentRecords.OrderBy(e => e.EmployeeId);

        public IEnumerable<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> GetAllTaxYear()
        {
            var allTaxYear = _context.TaxYears.Select(taxyears => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Text = taxyears.YearOfTax,
                Value = taxyears.Id.ToString()
            });
            return allTaxYear;
        }

        public PaymentRecord GetById(int Id) => _context.PaymentRecords.Where(pay => pay.Id == Id).FirstOrDefault();

        public TaxYear GetTaxYearById(int Id) => _context.TaxYears.Where(year => year.Id == Id).FirstOrDefault();

        public decimal NetPay(decimal totalEarnings, decimal totalDeduction)
        => totalEarnings - totalDeduction;

        public decimal OvertimeEarnings(decimal overtimeRate, decimal overtimeHours)
       => overtimeRate * overtimeHours;

        public decimal OverTimeHours(decimal hoursWorked, decimal contractualHours)
        {
            if (hoursWorked <= contractualHours)
            {
                overtimeHours = 0.00m;
            }
            else if (hoursWorked > contractualHours)
            {
                overtimeHours = hoursWorked - contractualHours;
            }
            return overtimeHours;
        }

        public decimal OvertimeRate(decimal hourlyRate) => hourlyRate * 1.5m;

        public decimal TotalDeduction(decimal tax, decimal nic, decimal studentLoanRepayment, decimal unionFees)
        => tax + nic + studentLoanRepayment + unionFees;

        public decimal TotalEarnings(decimal overtimeEarnings, decimal contractualEarnings)
        => overtimeEarnings + contractualEarnings;
    }
}
