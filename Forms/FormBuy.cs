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
    public partial class FormBuy : BaseForm
    {
        /// <summary>
        /// Saves the price that the product would cost
        /// </summary>
        private float price;

        private readonly FormViewBank parentForm;

        /// <param name="parent">The parent form of this element</param>
        public FormBuy(FormViewBank parent)
        {
            this.WindowTitle = "Kaufen";

            this.parentForm = parent;
            InitializeComponent();

            // Gets the user
            Account acc = Usermanager.Instance.LoggedInAs;

            // Checks that the user is logged in
            if (acc == null)
                return;

            // Inserts all values
            this.labelBuy.Text = Usermanager.Instance.GetRandomProduct();
            this.labelCosts.Text = (this.price = Usermanager.Instance.GetRandomPrice()).ToString()+"€";
            this.labelMoney.Text = acc.Money.ToString()+"€";
            this.labelMoneyAfter.Text = (acc.Money - (decimal)this.price).ToString()+"€";


            // If the product is afordable
            bool afordable = (acc.Money - (decimal)this.price) > 0;

            this.labelMoneyAfter.ForeColor = afordable ? Color.White : Color.Red;
            this.buttonAccept.Enabled = afordable;
        }

        /// <summary>
        /// Event handler for the cancle button
        /// </summary>
        private void OnButtonCancleClicked(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Event handler for the accept button
        /// </summary>
        private void OnButtonAcceptClicked(object sender, EventArgs e)
        {
            // Creates the transaction
            string optErr = Usermanager.Instance.CreateTransaction((decimal)this.price,true);

            // Closes this window
            this.Close();

            // Checks if an error occured
            if(optErr != null)
                // Displays the error to the user
                this.DisplayError(optErr, this.parentForm);
            else
                // Updates the user-elements
                this.parentForm.RefreshUserElements();
        }
    }
}
