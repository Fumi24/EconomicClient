using Fumi24.EconomicClient.ReadModels;

namespace Fumi24.EconomicClient.CreateModels
{
    public class CreateProductModel
    {
        public string ProductNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal CostPrice { get; set; }
        public decimal RecommendedPrice { get; set; }
        public decimal SalesPrice { get; set; }
        public string BarCode { get; set; }
        public bool Barred { get; set; }
        public Inventory Inventory { get; set; }
        public Unit Unit { get; set; }
        public ProductGroupReadModel ProductGroup { get; set; }
    }

}