namespace Clevr_CSV_Converter
{
    partial class ClevrCSVCoverterForm
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
            btnConvert = new Button();
            convertBtnResult = new Label();
            lbLogLink = new LinkLabel();
            lbPaymentCode = new Label();
            txtPaymentcode = new TextBox();
            txtPaieAuthenticationCode = new TextBox();
            lbUsernme = new Label();
            SuspendLayout();
            // 
            // btnConvert
            // 
            btnConvert.Location = new Point(108, 93);
            btnConvert.Name = "btnConvert";
            btnConvert.Size = new Size(75, 23);
            btnConvert.TabIndex = 0;
            btnConvert.Text = "Convert";
            btnConvert.UseVisualStyleBackColor = true;
            btnConvert.Click += btnConvert_Click;
            // 
            // convertBtnResult
            // 
            convertBtnResult.AutoSize = true;
            convertBtnResult.Location = new Point(108, 133);
            convertBtnResult.Name = "convertBtnResult";
            convertBtnResult.Size = new Size(71, 15);
            convertBtnResult.TabIndex = 1;
            convertBtnResult.Text = "[Result Text]";
            // 
            // lbLogLink
            // 
            lbLogLink.AutoSize = true;
            lbLogLink.Location = new Point(108, 157);
            lbLogLink.Name = "lbLogLink";
            lbLogLink.Size = new Size(75, 15);
            lbLogLink.TabIndex = 3;
            lbLogLink.TabStop = true;
            lbLogLink.Text = "[LogFileLink]";
            lbLogLink.LinkClicked += lbLogLink_LinkClicked;
            // 
            // lbPaymentCode
            // 
            lbPaymentCode.AutoSize = true;
            lbPaymentCode.Location = new Point(12, 29);
            lbPaymentCode.Name = "lbPaymentCode";
            lbPaymentCode.Size = new Size(89, 15);
            lbPaymentCode.TabIndex = 4;
            lbPaymentCode.Text = "Payment code :";
            // 
            // txtPaymentcode
            // 
            txtPaymentcode.Location = new Point(201, 26);
            txtPaymentcode.Name = "txtPaymentcode";
            txtPaymentcode.Size = new Size(100, 23);
            txtPaymentcode.TabIndex = 5;
            txtPaymentcode.Text = "302005";
            // 
            // txtPaieAuthenticationCode
            // 
            txtPaieAuthenticationCode.Location = new Point(201, 55);
            txtPaieAuthenticationCode.Name = "txtPaieAuthenticationCode";
            txtPaieAuthenticationCode.Size = new Size(100, 23);
            txtPaieAuthenticationCode.TabIndex = 7;
            txtPaieAuthenticationCode.Text = "SantaClauss";
            // 
            // lbUsernme
            // 
            lbUsernme.AutoSize = true;
            lbUsernme.Location = new Point(12, 58);
            lbUsernme.Name = "lbUsernme";
            lbUsernme.Size = new Size(184, 15);
            lbUsernme.TabIndex = 6;
            lbUsernme.Text = "Paie et GRH authentication code :";
            // 
            // ClevrCSVCoverterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(374, 188);
            Controls.Add(txtPaieAuthenticationCode);
            Controls.Add(lbUsernme);
            Controls.Add(txtPaymentcode);
            Controls.Add(lbPaymentCode);
            Controls.Add(lbLogLink);
            Controls.Add(convertBtnResult);
            Controls.Add(btnConvert);
            Name = "ClevrCSVCoverterForm";
            Text = "Clevr CSV Converter";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnConvert;
        private Label convertBtnResult;
        private LinkLabel lbLogLink;
        private Label lbPaymentCode;
        private TextBox txtPaymentcode;
        private TextBox txtPaieAuthenticationCode;
        private Label lbUsernme;
    }
}