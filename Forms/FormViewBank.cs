using Geldautomat.database.objects;
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
    public partial class FormViewBank : BaseForm
    {
        public FormViewBank()
        {
            this.WindowTitle = "Bank";
            InitializeComponent();
            this.panelMenu.SendToBack();

            // Inserts the user values
            this.RefreshUserElements();
        }

        /// <summary>
        /// Updates all fields and inserts the logged in user specific values
        /// </summary>
        public void RefreshUserElements()
        {
            // Gets the user
            Account acc = Usermanager.Instance.LoggedInAs;

            // Checks if the user is logged in
            if (acc == null)
                return;

            // Set all informations
            this.labelId.Text = acc.Id.ToString();
            this.labelWelcome.Text = $"{acc.Firstname} {acc.Lastname}";
            this.labelMoney.Text = acc.Money.ToString();
        }

        /// <summary>
        /// Event handler for the logout button
        /// </summary>
        private void OnButtonLogoutClicked(object sender, EventArgs e)
        {
            // Removes the logged in account
            Usermanager.Instance.Logout();

            // Redirects back to the login screen
            this.OpenNextWindow(new FormLogin());
        }

        /// <summary>
        /// Event handler for the transactions button
        /// </summary>
        private void OnButtonTransactionsClicked(object sender, EventArgs e)
        {
            // Opens the transactions screen
            try
            {
                // Displays the dialog with all transactions
                new FormTransactions().ShowDialog();
            }
            catch (Exception ex)
            {
                // Displays the error
                this.DisplayError(ex.Message);
            }
        }

        /// <summary>
        /// Event handler for the buy button
        /// </summary>
        private void OnButtonBuyClicked(object sender, EventArgs e)
        {
            // Opens the buy form
            new FormBuy(this).ShowDialog();
        }

        /// <summary>
        /// Event handler for the load-money button
        /// </summary>
        private void OnButtonLoadMoneyClicked(object sender, EventArgs e)
        {
            // Opens the form
            new FormLoadMoney(this).ShowDialog();
        }
    }
}
