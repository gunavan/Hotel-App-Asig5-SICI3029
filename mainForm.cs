using System;

using System.Windows.Forms;
// GUNAVAN D HUAMANI MELGAR | 802-22-2972
namespace HotelApp_Asig5
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.CancelButton = exitButton;
        }

        private void directionsFormButton_Click(object sender, EventArgs e)
        {
            DirectionForm directionForm = new DirectionForm();
            directionForm.ShowDialog();
        }

        private void roomChargesFormButton_Click(object sender, EventArgs e)
        {
            RoomChargesForm roomChargesForm = new RoomChargesForm();
            roomChargesForm.ShowDialog();
        }
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
