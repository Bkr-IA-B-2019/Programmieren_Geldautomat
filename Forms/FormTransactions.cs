using Geldautomat.database.exceptions;
using Geldautomat.database.objects;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace Geldautomat.Forms
{
    public partial class FormTransactions : BaseForm
    {
        // Default font for all transactions
        private Font TransactionFont = new Font("Bahnschrift", 12);

        /// <summary>
        /// Tries to grab all transactions from the logged in user and display them
        /// </summary>
        /// <exception cref="Exception">Throws an exception if anything went wrong with the successfull display of the transactions.</exception>
        /// <param name="parent">The parent from of the current transactions</param>
        public FormTransactions()
        {
            this.WindowTitle = "Transaktionen";
            InitializeComponent();

            // Gets all transactions from the user
            var trans = this.LoadTransactions();

            // Checks if no transactions have been found
            if (trans.Length <= 0)
            {
                this.AddTransaction("Keine Transaktionen gefunden.", Color.White);
            }
            else
            {
                // Appends all transactions
                foreach (Transaction tr in trans)
                    this.AddTransaction(
                        $"{(tr.Subtracted ? "-" : "+")} {tr.TranslatedMoney}€ am {tr.DateTime.ToString(@"dd.MM.yyyy \u\m HH:mm:ss")}",
                        tr.Subtracted ? Color.Red : Color.LawnGreen
                    );
            }

            // Calculates the excepted balance of the account
            decimal fin = trans.Length <= 0 ? 0 : trans.Select(x => x.TranslatedMoney * (x.Subtracted ? -1 : 1)).Aggregate((a, b) => a + b);

            // If the transaction rate has not been ricked
            bool valid = fin == Usermanager.Instance.LoggedInAs.Money;

            // If the transactions are not valid, show the window for that
            this.ShowDataInconsistencyInGui = !valid;

            if (!valid)
                // Updated the excepted account balance
                this.labelValue.Text = fin.ToString()+"€";

            // Adds the final transaction row to the queue
            this.AddTransaction("= " + fin + "€", Color.Orange);
        }

        /// <summary>
        /// En or disables the apperance of the extra gui informations
        /// that the transaction chain might have been ricked.
        /// </summary>
        public bool ShowDataInconsistencyInGui
        {
            set
            {
                // Sets the width of the actual transactions
                panelTransactions.Width = (int)(this.Width * (value ? .5f : 1f));
                panelError.Visible = value;

                this.Width = (int)(this.Width * (value?1:0.5));
            }
        }

        /// <summary>
        /// Gets all transactions from the currently logged in user.
        /// </summary>
        /// <exception cref="Exception">Throws an exception if anything went wrong with the database or if the user is not logged in</exception>
        /// <returns>An array with all those transactions</returns>
        public Transaction[] LoadTransactions()
        {
            // Gets the user
            Account acc = Usermanager.Instance.LoggedInAs;

            // Checks if the user is logged in
            if (acc == null)
                throw new Exception("Nutzer ist nicht angemeltet.");

            // Gets all transactions from the user
            return Usermanager.Instance.Database.GetAccountTransactions(acc);
        }

        /// <summary>
        /// Adds an transaction to the list
        /// </summary>
        /// <param name="transaction">The transaction string to display</param>
        private void AddTransaction(string transaction, Color color)
        {
            Label l = new Label()
            {
                Text = transaction,
                Dock=DockStyle.Top,
                Font=TransactionFont,
                ForeColor=color
            };
            this.panelTransactions.Controls.Add(l);
            l.BringToFront();
        }
    }
}
