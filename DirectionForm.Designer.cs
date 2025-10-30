namespace HotelApp_Asig5
{
    partial class DirectionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DirectionForm));
            this.exitButton = new System.Windows.Forms.Button();
            this.directionsButton = new System.Windows.Forms.Button();
            this.directionsLabel = new System.Windows.Forms.Label();
            this.nameLabel1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.SystemColors.MenuBar;
            this.exitButton.Font = new System.Drawing.Font("MS Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.Location = new System.Drawing.Point(669, 656);
            this.exitButton.Margin = new System.Windows.Forms.Padding(4);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(293, 81);
            this.exitButton.TabIndex = 10;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // directionsButton
            // 
            this.directionsButton.BackColor = System.Drawing.SystemColors.MenuBar;
            this.directionsButton.Font = new System.Drawing.Font("MS Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.directionsButton.Location = new System.Drawing.Point(62, 656);
            this.directionsButton.Margin = new System.Windows.Forms.Padding(4);
            this.directionsButton.Name = "directionsButton";
            this.directionsButton.Size = new System.Drawing.Size(293, 81);
            this.directionsButton.TabIndex = 9;
            this.directionsButton.Text = "Directions";
            this.directionsButton.UseVisualStyleBackColor = false;
            this.directionsButton.Click += new System.EventHandler(this.directionsButton_Click);
            // 
            // directionsLabel
            // 
            this.directionsLabel.Font = new System.Drawing.Font("MS Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.directionsLabel.Location = new System.Drawing.Point(62, 544);
            this.directionsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.directionsLabel.Name = "directionsLabel";
            this.directionsLabel.Size = new System.Drawing.Size(900, 86);
            this.directionsLabel.TabIndex = 7;
            this.directionsLabel.Text = resources.GetString("directionsLabel.Text");
            this.directionsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.directionsLabel.Visible = false;
            // 
            // nameLabel1
            // 
            this.nameLabel1.Font = new System.Drawing.Font("MS Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel1.Location = new System.Drawing.Point(37, 22);
            this.nameLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nameLabel1.Name = "nameLabel1";
            this.nameLabel1.Size = new System.Drawing.Size(925, 123);
            this.nameLabel1.TabIndex = 8;
            this.nameLabel1.Text = "Directions to the Mayaguez Resort  and Casino";
            this.nameLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DirectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(988, 758);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.directionsButton);
            this.Controls.Add(this.directionsLabel);
            this.Controls.Add(this.nameLabel1);
            this.Name = "DirectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Hotel App Directions";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button directionsButton;
        private System.Windows.Forms.Label directionsLabel;
        private System.Windows.Forms.Label nameLabel1;
    }
}