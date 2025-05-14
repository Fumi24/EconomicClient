using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Fumi24.EconomicClient.CreateModels;
using Fumi24.EconomicClient.ReadModels;
using RestEase;
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
            
            var invoice = new CreateInvoiceModel
            {
                Date = "2020-03-03",
                Customer = new Customer
                {
                    CustomerNumber = 1
                },
                Layout = new Layout
                {
                    LayoutNumber = 29
                },
                References = new References
                {
                    Other = "test"
                },
                PaymentTerms = new PaymentTerms
                {
                    PaymentTermsNumber = 3
                },
                
                Lines = new List<Line>
                {
                    new Line()
                    {
                        Product = new Product
                        {
                            ProductNumber = "1337"
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
        }
        
        [Fact]
        public async Task CanGetProducts()
        {
            var products = await Client.Value.GetProduct();
            Assert.NotNull(products);
            Assert.IsType<ResponseCollection<ProductReadModel>>(products);
        }
        
                
        [Fact]
        public async Task CanGetUnits()
        {
            var units = await Client.Value.GetUnits();
            Assert.NotNull(units);
            Assert.IsType<ResponseCollection<ReadModels.Unit>>(units);
        }

        [Fact]
        public async Task CanCreateProduct()
        {
            var createProductModel = new CreateProductModel
            {
                ProductNumber = "TEST-PROD-001",
                Name = "Test Product",
                Description = "A test product for unit testing.",
                CostPrice = 50.00m,
                RecommendedPrice = 75.00m,
                SalesPrice = 70.00m,
                BarCode = "1234567890123",
                Barred = false,
                Inventory = new Inventory
                {
                    Available = 100,
                    InStock = 100
                },
                Unit = new Unit
                {
                    UnitNumber = 1
                },
                ProductGroup = new ProductGroupReadModel
                {
                    ProductGroupNumber = 100
                }
            };

            var response = await Client.Value.CreateProduct(createProductModel);

            Assert.NotNull(response);
            Assert.Equal("TEST-PROD-001", response.ProductNumber);

            await Client.Value.DeleteProduct(response.ProductNumber);
        }


        [Fact]
        public async Task CanGetProductGroups()
        {
            var productGroups = await Client.Value.GetProductGroups();

            Assert.NotNull(productGroups);
            Assert.True(productGroups.Collection.Any());
        }
        
        [Fact]
        public async Task CanGetProductByNumber()
        {
            var createProductModel = new CreateProductModel
            {
                ProductNumber = "TEST-PROD-002",
                Name = "Get Product Test",
                Description = "Testing product retrieval.",
                CostPrice = 20.00m,
                RecommendedPrice = 30.00m,
                SalesPrice = 28.00m,
                BarCode = "9876543210987",
                Barred = false,
                Inventory = new Inventory
                {
                    Available = 50,
                    InStock = 50
                },
                Unit = new Unit
                {
                    UnitNumber = 1
                },
                ProductGroup = new ProductGroupReadModel
                {
                    ProductGroupNumber = 100
                }
            };

            var created = await Client.Value.CreateProduct(createProductModel);

            var fetched = await Client.Value.GetProduct(created.ProductNumber);

            Assert.NotNull(fetched);
            Assert.Equal("TEST-PROD-002", fetched.ProductNumber);

            await Client.Value.DeleteProduct(created.ProductNumber);
        }

        [Fact]
        public async Task CanUpdateProduct()
        {
            var createProductModel = new CreateProductModel
            {
                ProductNumber = "TEST-PROD-005",
                Name = "Original Product",
                Description = "Original Description",
                CostPrice = 15.00m,
                RecommendedPrice = 25.00m,
                SalesPrice = 22.00m,
                BarCode = "5556667778889",
                Barred = false,
                Inventory = new Inventory
                {
                    Available = 20,
                    InStock = 20
                },
                Unit = new Unit
                {
                    UnitNumber = 1,
                },
                ProductGroup = new ProductGroupReadModel
                {
                    ProductGroupNumber = 100
                }
            };

            // Create the product first
            var created = await Client.Value.CreateProduct(createProductModel);

            // Prepare an updated version of the product
            var updatedModel = new CreateProductModel
            {
                ProductNumber = created.ProductNumber, // product number must remain the same
                Name = "Updated Product Name",
                Description = "Updated Description",
                CostPrice = 18.00m,
                RecommendedPrice = 30.00m,
                SalesPrice = 28.00m,
                BarCode = "5556667778890",
                Barred = false,
                Inventory = new Inventory
                {
                    Available = 15,
                    InStock = 15
                },
                Unit = new Unit
                {
                    UnitNumber = 1
                },
                ProductGroup = created.ProductGroup
            };

            var updated = await Client.Value.UpdateProduct(created.ProductNumber, updatedModel);

            Assert.NotNull(updated);
            Assert.Equal("Updated Product Name", updated.Name);
            Assert.Equal("Updated Description", updated.Description);
            Assert.Equal(28.00m, updated.SalesPrice);

            await Client.Value.DeleteProduct(created.ProductNumber);
        }

        [Fact]
        public async Task CanDeleteProduct()
        {
            var createProductModel = new CreateProductModel
            {
                ProductNumber = "TEST-PROD-004",
                Name = "Product To Delete",
                Description = "Will be deleted.",
                CostPrice = 5.00m,
                RecommendedPrice = 10.00m,
                SalesPrice = 9.00m,
                BarCode = "0009998887776",
                Barred = false,
                Inventory = new Inventory
                {
                    Available = 10,
                    InStock = 10
                },
                Unit = new Unit
                {
                    UnitNumber = 1,
                },
                ProductGroup = new ProductGroupReadModel
                {
                    ProductGroupNumber = 100,
                }
            };

            var created = await Client.Value.CreateProduct(createProductModel);

            await Client.Value.DeleteProduct(created.ProductNumber);

            await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await Client.Value.GetProduct(created.ProductNumber);
            });
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