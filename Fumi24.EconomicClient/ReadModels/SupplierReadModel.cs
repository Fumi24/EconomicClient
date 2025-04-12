using System.Collections.Generic;
using Fumi24.EconomicClient.CreateModels;

namespace Fumi24.EconomicClient.ReadModels
{
    public class SupplierReadModel : IReadModel
    {
        public long? SupplierNumber { get; set; }
        public string Currency { get; set; }
        public SupplierGroup SupplierGroup { get; set; }
        public VatZone VatZone { get; set; }
        public string Name { get; set; }
        public PaymentTerms PaymentTerms { get; set; } = new PaymentTerms();
        public string CorporateIdentificationNumber { get; set; }
        public Account CostAccount { get; set; }
        public RemittanceAdvice RemittanceAdvice { get; set; }
        public string BankAccount { get; set; }

        public IList<string> FieldsToFilter { get; } = new List<string>
        {
            "supplierNumber",
            "name",
            "currency",
            "barred",
            "corporateIdentificationNumber",
            "email",
            "address",
            "zip",
            "city",
            "country",
            "bankAccount",
            "defaultInvoiceText"
        };
    }

    public class RemittanceAdvice
    {
        public PaymentType PaymentType { get; set; }
        public string CreditorId { get; set; }
    }
}