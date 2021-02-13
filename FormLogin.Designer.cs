namespace Geldautomat
{
    partial class FormLogin
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
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelId = new System.Windows.Forms.Label();
            this.textBoxPin = new System.Windows.Forms.TextBox();
            this.labelPin = new System.Windows.Forms.Label();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxId
            // 
            this.textBoxId.Font = new System.Drawing.Font("Rockwell Nova", 13.77391F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxId.Location = new System.Drawing.Point(12, 93);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.Size = new System.Drawing.Size(199, 36);
            this.textBoxId.TabIndex = 0;
            // 
            // labelTitle
            // 
            this.labelTitle.Font = new System.Drawing.Font("Rockwell Nova", 16.27826F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(9, 9);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(202, 40);
            this.labelTitle.TabIndex = 1;
            this.labelTitle.Text = "Anmeldung";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelId
            // 
            this.labelId.Font = new System.Drawing.Font("Rockwell Nova", 11.89565F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelId.Location = new System.Drawing.Point(12, 64);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(202, 25);
            this.labelId.TabIndex = 2;
            this.labelId.Text = "ID";
            this.labelId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxPin
            // 
            this.textBoxPin.Font = new System.Drawing.Font("Rockwell Nova", 13.77391F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPin.Location = new System.Drawing.Point(12, 177);
            this.textBoxPin.Name = "textBoxPin";
            this.textBoxPin.Size = new System.Drawing.Size(199, 36);
            this.textBoxPin.TabIndex = 3;
            // 
            // labelPin
            // 
            this.labelPin.Font = new System.Drawing.Font("Rockwell Nova", 11.89565F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPin.Location = new System.Drawing.Point(10, 149);
            this.labelPin.Name = "labelPin";
            this.labelPin.Size = new System.Drawing.Size(202, 25);
            this.labelPin.TabIndex = 4;
            this.labelPin.Text = "Pin";
            this.labelPin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonLogin
            // 
            this.buttonLogin.Font = new System.Drawing.Font("Consolas", 13.77391F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogin.Location = new System.Drawing.Point(33, 240);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(148, 37);
            this.buttonLogin.TabIndex = 5;
            this.buttonLogin.Text = "Anmelden";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(223, 289);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.labelPin);
            this.Controls.Add(this.textBoxPin);
            this.Controls.Add(this.labelId);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.textBoxId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form";
            this.Text = "Bank";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.TextBox textBoxPin;
        private System.Windows.Forms.Label labelPin;
        private System.Windows.Forms.Button buttonLogin;
    }
}

