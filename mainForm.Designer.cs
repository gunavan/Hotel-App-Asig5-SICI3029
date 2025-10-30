namespace HotelApp_Asig5
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.exitButton = new System.Windows.Forms.Button();
            this.roomChargesFormButton = new System.Windows.Forms.Button();
            this.directionsFormButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.SystemColors.MenuBar;
            this.exitButton.Font = new System.Drawing.Font("MS Gothic", 18F, System.Drawing.FontStyle.Bold);
            this.exitButton.Location = new System.Drawing.Point(19, 361);
            this.exitButton.Margin = new System.Windows.Forms.Padding(4);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(509, 78);
            this.exitButton.TabIndex = 4;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // roomChargesFormButton
            // 
            this.roomChargesFormButton.BackColor = System.Drawing.SystemColors.MenuBar;
            this.roomChargesFormButton.Font = new System.Drawing.Font("MS Gothic", 18F, System.Drawing.FontStyle.Bold);
            this.roomChargesFormButton.Location = new System.Drawing.Point(19, 262);
            this.roomChargesFormButton.Margin = new System.Windows.Forms.Padding(4);
            this.roomChargesFormButton.Name = "roomChargesFormButton";
            this.roomChargesFormButton.Size = new System.Drawing.Size(509, 78);
            this.roomChargesFormButton.TabIndex = 5;
            this.roomChargesFormButton.Text = "Room Charges Form";
            this.roomChargesFormButton.UseVisualStyleBackColor = false;
            this.roomChargesFormButton.Click += new System.EventHandler(this.roomChargesFormButton_Click);
            // 
            // directionsFormButton
            // 
            this.directionsFormButton.BackColor = System.Drawing.SystemColors.MenuBar;
            this.directionsFormButton.Font = new System.Drawing.Font("MS Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.directionsFormButton.Location = new System.Drawing.Point(19, 165);
            this.directionsFormButton.Margin = new System.Windows.Forms.Padding(4);
            this.directionsFormButton.Name = "directionsFormButton";
            this.directionsFormButton.Size = new System.Drawing.Size(509, 78);
            this.directionsFormButton.TabIndex = 6;
            this.directionsFormButton.Text = "Directions Form";
            this.directionsFormButton.UseVisualStyleBackColor = false;
            this.directionsFormButton.Click += new System.EventHandler(this.directionsFormButton_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("MS Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(509, 123);
            this.label1.TabIndex = 3;
            this.label1.Text = "Mayaguez\r\nResort and Casino\r\nMain Form";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(541, 451);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.roomChargesFormButton);
            this.Controls.Add(this.directionsFormButton);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mayaguez Resort and Casino Application";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button roomChargesFormButton;
        private System.Windows.Forms.Button directionsFormButton;
        private System.Windows.Forms.Label label1;
    }
}

