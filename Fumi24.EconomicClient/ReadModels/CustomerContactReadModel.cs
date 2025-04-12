using Fumi24.EconomicClient.CreateModels;

namespace Fumi24.EconomicClient.ReadModels
{
    public class CustomerContactReadModel
    {
        public int CustomerContactNumber { get; set; }
        public string Name { get; set; }
        public Customer Customer { get; set; }
    }
}