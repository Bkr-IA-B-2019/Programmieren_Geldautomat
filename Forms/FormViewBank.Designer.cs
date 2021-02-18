namespace Geldautomat.Forms
{
    partial class Bank
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
            this.panelMoney = new System.Windows.Forms.Panel();
            this.labelMoney = new System.Windows.Forms.Label();
            this.labelMoneyTitle = new System.Windows.Forms.Label();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.panelOverlap = new System.Windows.Forms.Panel();
            this.panelMenuFields = new System.Windows.Forms.Panel();
            this.buttonTransactions = new System.Windows.Forms.Button();
            this.buttonLoadMoney = new System.Windows.Forms.Button();
            this.buttonPay = new System.Windows.Forms.Button();
            this.panelId = new System.Windows.Forms.Panel();
            this.labelId = new System.Windows.Forms.Label();
            this.labelIdTitle = new System.Windows.Forms.Label();
            this.panelWelcome = new System.Windows.Forms.Panel();
            this.labelWelcome = new System.Windows.Forms.Label();
            this.labelWelcomeTitle = new System.Windows.Forms.Label();
            this.panelMoney.SuspendLayout();
            this.panelMenu.SuspendLayout();
            this.panelMenuFields.SuspendLayout();
            this.panelId.SuspendLayout();
            this.panelWelcome.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMoney
            // 
            this.panelMoney.BackColor = System.Drawing.Color.Transparent;
            this.panelMoney.Controls.Add(this.labelMoney);
            this.panelMoney.Controls.Add(this.labelMoneyTitle);
            this.panelMoney.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMoney.Location = new System.Drawing.Point(212, 116);
            this.panelMoney.Name = "panelMoney";
            this.panelMoney.Size = new System.Drawing.Size(806, 47);
            this.panelMoney.TabIndex = 10;
            // 
            // labelMoney
            // 
            this.labelMoney.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelMoney.Font = new System.Drawing.Font("Tahoma", 20.03478F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMoney.ForeColor = System.Drawing.Color.White;
            this.labelMoney.Location = new System.Drawing.Point(208, 0);
            this.labelMoney.Name = "labelMoney";
            this.labelMoney.Size = new System.Drawing.Size(595, 47);
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
            this.labelMoneyTitle.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.labelMoneyTitle.Size = new System.Drawing.Size(208, 47);
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
            this.panelMenu.Location = new System.Drawing.Point(0, 52);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(212, 554);
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
            this.buttonLogout.Location = new System.Drawing.Point(10, 505);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(188, 37);
            this.buttonLogout.TabIndex = 11;
            this.buttonLogout.Text = "Logout";
            this.buttonLogout.UseVisualStyleBackColor = false;
            this.buttonLogout.Click += new System.EventHandler(this.OnButtonLogoutClicked);
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
            this.panelMenuFields.Location = new System.Drawing.Point(10, 191);
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
            this.buttonTransactions.Click += new System.EventHandler(this.OnButtonTransactionsClicked);
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
            this.buttonLoadMoney.Click += new System.EventHandler(this.OnButtonLoadMoneyClicked);
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
            this.buttonPay.Click += new System.EventHandler(this.OnButtonBuyClicked);
            // 
            // panelId
            // 
            this.panelId.BackColor = System.Drawing.Color.Transparent;
            this.panelId.Controls.Add(this.labelId);
            this.panelId.Controls.Add(this.labelIdTitle);
            this.panelId.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelId.Location = new System.Drawing.Point(212, 163);
            this.panelId.Name = "panelId";
            this.panelId.Size = new System.Drawing.Size(806, 47);
            this.panelId.TabIndex = 12;
            // 
            // labelId
            // 
            this.labelId.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelId.Font = new System.Drawing.Font("Tahoma", 20.03478F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelId.ForeColor = System.Drawing.Color.White;
            this.labelId.Location = new System.Drawing.Point(153, 0);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(632, 47);
            this.labelId.TabIndex = 11;
            this.labelId.Text = "<ID>";
            this.labelId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelIdTitle
            // 
            this.labelIdTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelIdTitle.Font = new System.Drawing.Font("Tahoma", 20.03478F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIdTitle.ForeColor = System.Drawing.Color.White;
            this.labelIdTitle.Location = new System.Drawing.Point(0, 0);
            this.labelIdTitle.Name = "labelIdTitle";
            this.labelIdTitle.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.labelIdTitle.Size = new System.Drawing.Size(153, 47);
            this.labelIdTitle.TabIndex = 10;
            this.labelIdTitle.Text = "Ihre ID:";
            this.labelIdTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelWelcome
            // 
            this.panelWelcome.Controls.Add(this.labelWelcome);
            this.panelWelcome.Controls.Add(this.labelWelcomeTitle);
            this.panelWelcome.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelWelcome.Location = new System.Drawing.Point(212, 52);
            this.panelWelcome.Name = "panelWelcome";
            this.panelWelcome.Size = new System.Drawing.Size(806, 64);
            this.panelWelcome.TabIndex = 13;
            // 
            // labelWelcome
            // 
            this.labelWelcome.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelWelcome.Font = new System.Drawing.Font("Tahoma", 28.17391F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWelcome.ForeColor = System.Drawing.Color.White;
            this.labelWelcome.Location = new System.Drawing.Point(335, 0);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Size = new System.Drawing.Size(472, 64);
            this.labelWelcome.TabIndex = 11;
            this.labelWelcome.Text = "<Name>";
            this.labelWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelWelcomeTitle
            // 
            this.labelWelcomeTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelWelcomeTitle.Font = new System.Drawing.Font("Tahoma", 28.17391F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWelcomeTitle.ForeColor = System.Drawing.Color.White;
            this.labelWelcomeTitle.Location = new System.Drawing.Point(0, 0);
            this.labelWelcomeTitle.Name = "labelWelcomeTitle";
            this.labelWelcomeTitle.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.labelWelcomeTitle.Size = new System.Drawing.Size(335, 64);
            this.labelWelcomeTitle.TabIndex = 10;
            this.labelWelcomeTitle.Text = "Willkommen";
            this.labelWelcomeTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Bank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 606);
            this.Controls.Add(this.panelId);
            this.Controls.Add(this.panelMoney);
            this.Controls.Add(this.panelWelcome);
            this.Controls.Add(this.panelMenu);
            this.MinimumSize = new System.Drawing.Size(900, 550);
            this.Name = "Bank";
            this.Controls.SetChildIndex(this.panelMenu, 0);
            this.Controls.SetChildIndex(this.panelWelcome, 0);
            this.Controls.SetChildIndex(this.panelMoney, 0);
            this.Controls.SetChildIndex(this.panelId, 0);
            this.panelMoney.ResumeLayout(false);
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            this.panelMenuFields.ResumeLayout(false);
            this.panelId.ResumeLayout(false);
            this.panelWelcome.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelMoney;
        private System.Windows.Forms.Label labelMoneyTitle;
        private System.Windows.Forms.Label labelMoney;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button buttonLoadMoney;
        private System.Windows.Forms.Button buttonPay;
        private System.Windows.Forms.Button buttonTransactions;
        private System.Windows.Forms.Panel panelOverlap;
        private System.Windows.Forms.Panel panelMenuFields;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.Panel panelId;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.Label labelIdTitle;
        private System.Windows.Forms.Panel panelWelcome;
        private System.Windows.Forms.Label labelWelcome;
        private System.Windows.Forms.Label labelWelcomeTitle;
    }
}