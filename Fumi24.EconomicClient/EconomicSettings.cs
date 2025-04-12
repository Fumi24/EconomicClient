namespace Fumi24.EconomicClient
{
    public class EconomicSettings
    {
        public string AppSecretToken { get; set; }
        public string AgreementGrantToken { get; set; }
        public int LayoutNumber { get; set; }
        public bool EanEnabled { get; set; } = false;
    }
}