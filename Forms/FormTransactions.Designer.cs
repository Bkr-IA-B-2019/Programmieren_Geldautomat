namespace Geldautomat.Forms
{
    partial class FormTransactions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTransactions));
            this.panelTransactions = new System.Windows.Forms.Panel();
            this.panelError = new System.Windows.Forms.Panel();
            this.labelValue = new System.Windows.Forms.Label();
            this.labelError = new System.Windows.Forms.Label();
            this.labelErrorTitle = new System.Windows.Forms.Label();
            this.panelError.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTransactions
            // 
            this.panelTransactions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTransactions.AutoScroll = true;
            this.panelTransactions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTransactions.Location = new System.Drawing.Point(0, 55);
            this.panelTransactions.Name = "panelTransactions";
            this.panelTransactions.Padding = new System.Windows.Forms.Padding(10);
            this.panelTransactions.Size = new System.Drawing.Size(357, 660);
            this.panelTransactions.TabIndex = 8;
            // 
            // panelError
            // 
            this.panelError.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelError.Controls.Add(this.labelValue);
            this.panelError.Controls.Add(this.labelError);
            this.panelError.Controls.Add(this.labelErrorTitle);
            this.panelError.Location = new System.Drawing.Point(363, 55);
            this.panelError.Name = "panelError";
            this.panelError.Size = new System.Drawing.Size(365, 660);
            this.panelError.TabIndex = 9;
            // 
            // labelValue
            // 
            this.labelValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelValue.Font = new System.Drawing.Font("Consolas", 16.27826F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelValue.ForeColor = System.Drawing.Color.White;
            this.labelValue.Location = new System.Drawing.Point(0, 597);
            this.labelValue.Name = "labelValue";
            this.labelValue.Padding = new System.Windows.Forms.Padding(5);
            this.labelValue.Size = new System.Drawing.Size(365, 52);
            this.labelValue.TabIndex = 2;
            this.labelValue.Text = "<Wert>";
            this.labelValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelError
            // 
            this.labelError.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelError.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.27826F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelError.ForeColor = System.Drawing.Color.White;
            this.labelError.Location = new System.Drawing.Point(3, 46);
            this.labelError.Name = "labelError";
            this.labelError.Padding = new System.Windows.Forms.Padding(5);
            this.labelError.Size = new System.Drawing.Size(359, 551);
            this.labelError.TabIndex = 1;
            this.labelError.Text = resources.GetString("labelError.Text");
            this.labelError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelErrorTitle
            // 
            this.labelErrorTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelErrorTitle.Font = new System.Drawing.Font("Rockwell Nova", 13.77391F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelErrorTitle.ForeColor = System.Drawing.Color.OrangeRed;
            this.labelErrorTitle.Location = new System.Drawing.Point(3, 0);
            this.labelErrorTitle.Name = "labelErrorTitle";
            this.labelErrorTitle.Size = new System.Drawing.Size(359, 46);
            this.labelErrorTitle.TabIndex = 0;
            this.labelErrorTitle.Text = "❗ INKONSISTENTE DATEN ❗";
            this.labelErrorTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormTransactions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 714);
            this.Controls.Add(this.panelError);
            this.Controls.Add(this.panelTransactions);
            this.Name = "FormTransactions";
            this.Controls.SetChildIndex(this.panelTransactions, 0);
            this.Controls.SetChildIndex(this.panelError, 0);
            this.panelError.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTransactions;
        private System.Windows.Forms.Panel panelError;
        private System.Windows.Forms.Label labelValue;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.Label labelErrorTitle;
    }
}