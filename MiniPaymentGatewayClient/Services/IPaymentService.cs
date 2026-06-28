using System.ServiceModel;

namespace MiniPaymentGatewayClient.Services
{
    [ServiceContract]
    public interface IPaymentService
    {
        [OperationContract]
        string AuthorizeTransaction(string cardNumber,
                            decimal amount,
                            string merchant,
                            string currency);

        [OperationContract]
        string GetTransactionById(int transactionId);
    }
}
