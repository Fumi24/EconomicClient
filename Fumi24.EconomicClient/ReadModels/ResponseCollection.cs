using System;
using System.Collections.Generic;

namespace Fumi24.EconomicClient.ReadModels
{
    public class ResponseCollection<T>
    {
        public List<T> Collection { get; set; }
        public Pagination Pagination { get; set; }
        public MetaData MetaData { get; set; }
        public Uri Self { get; set; }
    }
    
    public  class Pagination
    {
        public long MaxPageSizeAllowed { get; set; }
        public long SkipPages { get; set; }
        public long PageSize { get; set; }
        public long Results { get; set; }
        public long ResultsWithoutFilter { get; set; }
        public Uri FirstPage { get; set; }
        public Uri LastPage { get; set; }
    }
}