using System;
using System.Collections.Generic;

namespace Fumi24.EconomicClient.ReadModels
{
    public class ProductReadModel : IReadModel
    {
        public string Name { get; set; }
        public string BarCode { get; set; }
        public bool Barred { get; set; }
        public decimal CostPrice { get; set; }
        public DepartmentalDistribution DepartmentalDistribution { get; set; }
        public string Description { get; set; }
        public Inventory Inventory { get; set; }
        public ProductGroupReadModel ProductGroup { get; set; }
        public string ProductNumber { get; set; }
        public decimal RecommendedPrice { get; set; }
        public decimal SalesPrice { get; set; }
        public string LastUpdated { get; set; }
        public Uri Self { get; set; }
        public Unit Unit { get; set; }

        public IList<string> FieldsToFilter { get; } = new List<string>()
        {
            "barCode", "barred", "costPrice", "departmentalDistribution.departmentalDistributionNumber", "description",
            "inventory.grossWeight", "inventory.netWeight", "inventory.packageVolume", "inventory.recommendedCostPrice",
            "lastUpdated", "name", "productGroup.productGroupNumber", "productNumber", "recommendedPrice", "salesPrice",
            "unit.unitNumber"
        };
    }

    public class ProductGroupReadModel
    {
        public int ProductGroupNumber { get; set; }
        public string name { get; set; }
    }

    public class Inventory
    {
        public decimal Available { get; set; }
        public decimal GrossWeight { get; set; }
        public decimal NetWeight { get; set; }
        public decimal InStock { get; set; }
        public DateTimeOffset InventoryLastUpdated { get; set; }
        public decimal OrderedByCustomers { get; set; }
        public decimal OrderedFromSuppliers { get; set; }
        public decimal PackageVolume { get; set; }
        public decimal RecommendedCostPrice { get; set; }
    }

    public class DepartmentalDistribution
    {
        public int DepartmentalDistributionNumber { get; set; }
        public string DistributionType { get; set; }
        public Uri Self { get; set; }
    }
}