using System;

namespace Fumi24.EconomicClient.ReadModels
{
    public class AccountingYearReadModel
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Year { get; set; }

        public string GetYearReference()
        {
            return Year.Replace("/", "_6_");
        }
    }
}