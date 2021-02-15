namespace Geldautomat.Forms
{
    partial class FormViewBank
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
            this.labelWelcome = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelMoney = new System.Windows.Forms.Label();
            this.labelMoneyTitle = new System.Windows.Forms.Label();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.panelOverlap = new System.Windows.Forms.Panel();
            this.panelMenuFields = new System.Windows.Forms.Panel();
            this.buttonTransactions = new System.Windows.Forms.Button();
            this.buttonLoadMoney = new System.Windows.Forms.Button();
            this.buttonPay = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panelMenu.SuspendLayout();
            this.panelMenuFields.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelWelcome
            // 
            this.labelWelcome.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelWelcome.Font = new System.Drawing.Font("Tahoma", 28.17391F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWelcome.ForeColor = System.Drawing.Color.White;
            this.labelWelcome.Location = new System.Drawing.Point(212, 52);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.labelWelcome.Size = new System.Drawing.Size(806, 59);
            this.labelWelcome.TabIndex = 9;
            this.labelWelcome.Text = "Willkommen <Name>";
            this.labelWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.labelMoney);
            this.panel1.Controls.Add(this.labelMoneyTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(212, 111);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(806, 47);
            this.panel1.TabIndex = 10;
            // 
            // labelMoney
            // 
            this.labelMoney.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelMoney.Font = new System.Drawing.Font("Tahoma", 20.03478F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMoney.ForeColor = System.Drawing.Color.White;
            this.labelMoney.Location = new System.Drawing.Point(228, 0);
            this.labelMoney.Name = "labelMoney";
            this.labelMoney.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.labelMoney.Size = new System.Drawing.Size(228, 47);
            this.labelMoney.TabIndex = 11;
            this.labelMoney.Text = "<Geld>";
            this.labelMoney.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelMoneyTitle
            // 
            this.labelMoneyTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelMoneyTitle.Font = new System.Drawing.Font("Tahoma", 20.03478F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMoneyTitle.ForeColor = System.Drawing.Color.White;
            this.labelMoneyTitle.Location = new System.Drawing.Point(0, 0);
            this.labelMoneyTitle.Name = "labelMoneyTitle";
            this.labelMoneyTitle.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.labelMoneyTitle.Size = new System.Drawing.Size(228, 47);
            this.labelMoneyTitle.TabIndex = 10;
            this.labelMoneyTitle.Text = "Kontostand:";
            this.labelMoneyTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panelMenu.Controls.Add(this.buttonLogout);
            this.panelMenu.Controls.Add(this.panelOverlap);
            this.panelMenu.Controls.Add(this.panelMenuFields);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(212, 606);
            this.panelMenu.TabIndex = 11;
            // 
            // buttonLogout
            // 
            this.buttonLogout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(137)))), ((int)(((byte)(137)))));
            this.buttonLogout.FlatAppearance.BorderSize = 0;
            this.buttonLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogout.Font = new System.Drawing.Font("Consolas", 13.77391F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.buttonLogout.Location = new System.Drawing.Point(10, 557);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(188, 37);
            this.buttonLogout.TabIndex = 11;
            this.buttonLogout.Text = "Logout";
            this.buttonLogout.UseVisualStyleBackColor = false;
            // 
            // panelOverlap
            // 
            this.panelOverlap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(126)))), ((int)(((byte)(206)))));
            this.panelOverlap.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelOverlap.Location = new System.Drawing.Point(0, 0);
            this.panelOverlap.Name = "panelOverlap";
            this.panelOverlap.Size = new System.Drawing.Size(212, 52);
            this.panelOverlap.TabIndex = 10;
            // 
            // panelMenuFields
            // 
            this.panelMenuFields.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panelMenuFields.AutoSize = true;
            this.panelMenuFields.Controls.Add(this.buttonTransactions);
            this.panelMenuFields.Controls.Add(this.buttonLoadMoney);
            this.panelMenuFields.Controls.Add(this.buttonPay);
            this.panelMenuFields.Location = new System.Drawing.Point(10, 217);
            this.panelMenuFields.Name = "panelMenuFields";
            this.panelMenuFields.Size = new System.Drawing.Size(191, 144);
            this.panelMenuFields.TabIndex = 9;
            // 
            // buttonTransactions
            // 
            this.buttonTransactions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonTransactions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(137)))), ((int)(((byte)(137)))));
            this.buttonTransactions.FlatAppearance.BorderSize = 0;
            this.buttonTransactions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTransactions.Font = new System.Drawing.Font("Consolas", 13.77391F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTransactions.ForeColor = System.Drawing.Color.White;
            this.buttonTransactions.Location = new System.Drawing.Point(0, 0);
            this.buttonTransactions.Name = "buttonTransactions";
            this.buttonTransactions.Size = new System.Drawing.Size(188, 37);
            this.buttonTransactions.TabIndex = 6;
            this.buttonTransactions.Text = "Transaktionen";
            this.buttonTransactions.UseVisualStyleBackColor = false;
            // 
            // buttonLoadMoney
            // 
            this.buttonLoadMoney.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLoadMoney.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(137)))), ((int)(((byte)(137)))));
            this.buttonLoadMoney.FlatAppearance.BorderSize = 0;
            this.buttonLoadMoney.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLoadMoney.Font = new System.Drawing.Font("Consolas", 13.77391F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLoadMoney.ForeColor = System.Drawing.Color.White;
            this.buttonLoadMoney.Location = new System.Drawing.Point(0, 104);
            this.buttonLoadMoney.Name = "buttonLoadMoney";
            this.buttonLoadMoney.Size = new System.Drawing.Size(188, 37);
            this.buttonLoadMoney.TabIndex = 8;
            this.buttonLoadMoney.Text = "Aufladen";
            this.buttonLoadMoney.UseVisualStyleBackColor = false;
            // 
            // buttonPay
            // 
            this.buttonPay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(137)))), ((int)(((byte)(137)))));
            this.buttonPay.FlatAppearance.BorderSize = 0;
            this.buttonPay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPay.Font = new System.Drawing.Font("Consolas", 13.77391F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPay.ForeColor = System.Drawing.Color.White;
            this.buttonPay.Location = new System.Drawing.Point(0, 52);
            this.buttonPay.Name = "buttonPay";
            this.buttonPay.Size = new System.Drawing.Size(188, 37);
            this.buttonPay.TabIndex = 7;
            this.buttonPay.Text = "Bezahlen";
            this.buttonPay.UseVisualStyleBackColor = false;
            // 
            // FormViewBank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 606);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelWelcome);
            this.Controls.Add(this.panelMenu);
            this.MinimumSize = new System.Drawing.Size(900, 550);
            this.Name = "FormViewBank";
            this.Controls.SetChildIndex(this.panelMenu, 0);
            this.Controls.SetChildIndex(this.labelWelcome, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            this.panelMenuFields.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelWelcome;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelMoneyTitle;
        private System.Windows.Forms.Label labelMoney;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button buttonLoadMoney;
        private System.Windows.Forms.Button buttonPay;
        private System.Windows.Forms.Button buttonTransactions;
        private System.Windows.Forms.Panel panelOverlap;
        private System.Windows.Forms.Panel panelMenuFields;
        private System.Windows.Forms.Button buttonLogout;
    }
}