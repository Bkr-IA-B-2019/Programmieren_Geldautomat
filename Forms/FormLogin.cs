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
        // If the mouse got pressed on the toolbar to drag
        private bool windowDragged = false;

        // At wich coordinates the mouse got clicked
        private int dragX, dragY;

        public FormLogin()
        {
            InitializeComponent();

            this.TopMost = true;
        }

        /// <summary>
        /// Eventhanlder for when the mouse gets pressed on the toolbar
        /// </summary>
        private void Toolbar_OnMouseDown(object sender, MouseEventArgs e)
        {
            this.windowDragged = true;
            this.dragX = e.X+9;
            this.dragY = e.Y+9;
        }

        private void Toolbar_OnMouseUp(object sender, MouseEventArgs e)
        {
            this.windowDragged = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Toolbar_OnMouseMove(object sender, MouseEventArgs e)
        {
            // Checks if the mouse is pressed
            if(this.windowDragged)
                // Updates the position
                this.SetDesktopLocation(MousePosition.X - this.dragX,MousePosition.Y - this.dragY);
        }
    }
}
