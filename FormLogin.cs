using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Geldautomat
{
    public partial class FormLogin : System.Windows.Forms.Form
    {
        public FormLogin()
        {
            InitializeComponent();

            this.TopMost = true;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            this.Close();

            new Thread((o) =>
            {
                Application.Run(new FormCreateAccount());
            }).Start();
        }
    }
}
