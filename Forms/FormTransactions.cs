using Geldautomat.database.exceptions;
using Geldautomat.database.objects;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Geldautomat.Forms
{
    public partial class Transaktionen : BaseForm
    {
        // Default font for all transactions
        private Font TransactionFont = new Font("Bahnschrift", 12);

        /// <summary>
        /// Tries to grab all transactions from the logged in user and display them
        /// </summary>
        /// <exception cref="Exception">Throws an exception if anything went wrong with the successfull display of the transactions.</exception>
        /// <param name="parent">The parent from of the current transactions</param>
        public Transaktionen()
        {
            InitializeComponent();

            // Gets the user
            Account acc = Usermanager.Instance.LoggedInAs;

            // Checks if the user is logged in
            if (acc == null)
                throw new Exception("Nutzer ist nicht angemeltet.");

            try
            {
                // Gets all transactions from the user
                Transaction[] transactions = Usermanager.Instance.Database.GetAccountTransactions(acc);

                // Checks if no transactions have been found
                if(transactions.Length <= 0)
                {
                    this.AddTransaction("Keine Transaktionen gefunden.",Color.White);
                    return;
                }

                // Appends all transactions
                foreach (Transaction tr in transactions)
                    this.AddTransaction(
                        $"{(tr.Subtracted ? "-" : "+")} {tr.TranslatedMoney}€ am {tr.DateTime.ToString(@"dd.MM.yyyy \u\m HH:mm:ss")}",
                        tr.Subtracted ? Color.Red : Color.LawnGreen
                    );
            }
            catch (DatabaseException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Adds an transaction to the list
        /// </summary>
        /// <param name="transaction">The transaction string to display</param>
        public void AddTransaction(string transaction, Color color)
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
