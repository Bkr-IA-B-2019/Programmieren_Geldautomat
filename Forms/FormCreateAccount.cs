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
    public partial class FormRegister : BaseForm
    {
        public FormRegister()
        {
            this.WindowTitle = "Registrieren";
            InitializeComponent();
        }

        /// <summary>
        /// Event handler for the register button click event
        /// </summary>
        private void OnButtonRegisterClicked(object sender, EventArgs e)
        {
            // Gets all informations
            string fn = this.textBoxFirstname.Text;
            string ln = this.textBoxLastname.Text;
            string pw1 = this.textBoxPasswordFirst.Text;
            string pw2 = this.textBoxPasswordSecond.Text;

            // Checks if any value is empty
            if(fn.Length==0 || ln.Length==0 || pw1.Length == 0 || pw2.Length == 0)
            {
                this.DisplayError("Bitte fülle alle Felder aus.");
                return;
            }

            // Tries to pass the pin
            if(!int.TryParse(pw1,out int pin))
            {
                this.DisplayError("Bitte nutzen nur eine Nummer als Pin.");
                return;
            }

            // Checks if the passwords match
            if (!pw1.Equals(pw2))
            {
                this.DisplayError("Die Pin-Felder stimmen nicht überein.");
                return;
            }

            // Tries to register the user and automatically log him in
            string optErr = Usermanager.Instance.RegisterAndLogIn(fn, ln, pin);

            // Checks if an error occured
            if(optErr != null)
            {
                this.DisplayError(optErr);
                return;
            }

            // Closes all windows
            for (int i = 0; i<Application.OpenForms.Count; i++)
                Application.OpenForms[i].Close();

            // Creates the bank form
            Form bank = new FormViewBank();

            // Opens the bankview
            this.OpenNextWindow(bank);
        }
    }
}
