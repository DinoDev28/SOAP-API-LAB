namespace MiniPaymentGatewayClient
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            CardNumber = new Label();
            txtCardNumber = new TextBox();
            Amount = new Label();
            txtAmount = new TextBox();
            Merchant = new Label();
            txtMerchant = new TextBox();
            currency = new Label();
            txtCurrency = new TextBox();
            btnAuthorize = new Button();
            rtbConsole = new RichTextBox();
            txtTransactionId = new TextBox();
            btnSearchTransaction = new Button();
            SuspendLayout();
            // 
            // CardNumber
            // 
            CardNumber.AutoSize = true;
            CardNumber.Location = new Point(12, 60);
            CardNumber.Name = "CardNumber";
            CardNumber.Size = new Size(79, 15);
            CardNumber.TabIndex = 0;
            CardNumber.Text = "Card Number";
            // 
            // txtCardNumber
            // 
            txtCardNumber.Location = new Point(97, 57);
            txtCardNumber.Name = "txtCardNumber";
            txtCardNumber.Size = new Size(222, 23);
            txtCardNumber.TabIndex = 1;
            // 
            // Amount
            // 
            Amount.AutoSize = true;
            Amount.Location = new Point(12, 103);
            Amount.Name = "Amount";
            Amount.Size = new Size(51, 15);
            Amount.TabIndex = 2;
            Amount.Text = "Amount";
            // 
            // txtAmount
            // 
            txtAmount.Location = new Point(97, 103);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(100, 23);
            txtAmount.TabIndex = 3;
            // 
            // Merchant
            // 
            Merchant.AutoSize = true;
            Merchant.Location = new Point(12, 145);
            Merchant.Name = "Merchant";
            Merchant.Size = new Size(58, 15);
            Merchant.TabIndex = 4;
            Merchant.Text = "Merchant";
            // 
            // txtMerchant
            // 
            txtMerchant.Location = new Point(97, 145);
            txtMerchant.Name = "txtMerchant";
            txtMerchant.Size = new Size(100, 23);
            txtMerchant.TabIndex = 5;
            // 
            // currency
            // 
            currency.AutoSize = true;
            currency.Location = new Point(12, 196);
            currency.Name = "currency";
            currency.Size = new Size(55, 15);
            currency.TabIndex = 6;
            currency.Text = "Currency";
            // 
            // txtCurrency
            // 
            txtCurrency.Location = new Point(97, 188);
            txtCurrency.Name = "txtCurrency";
            txtCurrency.Size = new Size(100, 23);
            txtCurrency.TabIndex = 7;
            // 
            // btnAuthorize
            // 
            btnAuthorize.Location = new Point(12, 250);
            btnAuthorize.Name = "btnAuthorize";
            btnAuthorize.Size = new Size(158, 59);
            btnAuthorize.TabIndex = 8;
            btnAuthorize.Text = "Authorize Transaction";
            btnAuthorize.UseVisualStyleBackColor = true;
            btnAuthorize.Click += btnAuthorize_Click;
            // 
            // rtbConsole
            // 
            rtbConsole.Location = new Point(-4, 315);
            rtbConsole.Name = "rtbConsole";
            rtbConsole.Size = new Size(804, 123);
            rtbConsole.TabIndex = 9;
            rtbConsole.Text = "";
            // 
            // txtTransactionId
            // 
            txtTransactionId.Location = new Point(630, 231);
            txtTransactionId.Name = "txtTransactionId";
            txtTransactionId.Size = new Size(158, 23);
            txtTransactionId.TabIndex = 10;
            // 
            // btnSearchTransaction
            // 
            btnSearchTransaction.Location = new Point(630, 260);
            btnSearchTransaction.Name = "btnSearchTransaction";
            btnSearchTransaction.Size = new Size(158, 38);
            btnSearchTransaction.TabIndex = 11;
            btnSearchTransaction.Text = "Search Transaction ID";
            btnSearchTransaction.UseVisualStyleBackColor = true;
            btnSearchTransaction.Click += btnSearchTransaction_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSearchTransaction);
            Controls.Add(txtTransactionId);
            Controls.Add(rtbConsole);
            Controls.Add(btnAuthorize);
            Controls.Add(txtCurrency);
            Controls.Add(currency);
            Controls.Add(txtMerchant);
            Controls.Add(Merchant);
            Controls.Add(txtAmount);
            Controls.Add(Amount);
            Controls.Add(txtCardNumber);
            Controls.Add(CardNumber);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label CardNumber;
        private TextBox txtCardNumber;
        private Label Amount;
        private TextBox txtAmount;
        private Label Merchant;
        private TextBox txtMerchant;
        private Label currency;
        private TextBox txtCurrency;
        private Button btnAuthorize;
        private RichTextBox rtbConsole;
        private TextBox txtTransactionId;
        private Button btnSearchTransaction;
    }
}
