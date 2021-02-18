namespace Geldautomat.Forms
{
    partial class Transaktionen
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
            this.panelTransactions = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panelTransactions
            // 
            this.panelTransactions.AutoScroll = true;
            this.panelTransactions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTransactions.Location = new System.Drawing.Point(0, 52);
            this.panelTransactions.Name = "panelTransactions";
            this.panelTransactions.Padding = new System.Windows.Forms.Padding(10);
            this.panelTransactions.Size = new System.Drawing.Size(340, 568);
            this.panelTransactions.TabIndex = 8;
            // 
            // Transaktionen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 620);
            this.Controls.Add(this.panelTransactions);
            this.Name = "Transaktionen";
            this.Controls.SetChildIndex(this.panelTransactions, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTransactions;
    }
}