﻿using System;
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
    public partial class FormError : BaseForm
    {
        public FormError(string error)
        {
            this.WindowTitle = "Fehler";
            InitializeComponent();

            this.labelError.Text = error;
        }

        private void OnButtonCloseClicked(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
