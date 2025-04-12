using Fumi24.EconomicClient.ReadModels;

namespace Fumi24.EconomicClient.CreateModels
{
    public class CreateSupplierModel
    {
        public long? SupplierNumber { get; set; }
        public string Currency { get; set; } = "DKK";
        public SupplierGroup SupplierGroup { get; set; }
        public VatZone VatZone { get; set; } = new VatZone();
        public string Name { get; set; }
        public PaymentTerms PaymentTerms { get; set; } = new PaymentTerms();
        public string CorporateIdentificationNumber { get; set; }
        public Account CostAccount { get; set; }
        public RemittanceAdvice RemittanceAdvice { get; set; } = null;
    }

    public class SupplierGroup
    {
        public long SupplierGroupNumber { get; set; } = 1;
    }
}