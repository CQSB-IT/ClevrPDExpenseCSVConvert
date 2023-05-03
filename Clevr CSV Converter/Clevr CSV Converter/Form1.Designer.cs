namespace Clevr_CSV_Converter
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
            this.btnConvert = new System.Windows.Forms.Button();
            this.convertBtnResult = new System.Windows.Forms.Label();
            this.lbLogLink = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(303, 168);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(75, 23);
            this.btnConvert.TabIndex = 0;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // convertBtnResult
            // 
            this.convertBtnResult.AutoSize = true;
            this.convertBtnResult.Location = new System.Drawing.Point(268, 236);
            this.convertBtnResult.Name = "convertBtnResult";
            this.convertBtnResult.Size = new System.Drawing.Size(71, 15);
            this.convertBtnResult.TabIndex = 1;
            this.convertBtnResult.Text = "[Result Text]";
            // 
            // lbLogLink
            // 
            this.lbLogLink.AutoSize = true;
            this.lbLogLink.Location = new System.Drawing.Point(268, 260);
            this.lbLogLink.Name = "lbLogLink";
            this.lbLogLink.Size = new System.Drawing.Size(75, 15);
            this.lbLogLink.TabIndex = 3;
            this.lbLogLink.TabStop = true;
            this.lbLogLink.Text = "[LogFileLink]";
            this.lbLogLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbLogLink_LinkClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbLogLink);
            this.Controls.Add(this.convertBtnResult);
            this.Controls.Add(this.btnConvert);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnConvert;
        private Label convertBtnResult;
        private LinkLabel lbLogLink;
    }
}