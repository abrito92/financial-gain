using Newtonsoft.Json;

namespace financial_gain.Domain
{
    /// <summary>
    /// This is the class that maps the input json. It is the core entity of the project.
    /// As it doesn't have any particular business rules, it simply instantiates the propreties.
    /// </summary>
    public class UserOperation
    {
        [JsonProperty("operation")]
        public string Operation { get; private set; }

        [JsonProperty("unit-cost")]
        public decimal UnitCost { get; private set; }

        [JsonProperty("quantity")]
        public int Quantity { get; private set; }

        public UserOperation(string operation, decimal unitCost, int quantity)
        {
            Operation = operation;
            UnitCost = unitCost;
            Quantity = quantity;
        }
    }
}
