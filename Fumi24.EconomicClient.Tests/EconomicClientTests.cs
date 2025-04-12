using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Fumi24.EconomicClient.CreateModels;
using Fumi24.EconomicClient.ReadModels;
using Xunit;
using Customer = Fumi24.EconomicClient.CreateModels.Customer;
using Line = Fumi24.EconomicClient.CreateModels.Line;
using PaymentTerms = Fumi24.EconomicClient.CreateModels.PaymentTerms;
using Product = Fumi24.EconomicClient.CreateModels.Product;
using References = Fumi24.EconomicClient.CreateModels.References;
using Unit = Fumi24.EconomicClient.CreateModels.Unit;

namespace Fumi24.EconomicClient.Test
{
    public class EconomicClientTests
    {
        public static string AppSecretToken = "";
        public static string AgreementToken = "";

        public Lazy<IEconomicClient> Client = new Lazy<IEconomicClient>(() =>
        {
            var client = EconomicClientFactory.Execute(AppSecretToken, AgreementToken);

            return client;
        });

        [Fact]
        public async Task CanGetSelf()
        {
            var response = await Client.Value.Self();
        }

        [Fact]
        public async Task GetGetCustomers()
        {
            var response = await Client.Value.ListCustomers();
        }

        [Fact]
        public async Task CanFilterCustomers()
        {
            var customer1 = new CreateCustomerModel
            {
                Name = "FilterTestCustomer 1"
            };
            var customer2 = new CreateCustomerModel
            {
                Name = "FilterTestCustomer 2"
            };
            var customer3 = new CreateCustomerModel
            {
                Name = "Peter"
            };
            
            var createdCustomer1 = await Client.Value.CreateCustomer(customer1);
            var createdCustomer2 = await Client.Value.CreateCustomer(customer2);
            var createdCustomer3 = await Client.Value.CreateCustomer(customer3);

            // Get By Eq Name
            
            var peterFilter = new QueryFilter<CustomerReadModel>();

            peterFilter.Where(x => x.Name, QueryOperator.Eq, "Peter");

            var filteredEquals = await Client.Value.ListCustomers(peterFilter);

            var filteredEqualsCount = filteredEquals.Collection.Count;
            
            // Get By Like Name
            
            var testFilter = new QueryFilter<CustomerReadModel>();

            testFilter.Where(x => x.Name, QueryOperator.Like, "FilterTestCustomer");

            filteredEquals = await Client.Value.ListCustomers(testFilter);

            var filteredEqualsCount2 = filteredEquals.Collection.Count;

            await Client.Value.DeleteCustomer(createdCustomer1.CustomerNumber);
            await Client.Value.DeleteCustomer(createdCustomer2.CustomerNumber);
            await Client.Value.DeleteCustomer(createdCustomer3.CustomerNumber);
            
            filteredEqualsCount.Should().Be(1);
            filteredEqualsCount2.Should().Be(2);
        }

        [Fact]
        public async Task CanGetCustomerByNumber()
        {
            var createCustomerModel = new CreateCustomerModel
            {
                Name = "CreateTestCustomer"
            };

            var response = await Client.Value.CreateCustomer(createCustomerModel);
            
            var customerList = await Client.Value.ListCustomers();

             await Client.Value.GetCustomerByCustomerNumber(customerList.Collection.First().CustomerNumber);

             await Client.Value.DeleteCustomer(response.CustomerNumber);
        }

        [Fact]
        public async Task CanCreateCustomer()
        {
            var createCustomerModel = new CreateCustomerModel
            {
                Name = "CreateTestCustomer"
            };

            var response = await Client.Value.CreateCustomer(createCustomerModel);

            await Client.Value.DeleteCustomer(response.CustomerNumber);
        }

        [Fact]
        public async Task CanCreateInvoiceDraft()
        {
            var createCustomerModel = new CreateCustomerModel                     
            {                                                                     
                Name = "CreateInvoiceDraftTestCustomer"                                                   
            };                                                                    
                                                                      
            var customer = await Client.Value.CreateCustomer(createCustomerModel);
            
            var invoice = new CreateInvoiceModel
            {
                Date = "2020-03-03",
                Customer = new Customer
                {
                    CustomerNumber = customer.CustomerNumber
                },
                Layout = new Layout
                {
                    LayoutNumber = 14
                },
                References = new References
                {
                    Other = "MRR-75"
                },
                PaymentTerms = new PaymentTerms
                {
                    PaymentTermsNumber = 1
                },
                
                Lines = new List<Line>
                {
                    new Line()
                    {
                        Product = new Product
                        {
                            ProductNumber = "1"
                        },
                        Quantity = 1,
                        Unit = new Unit
                        {
                            UnitNumber = 1
                        },
                        DiscountPercentage = 0,
                        UnitNetPrice = 200
                    }
                },
                Recipient = new Recipient
                {
                    Name = "Morten",
                    VatZone = new VatZone
                    {
                        VatZoneNumber = 1
                    }
                }
            };

            var response = await Client.Value.CreateInvoice(invoice);

            await Client.Value.DeleteInvoiceDraft(response.DraftInvoiceNumber);
            await Client.Value.DeleteCustomer(customer.CustomerNumber);
        }

        [Fact]
        public async Task ListBookedInvoices()
        {
            var bookedInvoices = await Client.Value.ListBookedInvoices(InvoiceStatus.Booked);
            var unpaidInvoices = await Client.Value.ListBookedInvoices(InvoiceStatus.Unpaid, new QueryFilter<BookedInvoiceReadModel>().Where(x => x.BookedInvoiceNumber, QueryOperator.Eq, "1"));
            var paidInvoices = await Client.Value.ListBookedInvoices(InvoiceStatus.Paid);
        }

        [Fact]
        public void TestQueryFilter()
        {
            var filter = new QueryFilter<BookedInvoiceReadModel>();

            var filterString = filter.ToString();

            var correctFilterString = "pagesize=1000&skippages=0";
            
            filterString.Should().BeEquivalentTo(correctFilterString);

            filter
                .Where(x => x.BookedInvoiceNumber, QueryOperator.Eq, "1")
                .Where(x => x.BookedInvoiceNumber, QueryOperator.Eq, "2");

            filterString = filter.ToString();

            correctFilterString = "filter=BookedInvoiceNumber%24eq%3A1%24or%3ABookedInvoiceNumber%24eq%3A2&pagesize=1000&skippages=0"; // This is URL Encoded Original Value is filter=bookedInvoiceNumber$eq:1$or:BookedInvoiceNumber$eq:2

            filterString.Should().BeEquivalentTo(correctFilterString);

            filter.PageSize = 500;

            filterString = filter.ToString();
            
            correctFilterString = "filter=BookedInvoiceNumber%24eq%3A1%24or%3ABookedInvoiceNumber%24eq%3A2&pagesize=500&skippages=0"; // This is URL Encoded Original Value is filter=bookedInvoiceNumber$eq:1$or:BookedInvoiceNumber$eq:2

            filterString.Should().BeEquivalentTo(correctFilterString);
        }
    }
}