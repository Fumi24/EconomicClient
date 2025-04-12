using Fumi24.EconomicClient.CreateModels;

namespace Fumi24.EconomicClient.ReadModels
{
    public class JournalReadModel
    {
        public Entries Entries { get; set; }
        public AccountingYear AccountingYear { get; set; }
        public long VoucherNumber { get; set; }
    }
}