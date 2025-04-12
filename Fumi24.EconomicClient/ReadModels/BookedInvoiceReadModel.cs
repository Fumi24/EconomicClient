using System;
using System.Collections.Generic;
using Fumi24.EconomicClient.CreateModels;

namespace Fumi24.EconomicClient.ReadModels
{
    public class BookedInvoiceReadModel : IReadModel
    {
        public long BookedInvoiceNumber { get; set; }
        public DateTimeOffset? Date { get; set; }
        public string Currency { get; set; }
        public decimal? ExchangeRate { get; set; }
        public decimal? NetAmount { get; set; }
        public decimal? NetAmountInBaseCurrency { get; set; }
        public decimal? GrossAmount { get; set; }
        public decimal? GrossAmountInBaseCurrency { get; set; }
        public decimal? VatAmount { get; set; }
        public decimal? RoundingAmount { get; set; }
        public decimal? Remainder { get; set; }
        public decimal? RemainderInBaseCurrency { get; set; }
        public DateTimeOffset? DueDate { get; set; }
        public PaymentTerms PaymentTerms { get; set; }
        public Customer Customer { get; set; }
        public Recipient Recipient { get; set; }
        public References References { get; set; }
        public Layout Layout { get; set; }
        public Pdf Pdf { get; set; }
        public List<CreateModels.Line> Lines { get; set; }
        public Uri Sent { get; set; }
        public Uri Self { get; set; }
        public IList<string> FieldsToFilter { get; } = new List<string>
        {
            "bookedinvoicenumber"
        };
    }
}