namespace WindowsToolkit
{
    partial class mainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.fixPrinterBtn = new System.Windows.Forms.Button();
            this.fixWifiBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // fixPrinterBtn
            // 
            this.fixPrinterBtn.Location = new System.Drawing.Point(52, 75);
            this.fixPrinterBtn.Name = "fixPrinterBtn";
            this.fixPrinterBtn.Size = new System.Drawing.Size(75, 23);
            this.fixPrinterBtn.TabIndex = 0;
            this.fixPrinterBtn.Text = "Fix Printer";
            this.fixPrinterBtn.UseVisualStyleBackColor = true;
            this.fixPrinterBtn.Click += new System.EventHandler(this.fixPrinterBtn_Click);
            // 
            // fixWifiBtn
            // 
            this.fixWifiBtn.Location = new System.Drawing.Point(133, 75);
            this.fixWifiBtn.Name = "fixWifiBtn";
            this.fixWifiBtn.Size = new System.Drawing.Size(75, 23);
            this.fixWifiBtn.TabIndex = 1;
            this.fixWifiBtn.Text = "Fix WiFi";
            this.fixWifiBtn.UseVisualStyleBackColor = true;
            this.fixWifiBtn.Click += new System.EventHandler(this.fixWifiBtn_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 177);
            this.Controls.Add(this.fixWifiBtn);
            this.Controls.Add(this.fixPrinterBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Windows Toolkit";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button fixPrinterBtn;
        private System.Windows.Forms.Button fixWifiBtn;
    }
}

