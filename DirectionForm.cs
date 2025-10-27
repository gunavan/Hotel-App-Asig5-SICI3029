using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelApp_Asig5
{
    public partial class DirectionForm : Form
    {
        bool enabled = false;
        public DirectionForm()
        {
            InitializeComponent();
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
