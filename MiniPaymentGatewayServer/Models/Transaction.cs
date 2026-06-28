namespace MiniPaymentGatewayServer.Models
{
    public class Transaction
    {
        public int TransactionID { get; set; }

        public string CardNumber { get; set; }

        public decimal Amount { get; set; }

        public string Merchant { get; set; }

        public string Currency { get; set; }

        public string Status { get; set; }

        public string AuthCode { get; set; }

        public string Note { get; set; }

        public DateTime RequestTime { get; set; }
    }
}
