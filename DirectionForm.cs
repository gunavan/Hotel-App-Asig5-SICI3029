using System;
using System.Windows.Forms;
// GUNAVAN D HUAMANI MELGAR | 802-22-2972
namespace HotelApp_Asig5
{
    public partial class DirectionForm : Form
    {
        bool enabled = false;
        public DirectionForm()
        {
            InitializeComponent();
            this.AcceptButton = directionsButton;
            this.CancelButton = exitButton;
        }

        private void directionsButton_Click(object sender, EventArgs e)
        {

            if (enabled) {
                enabled = false;
                directionsLabel.Visible = false; }
            else {
                enabled = true;
                directionsLabel.Visible = true;
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
