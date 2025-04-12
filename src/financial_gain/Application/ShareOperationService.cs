using financial_gain.Domain;
using financial_gain.Helpers;
using financial_gain.Interfaces;

namespace financial_gain.Application
{
    public class ShareOperationService : IShareOperations
    {
        private decimal meanPrice;

        private int totalShareQuantity;

        private decimal cumulativeDeficit;

        public ShareOperationService()
        {
            // Empty ctor, since we have nothing to instantiate at this point.
        }

        /// <summary>
        /// Consolidates the operations and its respective mechanics.
        /// </summary>
        /// <param name="operations"></param>
        /// <returns></returns>
        public List<Tax> ShareOperation(List<UserOperation> operations)
        {
            meanPrice = 0;

            totalShareQuantity = 0;

            cumulativeDeficit = 0;

            List<Tax> taxs = new List<Tax>();

            foreach (var operation in operations)
            {
                decimal tax = 0;

                decimal operationTotalValue = operation.UnitCost * operation.Quantity;

                if (operation.Operation == Constants.Operations.Buy)
                {
                    meanPrice = totalShareQuantity > 0 ? UpdateMeanPrice(operationTotalValue, operation.Quantity) : operation.UnitCost;

                    totalShareQuantity += operation.Quantity;
                }
                else if (operation.Operation == Constants.Operations.Sell)
                {
                    decimal gain = (operation.UnitCost - meanPrice) * operation.Quantity;

                    if (operationTotalValue > Constants.Values.IsentionBaseline)
                    {
                        if (gain > 0)
                        {
                            tax = CalculateTax(gain);
                        }
                    }

                    if (gain < 0)
                    {
                        cumulativeDeficit += Math.Abs(gain);
                    }

                    totalShareQuantity -= operation.Quantity;
                }

                taxs.Add(new Tax { TaxValue = tax });
            }

            return taxs;
        }

        /// <summary>
        /// Calculate the total tax for a sell operation in an entry.
        /// Cumulative Deficit is the total of deficit resulting in operations, in case the operation results in a loss
        /// </summary>
        /// <param name="operations"></param>
        /// <returns></returns>        
        private decimal CalculateTax(decimal gain)
        {
            decimal gainAfterDeficit = gain - cumulativeDeficit;

            if (gainAfterDeficit > 0)
            {

                cumulativeDeficit = 0;
                return Math.Round(0.20M * gainAfterDeficit, 2);
            }
            else
            {
                cumulativeDeficit -= gain;
                return 0;
            }
        }

        /// <summary>
        /// Update de Mean price of the operation according to the weighted arithmetic mean
        /// </summary>
        /// <param name="operationTotalValue"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        private decimal UpdateMeanPrice(decimal operationTotalValue, int quantity)
        {
            return (totalShareQuantity * meanPrice + operationTotalValue) / (totalShareQuantity + quantity);
        }
    }
}
