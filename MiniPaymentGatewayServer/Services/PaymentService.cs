using MiniPaymentGatewayServer.Data;
using MiniPaymentGatewayServer.Models;

namespace MiniPaymentGatewayServer.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly TransactionRepository _repository =
            new TransactionRepository();
// -------------------------------------------------------------------------------- //
        #region AuthorizeTransaction
        public string AuthorizeTransaction(string cardNumber,
                                           decimal amount,
                                           string merchant,
                                           string currency)
        {
            string status = amount <= 1000
                ? "APPROVED"
                : "DECLINED";
            string authCode =
                    Guid.NewGuid()
                        .ToString()
                        .Substring(0, 6)
                        .ToUpper();

            Transaction transaction =
                new Transaction
                {
                    CardNumber = cardNumber,
                    Amount = amount,
                    Merchant = merchant,
                    Currency = currency,
                    Status = status,
                    AuthCode = authCode,
                };

            int transactionId =
                _repository.SaveTransaction(transaction);

            return $@"
                <TransactionResponse>
                    <TransactionID>{transactionId}</TransactionID>
                    <Card>{cardNumber}</Card>
                    <Merchant>{merchant}</Merchant>
                    <Amount>{amount}</Amount>
                    <Currency>{currency}</Currency>
                    <Status>{status}</Status>
                    <AuthCode>{authCode}</AuthCode>
                </TransactionResponse>";
        }
        #endregion AuthorizeTransaction

// -------------------------------------------------------------------------------- //
        #region GetTransactionByID
        public string GetTransactionById(int transactionId)
        {
            Transaction? transaction =
                _repository.GetTransactionById(transactionId);

            if (transaction == null)
            {
                return $@"
<TransactionResponse>
    <Status>NOT_FOUND</Status>
</TransactionResponse>";
            }

            return $@"
<TransactionResponse>
    <TransactionID>{transaction.TransactionID}</TransactionID>
    <Card>{transaction.CardNumber}</Card>
    <Merchant>{transaction.Merchant}</Merchant>
    <Amount>{transaction.Amount}</Amount>
    <Currency>{transaction.Currency}</Currency>
    <Status>{transaction.Status}</Status>
    <AuthCode>{transaction.AuthCode}</AuthCode>
    <RequestTime>{transaction.RequestTime}</RequestTime>
</TransactionResponse>";
        }
        #endregion GetTransactionID
// -------------------------------------------------------------------------------- //
    }
}