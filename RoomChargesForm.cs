using System;
using System.Windows.Forms;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.CodeDom;
// GUNAVAN D HUAMANI MELGAR | 802-22-2972
namespace HotelApp_Asig5
{

    public partial class RoomChargesForm : Form
    {
        // variables
        string clientId = "", date = DateTime.Now.ToString("dd/MM/yyyy"), hour = DateTime.Now.ToShortTimeString().ToString();
        decimal roomCharge = 0, additionalCharges = 0, subtotal = 0, total = 0, taxTotal = 0,
                nightCharges = 0, roomService = 0, telephone = 0, misc = 0;
        int nights = 0;
        const decimal TAX = 0.1105m;
        bool notEmpty = true;
        DialogResult result;
        public RoomChargesForm()
        {
            InitializeComponent();
            
            dateLabel.Text = date;
            timeLabel.Text = hour;
            // accept and cancel buttons
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
            result = MessageBox.Show("Do you want to save this transaction to file?", "Save to File", MessageBoxButtons.YesNo);
            // yes/no message box
            if (result == DialogResult.Yes) {
                string line = date + "," + hour + "," + clientId + "," + roomCharge + "," + additionalCharges + "," + subtotal + "," + taxTotal + "," + total;
                try {
                    StreamWriter writeFile;
                    // checks if folder exists
                    if (Directory.Exists(@"C:\record")) {
                        // if folder exists, checks that .txt file exists and creates it if not
                        if (!(File.Exists(@"C:\record\RoomChargesFile.txt"))) {
                            writeFile = File.CreateText(@"C:\record\RoomChargesFile.txt");
                            writeFile.WriteLine("DATE, HOUR, CLIENTID, ROOMCHARGES, ADDITIONALCHARGES, SUB TOTAL, TAX TOTAL, TOTAL ROOM CHARGES");
                            writeFile.WriteLine(line);
                            MessageBox.Show("File Created in: C:\\record\\RoomChargesFile.txt");
                            writeFile.Close(); }
                        // if .txt file exists, appends to it
                        else {
                            // checks if transaction is already in file, false means its a new one
                            if (!FindIt(line)) {
                                writeFile = File.AppendText(@"C:\record\RoomChargesFile.txt");
                                MessageBox.Show("Transaction SAVED in File: C:\\record\\RoomChargesFile.txt");
                                writeFile.WriteLine(line);
                                writeFile.Close(); }
                            // if transaction found in file
                            else {
                                MessageBox.Show("This transaction has been found in the file.\nDuplicate transaction will not be saved", "Transaction in File Already!");
                                return; } } }
                    // folder did not exist
                    else { MessageBox.Show("Directory C:\\record does not exist. File not saved."); } }
                catch (Exception ex) { MessageBox.Show(ex.Message); } }
        }
        // returns true if line was found in file
        private bool FindIt(string line)
        {
            StreamReader readFile;
            string cutUpLine = line.Substring(0, 27); // cuts string to date, hour, id length
            try {
                readFile = File.OpenText(@"C:\record\RoomChargesFile.txt");
                string lineInFile;
                while (!readFile.EndOfStream) {
                    lineInFile = readFile.ReadLine();
                    lineInFile = lineInFile.Substring(0, 27);
                    if (lineInFile == cutUpLine) { return true; } }
                readFile.Close();
                return false; }
            catch (Exception ex) { MessageBox.Show(ex.Message); return true; }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            Clear();
        }
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // opens to excel
        private void fileOpenMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = @"C:\record";
            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK) {
                Excel.Application excelApp = new Excel.Application();
                // Open the text file with parsing options (comma-delimited example)
                excelApp.Workbooks.OpenText(Filename: openFileDialog.FileName,
                DataType: Excel.XlTextParsingType.xlDelimited,
                Comma: true);
                // Make Excel visible
                excelApp.Visible = true;
                excelApp.ActiveWindow.Caption = "Room Charges File"; }
        }
        // saves valid transaction
        private void fileSaveMenuItem_Click(object sender, EventArgs e)
        {
            bool valid = true;

            if (!clientIdMTextBox.MaskFull || roomCharge == 0 || total == 0) {
                valid = false;
                MessageBox.Show("No valid data in transaction to save.\nPlease calculate a transaction first.", "Error");
            }

            if (valid) { SaveTransaction(); }
        }
    }
}
