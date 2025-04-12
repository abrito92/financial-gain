using financial_gain.Domain;

namespace financial_gain.Interfaces
{
    public interface IShareOperations
    {
        public List<Tax> ShareOperation(List<UserOperation> operations);
    }
}
