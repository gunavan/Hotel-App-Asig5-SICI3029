using System;
using System.Windows.Forms;
using System.IO;
using System.CodeDom;
// GUNAVAN D HUAMANI MELGAR | 802-22-2972
namespace HotelApp_Asig5
{

    public partial class RoomChargesForm : Form
    {
        // variables
        string clientId = "", date = DateTime.Now.ToString("dd/MM/yyyy"), hour = DateTime.Now.ToShortTimeString().ToString(),
               message = "Do you want to save this transaction to file?", caption = "Save to File";
        decimal roomCharge = 0, additionalCharges = 0, subtotal = 0, total = 0, taxTotal = 0,
                nightCharges = 0, roomService = 0, telephone = 0, misc = 0;
        int nights = 0;
        const decimal TAX = 0.1105m;
        bool notEmpty = true;
        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
        DialogResult result;
        public RoomChargesForm()
        {
            InitializeComponent();
            
            dateLabel.Text = date;
            timeLabel.Text = hour;

            this.AcceptButton = calculateButton;
            this.CancelButton = exitButton;
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            notEmpty = true;
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
                clientId = clientIdMTextBox.Text;
                // math
                roomCharge = nights * nightCharges;
                additionalCharges = roomService + telephone + misc;

                subtotal = roomCharge + additionalCharges;
                taxTotal = subtotal * TAX;

                total = taxTotal + subtotal;
                // output
                Output();

                SaveTransaction(); }
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
        // saves to file
        private void SaveTransaction()
        {
            // vars
            result = MessageBox.Show(message, caption, buttons);
            if (result == DialogResult.Yes) {
                string line = date + "," + hour + "," + clientId + "," + roomCharge + "," + additionalCharges + "," + subtotal + "," + taxTotal + "," + total;
                try {
                    StreamWriter writeFile;
                    if (Directory.Exists(@"C:\record")) {
                        if (!(File.Exists(@"C:\record\RoomChargeFile.txt"))) {
                            writeFile = File.CreateText(@"C:\record\RoomChargeFile.txt");
                            writeFile.WriteLine("DATE, HOUR, CLIENTID, ROOMCHARGES, ADDITIONALCHARGES, SUB TOTAL, TAX TOTAL, TOTAL ROOM CHARGES");
                            writeFile.WriteLine(line);
                            MessageBox.Show("File Created in: C:\\record\\RoomChargeFile.txt");
                            writeFile.Close(); }
                        else {
                            if (!FindIt(line)) {
                                writeFile = File.AppendText(@"C:\record\RoomChargeFile.txt");
                                MessageBox.Show("Transaction SAVED in File: C:\\record\\RoomChargesFile.txt");
                                writeFile.WriteLine(line);
                                writeFile.Close(); }
                            else {
                                MessageBox.Show("The transaction has been found in the file.\nTransaction will not be made or saved");
                                return; } } }
                    else { MessageBox.Show("Directory C:\\record does not exist. File not saved."); } }
                catch (Exception ex) { MessageBox.Show(ex.Message); } }
            else { Clear(); }
        }
        // returns true if line was found in file
        private bool FindIt(string line)
        {
            StreamReader readFile;
            string cutUpLine = line.Substring(0, 27); // date, hour, id length
            try {
                readFile = File.OpenText(@"C:\record\RoomChargeFile.txt");
                string lineInFile;
                while (!readFile.EndOfStream) {
                    lineInFile = readFile.ReadLine();
                    lineInFile = lineInFile.Substring(0, 27);
                    if (lineInFile == cutUpLine) { return true; } }
                readFile.Close();
                return false; }
            catch (Exception ex) { MessageBox.Show(ex.Message); return true; }
        }
    }
}
