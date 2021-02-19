using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Geldautomat.Forms
{
    public partial class FormLoadMoney : BaseForm
    {
        /// <summary>
        /// Holds the parent form
        /// </summary>
        private readonly FormViewBank parentForm;

        public FormLoadMoney(FormViewBank parent)
        {
            this.WindowTitle = "Geld Aufladen";
            this.parentForm = parent;
            InitializeComponent();
        }

        /// <summary>
        /// Event handler for the accept button
        /// </summary>
        private void OnButtonAcceptClicked(object sender, EventArgs e)
        {
            // Gets the money
            if(!decimal.TryParse(this.textBoxMoney.Text,out decimal money))
            {
                this.DisplayError("Bitte gebe die Anzahl an € an, welche du gegeschrieben haben möchtest.");
                return;
            }

            // Creates the transaction
            string optErr = Usermanager.Instance.CreateTransaction(money, false);

            // Closes this window
            this.Close();

            // Checks if an error occured
            if (optErr != null)
                // Displays the error to the user
                this.DisplayError(optErr, this.parentForm);
            else
                // Updates the user-elements
                this.parentForm.RefreshUserElements();
        }
    }
}
