using System.Collections.Generic;
using Fumi24.EconomicClient.ReadModels;

namespace Fumi24.EconomicClient.CreateModels
{
    public class CreateInvoiceModel
    {
        public string Date { get; set; }
        public string Currency { get; set; } = "DKK";
        public string DueDate { get; set; }
        public Notes Notes { get; set; }
        public PaymentTerms PaymentTerms { get; set; }
        public Customer Customer { get; set; }
        public References References { get; set; }
        public Delivery Delivery { get; set; }
        public Layout Layout { get; set; }
        public List<Line> Lines { get; set; }
        public Recipient Recipient { get; set; }
    }

    public class Notes
    {
        public string Heading { get; set; }
        public string TextLine1 { get; set; }
        public string TextLine2 { get; set; }
    }

    public class Customer
    {
        public long CustomerNumber { get; set; }
    }

    public class Line
    {
        public Unit Unit { get; set; }
        public Product Product { get; set; }
        public string Description { get; set; } = "";
        public decimal? Quantity { get; set; }
        public decimal? UnitNetPrice { get; set; }
        public decimal DiscountPercentage { get; set; } = 0;
    }

    public class Product
    {
        public string ProductNumber { get; set; }
    }

    public class Unit
    {
        public long? UnitNumber { get; set; }
        public string Name { get; set; }
    }

    public class References
    {
        public string Other { get; set; }
    } 

}