using System;
using System.Collections.Generic;

namespace Fumi24.EconomicClient.ReadModels
{
    public class CustomerReadModel : IReadModel
    {
        public long CustomerNumber { get; set; }
        public string Currency { get; set; }
        public PaymentTerms PaymentTerms { get; set; }
        public CustomerGroup CustomerGroup { get; set; }
        public string Address { get; set; }
        public decimal? Balance { get; set; }
        public decimal? DueAmount { get; set; }
        public string CorporateIdentificationNumber { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Zip { get; set; }
        public string TelephoneAndFaxNumber { get; set; }
        public string Ean { get; set; }
        public VatZone VatZone { get; set; }
        public DateTimeOffset LastUpdated { get; set; }
        public Uri Contacts { get; set; }
        public Templates Templates { get; set; }
        public Invoices Totals { get; set; }
        public Uri DeliveryLocations { get; set; }
        public Invoices Invoices { get; set; }
        public string MobilePhone { get; set; }
        public MetaData MetaData { get; set; }
        public Uri Self { get; set; }
        public bool Barred { get; set; }
        public IList<string> FieldsToFilter { get; } = new List<string>
        {
            "address","balance","barred","city","corporateIdentificationNumber","country","creditLimit","currency","customerNumber","ean","email","lastUpdated","mobilePhone","name","publicEntryNumber","telephoneAndFaxNumber","vatNumber","website","zip"
        };
    }

    public class CustomerGroup
    {
        public long CustomerGroupNumber { get; set; }
        public Uri Self { get; set; }
    }

    public class Invoices
    {
        public Uri Drafts { get; set; }
        public Uri Booked { get; set; }
        public Uri Self { get; set; }
    }

    public class MetaData
    {
        public Delete Delete { get; set; }
        public Delete Replace { get; set; }
    }

    public class Delete
    {
        public string Description { get; set; }
        public Uri Href { get; set; }
        public string HttpMethod { get; set; }
    }

    public class PaymentTerms
    {
        public long PaymentTermsNumber { get; set; }
        public Uri Self { get; set; }
    }

    public class Templates
    {
        public Uri Invoice { get; set; }
        public Uri InvoiceLine { get; set; }
        public Uri Self { get; set; }
    }

    public class VatZone
    {
        public long VatZoneNumber { get; set; } = 1;
        public Uri Self { get; set; }
    }

}