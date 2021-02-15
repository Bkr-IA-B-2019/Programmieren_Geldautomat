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
    public partial class FormTransactions : BaseForm
    {
        // Default font for all transactions
        private Font transactionFont = new Font("Bahnschrift", 12);

        public FormTransactions()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Adds an transaction to the list
        /// </summary>
        /// <param name="transaction">The transaction string to display</param>
        public void AddTransaction(string transaction)
        {
            Label l = new Label()
            {
                Text = transaction,
                Dock=DockStyle.Top,
                Font=transactionFont,
                ForeColor=Color.White
            };
            this.panelTransactions.Controls.Add(l);
            l.BringToFront();
        }
    }
}
