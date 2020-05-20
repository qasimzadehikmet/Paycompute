using System;
using System.Collections.Generic;
using System.Text;

namespace Paycompute.Service
{
    public  interface INationalInsuranceContributionService
    {
        decimal NIContribution(decimal totalAmount);
    }
}
