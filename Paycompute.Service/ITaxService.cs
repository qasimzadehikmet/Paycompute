using System;
using System.Collections.Generic;
using System.Text;

namespace Paycompute.Service
{
    public interface ITaxService
    {
       decimal TaxAmount(decimal totalAmount);
    }
}
