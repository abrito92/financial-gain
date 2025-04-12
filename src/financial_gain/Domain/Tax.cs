using Newtonsoft.Json;

namespace financial_gain.Domain
{
    public class Tax
    {
        [JsonProperty("tax")]
        public decimal TaxValue { get; set; }
    }
}
