namespace DieGuessGame
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            richTextBox1 = new RichTextBox();
            lblEnterGuess = new Label();
            cmdReset = new Button();
            pbImage = new PictureBox();
            lblNtimesPlayed = new Label();
            lblNtimesWon = new Label();
            lblNtimesLost = new Label();
            groupBox1 = new GroupBox();
            cmdRoll = new Button();
            txtEnterGuess = new TextBox();
            lblErrorMessage = new Label();
            ((System.ComponentModel.ISupportInitialize)pbImage).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = Color.DarkSeaGreen;
            richTextBox1.Location = new Point(76, 290);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(543, 148);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            // 
            // lblEnterGuess
            // 
            lblEnterGuess.AutoSize = true;
            lblEnterGuess.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEnterGuess.Location = new Point(76, 42);
            lblEnterGuess.Name = "lblEnterGuess";
            lblEnterGuess.Size = new Size(181, 23);
            lblEnterGuess.TabIndex = 1;
            lblEnterGuess.Text = "Enter your guess (1-6):";
            // 
            // cmdReset
            // 
            cmdReset.Location = new Point(204, 105);
            cmdReset.Name = "cmdReset";
            cmdReset.Size = new Size(94, 29);
            cmdReset.TabIndex = 3;
            cmdReset.Text = "Reset";
            cmdReset.UseVisualStyleBackColor = true;
            cmdReset.Click += cmdReset_Click;
            // 
            // pbImage
            // 
            pbImage.Location = new Point(371, 64);
            pbImage.Name = "pbImage";
            pbImage.Size = new Size(200, 200);
            pbImage.TabIndex = 4;
            pbImage.TabStop = false;
            // 
            // lblNtimesPlayed
            // 
            lblNtimesPlayed.AutoSize = true;
            lblNtimesPlayed.Location = new Point(6, 27);
            lblNtimesPlayed.Name = "lblNtimesPlayed";
            lblNtimesPlayed.Size = new Size(175, 20);
            lblNtimesPlayed.TabIndex = 6;
            lblNtimesPlayed.Text = "Number of Times Played:";
            // 
            // lblNtimesWon
            // 
            lblNtimesWon.AutoSize = true;
            lblNtimesWon.Location = new Point(6, 51);
            lblNtimesWon.Name = "lblNtimesWon";
            lblNtimesWon.Size = new Size(161, 20);
            lblNtimesWon.TabIndex = 7;
            lblNtimesWon.Text = "Number of Times Won:";
            // 
            // lblNtimesLost
            // 
            lblNtimesLost.AutoSize = true;
            lblNtimesLost.Location = new Point(6, 74);
            lblNtimesLost.Name = "lblNtimesLost";
            lblNtimesLost.Size = new Size(158, 20);
            lblNtimesLost.TabIndex = 8;
            lblNtimesLost.Text = "Number of Times Lost:";
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.DarkSeaGreen;
            groupBox1.Controls.Add(lblNtimesPlayed);
            groupBox1.Controls.Add(lblNtimesLost);
            groupBox1.Controls.Add(lblNtimesWon);
            groupBox1.Location = new Point(76, 155);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(237, 109);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            groupBox1.Text = "Game Info";
            // 
            // cmdRoll
            // 
            cmdRoll.Location = new Point(82, 106);
            cmdRoll.Name = "cmdRoll";
            cmdRoll.Size = new Size(94, 29);
            cmdRoll.TabIndex = 10;
            cmdRoll.Text = "Roll";
            cmdRoll.UseVisualStyleBackColor = true;
            cmdRoll.Click += cmdRoll_Click;
            // 
            // txtEnterGuess
            // 
            txtEnterGuess.Location = new Point(263, 38);
            txtEnterGuess.Name = "txtEnterGuess";
            txtEnterGuess.Size = new Size(35, 27);
            txtEnterGuess.TabIndex = 11;
            txtEnterGuess.TextAlign = HorizontalAlignment.Center;
            // 
            // lblErrorMessage
            // 
            lblErrorMessage.AutoSize = true;
            lblErrorMessage.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblErrorMessage.ForeColor = Color.Red;
            lblErrorMessage.Location = new Point(33, 68);
            lblErrorMessage.Name = "lblErrorMessage";
            lblErrorMessage.Size = new Size(332, 23);
            lblErrorMessage.TabIndex = 12;
            lblErrorMessage.Text = "Please enter a number between 1 and 6.";
            lblErrorMessage.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.ForestGreen;
            ClientSize = new Size(648, 467);
            Controls.Add(lblErrorMessage);
            Controls.Add(txtEnterGuess);
            Controls.Add(cmdRoll);
            Controls.Add(groupBox1);
            Controls.Add(pbImage);
            Controls.Add(cmdReset);
            Controls.Add(lblEnterGuess);
            Controls.Add(richTextBox1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pbImage).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox richTextBox1;
        private Label lblEnterGuess;
        private Button cmdReset;
        private PictureBox pbImage;
        private Label lblNtimesPlayed;
        private Label lblNtimesWon;
        private Label lblNtimesLost;
        private GroupBox groupBox1;
        private Button cmdRoll;
        private TextBox txtEnterGuess;
        private Label lblErrorMessage;
    }
}
