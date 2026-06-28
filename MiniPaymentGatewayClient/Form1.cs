using MiniPaymentGatewayClient.Services;
using System.ServiceModel;

namespace MiniPaymentGatewayClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAuthorize_Click(object sender, EventArgs e)
        {
            try
            {
                var binding = new BasicHttpBinding();

                var endpoint =
                    new EndpointAddress(
                        //"http://localhost:5133/PaymentService.svc");
                        "http://vindicate-diabolic-dingo.ngrok-free.dev/PaymentService.svc"); // To use this, open CMD and run: ngrok http 5133

                var factory =
                    new ChannelFactory<IPaymentService>(
                        binding,
                        endpoint);

                var client = factory.CreateChannel();

                string response =
                    client.AuthorizeTransaction(
                        txtCardNumber.Text,
                        decimal.Parse(txtAmount.Text),
                        txtMerchant.Text,
                        txtCurrency.Text);

                rtbConsole.AppendText(
                    "REQUEST SENT\n");

                rtbConsole.AppendText(
                    $"Card: {txtCardNumber.Text}\n");

                rtbConsole.AppendText(
                    $"Amount: {txtAmount.Text}\n");

                rtbConsole.AppendText(
                    $"Merchant: {txtMerchant.Text}\n");

                rtbConsole.AppendText(
                    $"Currency: {txtCurrency.Text}\n\n");

                rtbConsole.AppendText(
                    "SOAP RESPONSE\n");

                rtbConsole.AppendText(response);

                rtbConsole.AppendText(
                    "\n---------------------------------\n");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearchTransaction_Click(object sender, EventArgs e)
        {
            try
            {
                var binding = new BasicHttpBinding();

                var endpoint =
                    new EndpointAddress(
                        //"http://localhost:5133/PaymentService.svc");
                        "http://vindicate-diabolic-dingo.ngrok-free.dev/PaymentService.svc"); // To use this, open CMD and run: ngrok http 5133

                var factory =
                    new ChannelFactory<IPaymentService>(
                        binding,
                        endpoint);

                var client = factory.CreateChannel();

                string response =
                    client.GetTransactionById(
                        int.Parse(txtTransactionId.Text));

                rtbConsole.AppendText(
                    "\nTRANSACTION SEARCH\n");

                rtbConsole.AppendText(response);

                rtbConsole.AppendText(
                    "\n---------------------------------\n");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
