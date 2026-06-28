using Microsoft.Data.SqlClient;
using MiniPaymentGatewayServer.Models;

namespace MiniPaymentGatewayServer.Data
{
    public class TransactionRepository
    {
        private readonly string _connectionString =
            @"Server=.\SQLEXPRESS;
              Database=MiniPaymentGatewayDB;
              Trusted_Connection=True;
              TrustServerCertificate=True;";
        // --------- Transaction methods -------------------------------//

        /// <summary>
        /// Logs an incoming transaction into the SQL DB
        /// </summary>
        /// <param name="transaction">Pues la transaction carnal que mas va a ser?</param>
        /// <returns>Returns the SOAP response along with the transaction decision</returns>
        public int SaveTransaction(Transaction transaction)
        {
            using SqlConnection connection =
                new SqlConnection(_connectionString);

            connection.Open();

            string query = @"
                INSERT INTO Transactions
                (
                    CardNumber,
                    Amount,
                    Merchant,
                    Currency,
                    Status,
                    AuthCode
                )

                OUTPUT INSERTED.TransactionID

                VALUES
                (
                    @CardNumber,
                    @Amount,
                    @Merchant,
                    @Currency,
                    @Status,
                    @AuthCode
                );";

            using SqlCommand command =
                new SqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@CardNumber",
                transaction.CardNumber);

            command.Parameters.AddWithValue(
                "@Amount",
                transaction.Amount);

            command.Parameters.AddWithValue(
                "@Merchant",
                transaction.Merchant);

            command.Parameters.AddWithValue(
                "@Currency",
                transaction.Currency);

            command.Parameters.AddWithValue(
                "@Status",
                transaction.Status);

            command.Parameters.AddWithValue(
                "@AuthCode",
                transaction.AuthCode);

            int transactionId =
                (int)command.ExecuteScalar();

            return transactionId;
        }

        // ----------------------------------------------------------------------//
        // ----------------------------------------------------------------------//

        // ----------------------------------------------------------------------//

        // ----------------------------------------------------------------------//
        // ----------------------------------------------------------------------//

        /// <summary>
        /// Retrieves a transaction record from the SQL DB filtering by transaction ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns a table row if the ID is valid or exists </returns>
        public Transaction? GetTransactionById(int id)
        {
            using SqlConnection connection =
                new SqlConnection(_connectionString);

            connection.Open();

            string query = @"
        SELECT *
        FROM Transactions
        WHERE TransactionID = @Id";

            using SqlCommand command =
                new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Id", id);

            using SqlDataReader reader =
                command.ExecuteReader();

            if (reader.Read())
            {
                return new Transaction
                {
                    TransactionID = Convert.ToInt32(reader["TransactionID"]),
                    CardNumber = reader["CardNumber"].ToString(),
                    Amount = Convert.ToDecimal(reader["Amount"]),
                    Merchant = reader["Merchant"].ToString(),
                    Currency = reader["Currency"].ToString(),
                    Status = reader["Status"].ToString(),
                    AuthCode = reader["AuthCode"].ToString(),
                    RequestTime = Convert.ToDateTime(reader["RequestTime"])
                };
            }

            return null;
        }
        // --------- END Transaction methods -------------------------------//

    }
}
