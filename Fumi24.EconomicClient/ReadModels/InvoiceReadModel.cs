using System;
using System.Collections.Generic;
using Fumi24.EconomicClient.CreateModels;

namespace Fumi24.EconomicClient.ReadModels
{
    public class InvoiceReadModel
    {
        public long DraftInvoiceNumber { get; set; }
        public Soap Soap { get; set; }
        public Templates Templates { get; set; }
        public List<Line> Lines { get; set; }
        public DateTimeOffset? Date { get; set; }
        public string Currency { get; set; }
        public decimal? ExchangeRate { get; set; }
        public decimal? NetAmount { get; set; }
        public decimal? NetAmountInBaseCurrency { get; set; }
        public decimal? GrossAmount { get; set; }
        public decimal? GrossAmountInBaseCurrency { get; set; }
        public decimal? MarginInBaseCurrency { get; set; }
        public decimal? MarginPercentage { get; set; }
        public decimal? VatAmount { get; set; }
        public decimal? RoundingAmount { get; set; }
        public decimal? CostPriceInBaseCurrency { get; set; }
        public DateTimeOffset? DueDate { get; set; }
        public CreateModels.PaymentTerms PaymentTerms { get; set; }
        public Customer Customer { get; set; }
        public Recipient Recipient { get; set; }
        public References References { get; set; }
        public Layout Layout { get; set; }
        public Pdf Pdf { get; set; }
        public Uri Self { get; set; }
    }

    public class Layout
    {
        public long? LayoutNumber { get; set; }
        public Uri Self { get; set; }
    }

    public class Line
    {
        public long? LineNumber { get; set; }
        public long? SortKey { get; set; }
        public Unit Unit { get; set; }
        public Product Product { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? UnitNetPrice { get; set; }
        public decimal? DiscountPercentage { get; set; }
        public decimal? UnitCostPrice { get; set; }
        public decimal? TotalNetAmount { get; set; }
        public decimal? MarginInBaseCurrency { get; set; }
        public decimal? MarginPercentage { get; set; }
    }

    public class Product
    {
        public string ProductNumber { get; set; }
        public Uri Self { get; set; }
    }

    public class Unit
    {
        public long? UnitNumber { get; set; }
        public string Name { get; set; }
        public Uri Products { get; set; }
        public Uri Self { get; set; }
    }

    public class Pdf
    {
        public Uri Download { get; set; }
    }

    public class Recipient
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public VatZone VatZone { get; set; }
        public Attention Attention { get; set; }
        public string Ean { get; set; }
    }

    public class Delivery
    {
        public string Address { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
    }

    public class Attention
    {
        public Attention(long customerContactNumber)
        {
            CustomerContactNumber = customerContactNumber;
        }
        
        public long CustomerContactNumber { get; set; }
    }

    public class References
    {
        public string Other { get; set; }
    }

    public class Soap
    {
        public CurrentInvoiceHandle CurrentInvoiceHandle { get; set; }
    }

    public class CurrentInvoiceHandle
    {
        public long? Id { get; set; }
    }
}