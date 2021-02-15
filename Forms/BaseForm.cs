using System;
using System.Threading;
using System.Windows.Forms;

namespace Geldautomat.Forms
{
    public partial class BaseForm : Form
    {
        // If the mouse got pressed on the toolbar to drag
        private bool windowDragged = false;

        // At wich coordinates the mouse got clicked
        private int dragX, dragY;

        public BaseForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Eventhanlder for when the mouse gets pressed on the toolbar
        /// </summary>
        private void Dragbar_OnMouseDown(object sender, MouseEventArgs e)
        {
            this.windowDragged = true;
            this.dragX = e.X + 9 + this.dragBar.Location.X;
            this.dragY = e.Y + 9 + this.dragBar.Location.Y;
        }

        /// <summary>
        /// Eventhandler for when the mouse gets released (For the dragbar)
        /// </summary>
        private void Dragbar_OnMouseUp(object sender, MouseEventArgs e)
        {
            this.windowDragged = false;
        }

        /// <summary>
        /// Event handler for when the close button get's clicked
        /// </summary>
        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Event handler for when the mouse gets moved over the dragbar
        /// </summary>
        private void Dragbar_OnMouseMove(object sender, MouseEventArgs e)
        {
            // Checks if the mouse is pressed
            if (this.windowDragged)
                // Updates the position
                this.SetDesktopLocation(MousePosition.X - this.dragX, MousePosition.Y - this.dragY);
        }

        /// <summary>
        /// Displays the given error to the user
        /// </summary>
        protected void DisplayError(string error)
        {
            // Creates an error form
            new FormError(error).ShowDialog();
        }

        /// <summary>
        /// Opens the given window and closes this one
        /// </summary>
        protected void OpenNextWindow(Form form)
        {
            // Opens the window
            new Thread(o =>Application.Run(form)).Start();

            // Closes this one
            this.Close();
        }
    }
}
