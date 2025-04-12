using System.Collections.Generic;
using Fumi24.EconomicClient.ReadModels;

namespace Fumi24.EconomicClient.CreateModels
{
    public class CreateJournalModel
    {
        public AccountingYear AccountingYear { get; set; }
        public Entries Entries { get; set; }
    }

    public class Entries
    {
        public List<CustomerPaymentEntry> CustomerPayments { get; set; }
        public List<SupplierInvoiceEntry> SupplierInvoices { get; set; }
        public List<SupplierPaymentEntry> SupplierPayments { get; set; }
        public List<FinanceVoucherEntry> FinanceVouchers { get; set; }
    }

    public class SupplierInvoiceEntry
    {
        public Currency Currency { get; set; } = new Currency();
        public string DueDate { get; set; }
        public string Text { get; set; }
        public string Date { get; set; }
        public Supplier Supplier { get; set; }
        public string SupplierInvoiceNumber { get; set; }
        public decimal Amount { get; set; }
        public Account ContraAccount { get; set; } = new Account();
        public DefaultVatAccount ContraDefaultVatAccount { get; set; } = new DefaultVatAccount();
        public DefaultVatAccount ContraVatAccount { get; set; }
        public PaymentDetails PaymentDetails { get; set; }
    }
    
    public class SupplierPaymentEntry
    {
        public Supplier Supplier { get; set; }
        public string SupplierInvoiceNumber { get; set; }
        public Currency Currency { get; set; } = new Currency();
        public string Text { get; set; }
        public string Date { get; set; }
        public decimal Amount { get; set; }
        public Account ContraAccount { get; set; }
    }

    public class FinanceVoucherEntry
    {
        public Currency Currency { get; set; } = new Currency();
        public string Text { get; set; }
        public string Date { get; set; }
        public decimal Amount { get; set; }
        public EntryAccount Account { get; set; }
        public EntryAccount ContraAccount { get; set; }
        public VatAccount VatAccount { get; set; }
    }

    public class CustomerPaymentEntry
    {
        public long CustomerInvoice { get; set; }
        public string Date { get; set; }
        public decimal Amount { get; set; }
        public string Text { get; set; }
        public Customer Customer { get; set; }
        public EntryAccount ContraAccount { get; set; }
        public EntryAccount Account { get; set; }
    }

    public class EntryAccount
    {
        public int? AccountNumber { get; set; }
    }

    public class PaymentDetails
    {
        public PaymentType PaymentType { get; set; } = new PaymentType();
        public string AccountNo { get; set; }
        public string Message { get; set; }
        public string IbanSwift { get; set; }
        public string FiSupplierNo { get; set; }
        public string OcrLine { get; set; } 
    }

    public class PaymentType : IReadModel 
    {
        public int PaymentTypeNumber { get; set; } = 7;
        public string Name { get; set; }
        public IList<string> FieldsToFilter { get; } = new List<string>();
    }

    public class DefaultVatAccount
    {
        public string VatCode { get; set; } = "I25";
    }

    public class Account
    {
        public long AccountNumber { get; set; } = 1310;
    }

    public class Supplier
    {
        public long SupplierNumber { get; set; }
    }

    public class Currency
    {
        public string Code { get; set; } = "DKK";
    }

    public class AccountingYear
    {
        public string Year { get; set; }
        
        public AccountingYear(string year)
        {
            Year = year;
        }
    }

    public class VatAccount
    {
        public string VatCode { get; set; }
    }
}