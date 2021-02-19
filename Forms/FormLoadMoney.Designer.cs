namespace Geldautomat.Forms
{
    partial class FormLoadMoney
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxMoney = new System.Windows.Forms.TextBox();
            this.labelMoney = new System.Windows.Forms.Label();
            this.buttonAccept = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.textBoxMoney);
            this.panel1.Controls.Add(this.labelMoney);
            this.panel1.Location = new System.Drawing.Point(24, 83);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(422, 69);
            this.panel1.TabIndex = 8;
            // 
            // textBoxMoney
            // 
            this.textBoxMoney.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.textBoxMoney.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxMoney.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBoxMoney.Font = new System.Drawing.Font("Rockwell Nova", 13.77391F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMoney.ForeColor = System.Drawing.Color.White;
            this.textBoxMoney.Location = new System.Drawing.Point(0, 33);
            this.textBoxMoney.Name = "textBoxMoney";
            this.textBoxMoney.Size = new System.Drawing.Size(422, 36);
            this.textBoxMoney.TabIndex = 0;
            // 
            // labelMoney
            // 
            this.labelMoney.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelMoney.Font = new System.Drawing.Font("Tahoma", 13.77391F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMoney.ForeColor = System.Drawing.Color.White;
            this.labelMoney.Location = new System.Drawing.Point(0, 0);
            this.labelMoney.Name = "labelMoney";
            this.labelMoney.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.labelMoney.Size = new System.Drawing.Size(422, 33);
            this.labelMoney.TabIndex = 2;
            this.labelMoney.Text = "Money";
            this.labelMoney.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonAccept
            // 
            this.buttonAccept.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(137)))), ((int)(((byte)(137)))));
            this.buttonAccept.FlatAppearance.BorderSize = 0;
            this.buttonAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAccept.Font = new System.Drawing.Font("Consolas", 13.77391F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAccept.ForeColor = System.Drawing.Color.White;
            this.buttonAccept.Location = new System.Drawing.Point(152, 202);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(157, 37);
            this.buttonAccept.TabIndex = 9;
            this.buttonAccept.Text = "Akzeptieren";
            this.buttonAccept.UseVisualStyleBackColor = false;
            this.buttonAccept.Click += new System.EventHandler(this.OnButtonAcceptClicked);
            // 
            // Aufladen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 264);
            this.Controls.Add(this.buttonAccept);
            this.Controls.Add(this.panel1);
            this.MaximumSize = new System.Drawing.Size(700, 420);
            this.MinimumSize = new System.Drawing.Size(450, 220);
            this.Name = "Aufladen";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.buttonAccept, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxMoney;
        private System.Windows.Forms.Label labelMoney;
        private System.Windows.Forms.Button buttonAccept;
    }
}