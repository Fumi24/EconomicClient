namespace Fumi24.EconomicClient.CreateModels
{
    public class BookInvoiceModel
    {
        public DraftInvoice DraftInvoice { get; set; }
        public string SendBy { get; set; } = "none";
        
        public BookInvoiceModel(long draftInvoiceNumber, SendBy sendBy)
        {
            DraftInvoice = new DraftInvoice
            {
                DraftInvoiceNumber = draftInvoiceNumber
            };
            if (sendBy == CreateModels.SendBy.Ean)
            {
                SendBy = "Ean";
            }
        }
    }

    public class DraftInvoice
    {
        public long DraftInvoiceNumber { get; set; }
    }

    public enum SendBy
    {
        Ean,
        None
    }
}