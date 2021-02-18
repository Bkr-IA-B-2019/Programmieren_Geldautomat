using Geldautomat.Forms;
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

namespace Geldautomat.Forms
{
    public partial class Anmeldung : BaseForm
    {
        public Anmeldung()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Event handler for the register button
        /// </summary>
        private void OnButtonRegisterClicked(object sender, EventArgs e)
        {
            Registrierung fca = new Registrierung();
            fca.ShowDialog();
        }

        /// <summary>
        /// Event handler for the login button
        /// </summary>
        private void OnButtonLoginClicked(object sender, EventArgs e)
        {
            // Tries to get the pin and id
            if (!int.TryParse(this.textBoxPin.Text,out int pin) || !int.TryParse(this.textBoxId.Text,out int id)){
                // Displays the error
                this.DisplayError("ID oder Pin sind nicht valid.");
                return;
            }

            // Tries to login the user
            string optError = Usermanager.Instance.Login(id, pin);

            // Checks if the login was successfull
            if (optError == null)
            {
                // Closes this window
                this.Close();

                // Opens the bank window
                OpenNextWindow(new Bank());
            }
            else
                // Displays the error
                this.DisplayError(optError);
        }
    }
}
