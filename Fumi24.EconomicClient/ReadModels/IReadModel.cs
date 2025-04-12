using System.Collections.Generic;

namespace Fumi24.EconomicClient.ReadModels
{
    public interface IReadModel
    {
        IList<string> FieldsToFilter { get; }
    }
}