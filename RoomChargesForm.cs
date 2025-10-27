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
    public partial class RoomChargesForm : Form
    {
        public RoomChargesForm()
        {
            InitializeComponent();
            string date = DateTime.Now.ToString("dd/MM/yyyy");
            string hour = DateTime.Now.ToShortTimeString().ToString();
            this.AcceptButton = calculateButton;
            this.CancelButton = exitButton;

            dateLabel.Text = date;
            timeLabel.Text = hour;
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            // variables
            decimal roomCharge = 0, additionalCharges = 0, subtotal = 0, total = 0, taxTotal = 0;
            decimal nightCharges = 0, roomService = 0, telephone = 0, misc = 0;
            int nights = 0;
            decimal TAX = 0.1105m;
            bool notEmpty = true;
            // checks if its a number, then if textbox is empty
            if (!clientIdMTextBox.MaskFull) {
                if (clientIdMTextBox.Text != "") { roomChargesErrorLabel.Text = "Client ID TextBox must be fully filled!"; }
                clientIdMTextBox.Focus();
                notEmpty = false; }
            else if (!int.TryParse(nightsTextBox.Text, out nights)) {
                if (nightsTextBox.Text != "") { roomChargesErrorLabel.Text = "Nights TextBox must contain a number!"; }
                else { roomChargesErrorLabel.Text = "Nights TextBox cannot be empty!"; }
                nightsTextBox.Focus();
                notEmpty = false; }
            else if (!decimal.TryParse(nightlyChargeTextBox.Text, out nightCharges)) {
                if (nightlyChargeTextBox.Text != "") { roomChargesErrorLabel.Text = "Nightly Charge TextBox must contain a number!"; }
                else { roomChargesErrorLabel.Text = "Nightly Charge TextBox cannot be empty!"; }
                nightlyChargeTextBox.Focus();
                notEmpty = false; }
            else if (!decimal.TryParse(roomServiceTextBox.Text, out roomService)) {
                if (roomServiceTextBox.Text != "") { roomChargesErrorLabel.Text = "Room Service TextBox must contain a number!"; }
                else { roomChargesErrorLabel.Text = "Room Service TextBox cannot be empty!"; }
                roomServiceTextBox.Focus();
                notEmpty = false; }
            else if (!decimal.TryParse(telephoneTextBox.Text, out telephone)) {
                if (telephoneTextBox.Text != "") { roomChargesErrorLabel.Text = "Telephone TextBox must contain a number!"; }
                else { roomChargesErrorLabel.Text = "Telephone TextBox cannot be empty!"; }
                telephoneTextBox.Focus();
                notEmpty = false; }
            else if (!decimal.TryParse(miscTextBox.Text, out misc)) {
                if (miscTextBox.Text != "") { roomChargesErrorLabel.Text = "Misc TextBox must contain a number!"; }
                else { roomChargesErrorLabel.Text = "Misc TextBox cannot be empty!"; }
                miscTextBox.Focus();
                notEmpty = false; }
            else { roomChargesErrorLabel.Text = ""; }
            // if negative
            string temp = " TextBox must be a positive number!";
            if (nights < 0) {
                roomChargesErrorLabel.Text = "Nights" + temp;
                nightsTextBox.Focus();
                notEmpty = false; }
            else if (nightCharges < 0) {
                roomChargesErrorLabel.Text = "Nightly Charges" + temp;
                nightlyChargeTextBox.Focus();
                notEmpty = false; }
            else if (roomService < 0) {
                roomChargesErrorLabel.Text = "Room Service" + temp;
                roomServiceTextBox.Focus();
                notEmpty = false; }
            else if (telephone < 0) {
                roomChargesErrorLabel.Text = "Telephone" + temp;
                telephoneTextBox.Focus();
                notEmpty = false; }
            else if (misc < 0) {
                roomChargesErrorLabel.Text = "Misc" + temp;
                miscTextBox.Focus();
                notEmpty = false; }

            if (notEmpty) {
                // math
                roomCharge = nights * nightCharges;
                additionalCharges = roomService + telephone + misc;

                subtotal = roomCharge + additionalCharges;
                taxTotal = subtotal * TAX;

                total = taxTotal + subtotal;
                // output
                Output(); }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            Clear();
        }
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Output()
        {
            roomChargesLabel.Text = roomCharge.ToString("C");
            additionalChargesLabel.Text = additionalCharges.ToString("C");
            subtotalLabel.Text = subtotal.ToString("C");
            totalLabel.Text = total.ToString("C");
            taxLabel.Text = taxTotal.ToString("C");
            totalLabel.Text = total.ToString("C");
        }

        private void Clear()
        {
            // labels
            roomChargesLabel.Text = "";
            additionalChargesLabel.Text = "";
            subtotalLabel.Text = "";
            totalLabel.Text = "";
            taxLabel.Text = "";
            totalLabel.Text = "";
            // text boxes
            clientIdMTextBox.Text = "";
            nightsTextBox.Text = "";
            nightlyChargeTextBox.Text = "";
            roomServiceTextBox.Text = "";
            telephoneTextBox.Text = "";
            miscTextBox.Text = "";
            // focus
            clientIdMTextBox.Focus();
            // errorbar
            roomChargesErrorLabel.Text = "";
        }
    }
}
