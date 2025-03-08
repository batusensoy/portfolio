namespace Scores
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
            groupBox1 = new GroupBox();
            lblErrorMsg2 = new Label();
            lblErrorMsg1 = new Label();
            txtNassignments = new TextBox();
            txtNstudents = new TextBox();
            lblNassignments = new Label();
            lblNstudents = new Label();
            cmdSubmitCounts = new Button();
            cmdResetScores = new Button();
            groupBoxNavigate = new GroupBox();
            cmdLastStudent = new Button();
            cmdNextStudent = new Button();
            cmdPrevStudent = new Button();
            cmdFirstStudent = new Button();
            groupBoxStudentInfo = new GroupBox();
            lblErrorMsg3 = new Label();
            cmdSaveName = new Button();
            txtStudentInfo = new TextBox();
            lblStudentInfo = new Label();
            groupBoxAssignmentInfo = new GroupBox();
            lblErrorMsg5 = new Label();
            lblErrorMsg4 = new Label();
            cmdSaveScore = new Button();
            lblEnterAssignmentScore = new Label();
            txtAssignmentScore = new TextBox();
            txtAssignmentNumber = new TextBox();
            lblEnterAssignmentN = new Label();
            cmdDisplayScores = new Button();
            richTextBox1 = new RichTextBox();
            groupBox1.SuspendLayout();
            groupBoxNavigate.SuspendLayout();
            groupBoxStudentInfo.SuspendLayout();
            groupBoxAssignmentInfo.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.ControlLight;
            groupBox1.Controls.Add(lblErrorMsg2);
            groupBox1.Controls.Add(lblErrorMsg1);
            groupBox1.Controls.Add(txtNassignments);
            groupBox1.Controls.Add(txtNstudents);
            groupBox1.Controls.Add(lblNassignments);
            groupBox1.Controls.Add(lblNstudents);
            groupBox1.Controls.Add(cmdSubmitCounts);
            groupBox1.Location = new Point(44, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(463, 162);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Counts";
            // 
            // lblErrorMsg2
            // 
            lblErrorMsg2.AutoSize = true;
            lblErrorMsg2.ForeColor = Color.Red;
            lblErrorMsg2.Location = new Point(-1, 107);
            lblErrorMsg2.Name = "lblErrorMsg2";
            lblErrorMsg2.Size = new Size(77, 20);
            lblErrorMsg2.TabIndex = 6;
            lblErrorMsg2.Text = "ErrorMsg2";
            lblErrorMsg2.Visible = false;
            // 
            // lblErrorMsg1
            // 
            lblErrorMsg1.AutoSize = true;
            lblErrorMsg1.ForeColor = Color.Red;
            lblErrorMsg1.Location = new Point(-1, 49);
            lblErrorMsg1.Name = "lblErrorMsg1";
            lblErrorMsg1.Size = new Size(77, 20);
            lblErrorMsg1.TabIndex = 5;
            lblErrorMsg1.Text = "ErrorMsg1";
            lblErrorMsg1.Visible = false;
            // 
            // txtNassignments
            // 
            txtNassignments.Location = new Point(213, 81);
            txtNassignments.Name = "txtNassignments";
            txtNassignments.Size = new Size(62, 27);
            txtNassignments.TabIndex = 4;
            // 
            // txtNstudents
            // 
            txtNstudents.Location = new Point(213, 24);
            txtNstudents.Name = "txtNstudents";
            txtNstudents.Size = new Size(62, 27);
            txtNstudents.TabIndex = 3;
            // 
            // lblNassignments
            // 
            lblNassignments.AutoSize = true;
            lblNassignments.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNassignments.Location = new Point(11, 85);
            lblNassignments.Name = "lblNassignments";
            lblNassignments.Size = new Size(196, 23);
            lblNassignments.TabIndex = 2;
            lblNassignments.Text = "Number of assignments:";
            // 
            // lblNstudents
            // 
            lblNstudents.AutoSize = true;
            lblNstudents.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNstudents.Location = new Point(40, 28);
            lblNstudents.Name = "lblNstudents";
            lblNstudents.Size = new Size(167, 23);
            lblNstudents.TabIndex = 1;
            lblNstudents.Text = "Number of students:";
            // 
            // cmdSubmitCounts
            // 
            cmdSubmitCounts.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cmdSubmitCounts.Location = new Point(296, 48);
            cmdSubmitCounts.Name = "cmdSubmitCounts";
            cmdSubmitCounts.Size = new Size(135, 29);
            cmdSubmitCounts.TabIndex = 0;
            cmdSubmitCounts.Text = "Submit Counts";
            cmdSubmitCounts.UseVisualStyleBackColor = true;
            cmdSubmitCounts.Click += cmdSubmitCounts_Click;
            // 
            // cmdResetScores
            // 
            cmdResetScores.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cmdResetScores.Location = new Point(532, 67);
            cmdResetScores.Name = "cmdResetScores";
            cmdResetScores.Size = new Size(147, 72);
            cmdResetScores.TabIndex = 1;
            cmdResetScores.Text = "Reset Scores";
            cmdResetScores.UseVisualStyleBackColor = true;
            cmdResetScores.Click += cmdResetScores_Click;
            // 
            // groupBoxNavigate
            // 
            groupBoxNavigate.BackColor = SystemColors.ControlLight;
            groupBoxNavigate.Controls.Add(cmdLastStudent);
            groupBoxNavigate.Controls.Add(cmdNextStudent);
            groupBoxNavigate.Controls.Add(cmdPrevStudent);
            groupBoxNavigate.Controls.Add(cmdFirstStudent);
            groupBoxNavigate.Enabled = false;
            groupBoxNavigate.Location = new Point(44, 190);
            groupBoxNavigate.Name = "groupBoxNavigate";
            groupBoxNavigate.Size = new Size(668, 109);
            groupBoxNavigate.TabIndex = 2;
            groupBoxNavigate.TabStop = false;
            groupBoxNavigate.Text = "Navigate";
            // 
            // cmdLastStudent
            // 
            cmdLastStudent.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cmdLastStudent.Location = new Point(491, 46);
            cmdLastStudent.Name = "cmdLastStudent";
            cmdLastStudent.Size = new Size(134, 29);
            cmdLastStudent.TabIndex = 3;
            cmdLastStudent.Text = ">> Last Student";
            cmdLastStudent.UseVisualStyleBackColor = true;
            cmdLastStudent.Click += cmdLastStudent_Click;
            // 
            // cmdNextStudent
            // 
            cmdNextStudent.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cmdNextStudent.Location = new Point(339, 46);
            cmdNextStudent.Name = "cmdNextStudent";
            cmdNextStudent.Size = new Size(134, 29);
            cmdNextStudent.TabIndex = 2;
            cmdNextStudent.Text = "> Next Student";
            cmdNextStudent.UseVisualStyleBackColor = true;
            cmdNextStudent.Click += cmdNextStudent_Click;
            // 
            // cmdPrevStudent
            // 
            cmdPrevStudent.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cmdPrevStudent.Location = new Point(185, 46);
            cmdPrevStudent.Name = "cmdPrevStudent";
            cmdPrevStudent.Size = new Size(134, 29);
            cmdPrevStudent.TabIndex = 1;
            cmdPrevStudent.Text = "< Prev Student";
            cmdPrevStudent.UseVisualStyleBackColor = true;
            cmdPrevStudent.Click += cmdPrevStudent_Click;
            // 
            // cmdFirstStudent
            // 
            cmdFirstStudent.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cmdFirstStudent.Location = new Point(32, 46);
            cmdFirstStudent.Name = "cmdFirstStudent";
            cmdFirstStudent.Size = new Size(134, 29);
            cmdFirstStudent.TabIndex = 0;
            cmdFirstStudent.Text = "<< First Student";
            cmdFirstStudent.UseVisualStyleBackColor = true;
            cmdFirstStudent.Click += cmdFirstStudent_Click;
            // 
            // groupBoxStudentInfo
            // 
            groupBoxStudentInfo.BackColor = SystemColors.ControlLight;
            groupBoxStudentInfo.Controls.Add(lblErrorMsg3);
            groupBoxStudentInfo.Controls.Add(cmdSaveName);
            groupBoxStudentInfo.Controls.Add(txtStudentInfo);
            groupBoxStudentInfo.Controls.Add(lblStudentInfo);
            groupBoxStudentInfo.Enabled = false;
            groupBoxStudentInfo.Location = new Point(44, 322);
            groupBoxStudentInfo.Name = "groupBoxStudentInfo";
            groupBoxStudentInfo.Size = new Size(668, 83);
            groupBoxStudentInfo.TabIndex = 3;
            groupBoxStudentInfo.TabStop = false;
            groupBoxStudentInfo.Text = "Student Info";
            // 
            // lblErrorMsg3
            // 
            lblErrorMsg3.AutoSize = true;
            lblErrorMsg3.ForeColor = Color.Red;
            lblErrorMsg3.Location = new Point(10, 60);
            lblErrorMsg3.Name = "lblErrorMsg3";
            lblErrorMsg3.Size = new Size(77, 20);
            lblErrorMsg3.TabIndex = 3;
            lblErrorMsg3.Text = "ErrorMsg3";
            lblErrorMsg3.Visible = false;
            // 
            // cmdSaveName
            // 
            cmdSaveName.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cmdSaveName.Location = new Point(477, 29);
            cmdSaveName.Name = "cmdSaveName";
            cmdSaveName.Size = new Size(94, 29);
            cmdSaveName.TabIndex = 2;
            cmdSaveName.Text = "Save Name";
            cmdSaveName.UseVisualStyleBackColor = true;
            cmdSaveName.Click += cmdSaveName_Click;
            // 
            // txtStudentInfo
            // 
            txtStudentInfo.Location = new Point(122, 29);
            txtStudentInfo.Name = "txtStudentInfo";
            txtStudentInfo.Size = new Size(286, 27);
            txtStudentInfo.TabIndex = 1;
            // 
            // lblStudentInfo
            // 
            lblStudentInfo.AutoSize = true;
            lblStudentInfo.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStudentInfo.Location = new Point(10, 34);
            lblStudentInfo.Name = "lblStudentInfo";
            lblStudentInfo.Size = new Size(93, 23);
            lblStudentInfo.TabIndex = 0;
            lblStudentInfo.Text = "Student #1";
            // 
            // groupBoxAssignmentInfo
            // 
            groupBoxAssignmentInfo.BackColor = SystemColors.ControlLight;
            groupBoxAssignmentInfo.Controls.Add(lblErrorMsg5);
            groupBoxAssignmentInfo.Controls.Add(lblErrorMsg4);
            groupBoxAssignmentInfo.Controls.Add(cmdSaveScore);
            groupBoxAssignmentInfo.Controls.Add(lblEnterAssignmentScore);
            groupBoxAssignmentInfo.Controls.Add(txtAssignmentScore);
            groupBoxAssignmentInfo.Controls.Add(txtAssignmentNumber);
            groupBoxAssignmentInfo.Controls.Add(lblEnterAssignmentN);
            groupBoxAssignmentInfo.Enabled = false;
            groupBoxAssignmentInfo.Location = new Point(44, 448);
            groupBoxAssignmentInfo.Name = "groupBoxAssignmentInfo";
            groupBoxAssignmentInfo.Size = new Size(668, 139);
            groupBoxAssignmentInfo.TabIndex = 4;
            groupBoxAssignmentInfo.TabStop = false;
            groupBoxAssignmentInfo.Text = "Assignment Info";
            // 
            // lblErrorMsg5
            // 
            lblErrorMsg5.AutoSize = true;
            lblErrorMsg5.ForeColor = Color.Red;
            lblErrorMsg5.Location = new Point(74, 113);
            lblErrorMsg5.Name = "lblErrorMsg5";
            lblErrorMsg5.Size = new Size(77, 20);
            lblErrorMsg5.TabIndex = 6;
            lblErrorMsg5.Text = "ErrorMsg5";
            lblErrorMsg5.Visible = false;
            // 
            // lblErrorMsg4
            // 
            lblErrorMsg4.AutoSize = true;
            lblErrorMsg4.ForeColor = Color.Red;
            lblErrorMsg4.Location = new Point(11, 56);
            lblErrorMsg4.Name = "lblErrorMsg4";
            lblErrorMsg4.Size = new Size(77, 20);
            lblErrorMsg4.TabIndex = 5;
            lblErrorMsg4.Text = "ErrorMsg4";
            lblErrorMsg4.Visible = false;
            // 
            // cmdSaveScore
            // 
            cmdSaveScore.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cmdSaveScore.Location = new Point(467, 56);
            cmdSaveScore.Name = "cmdSaveScore";
            cmdSaveScore.Size = new Size(94, 29);
            cmdSaveScore.TabIndex = 4;
            cmdSaveScore.Text = "Save Score";
            cmdSaveScore.UseVisualStyleBackColor = true;
            cmdSaveScore.Click += cmdSaveScore_Click;
            // 
            // lblEnterAssignmentScore
            // 
            lblEnterAssignmentScore.AutoSize = true;
            lblEnterAssignmentScore.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEnterAssignmentScore.Location = new Point(141, 90);
            lblEnterAssignmentScore.Name = "lblEnterAssignmentScore";
            lblEnterAssignmentScore.Size = new Size(150, 23);
            lblEnterAssignmentScore.TabIndex = 3;
            lblEnterAssignmentScore.Text = "Assignment Score:";
            // 
            // txtAssignmentScore
            // 
            txtAssignmentScore.Location = new Point(299, 85);
            txtAssignmentScore.Name = "txtAssignmentScore";
            txtAssignmentScore.Size = new Size(84, 27);
            txtAssignmentScore.TabIndex = 2;
            // 
            // txtAssignmentNumber
            // 
            txtAssignmentNumber.Location = new Point(299, 32);
            txtAssignmentNumber.Name = "txtAssignmentNumber";
            txtAssignmentNumber.Size = new Size(84, 27);
            txtAssignmentNumber.TabIndex = 1;
            // 
            // lblEnterAssignmentN
            // 
            lblEnterAssignmentN.AutoSize = true;
            lblEnterAssignmentN.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEnterAssignmentN.Location = new Point(35, 36);
            lblEnterAssignmentN.Name = "lblEnterAssignmentN";
            lblEnterAssignmentN.Size = new Size(257, 23);
            lblEnterAssignmentN.TabIndex = 0;
            lblEnterAssignmentN.Text = "Enter Assignment Number (1-X):";
            // 
            // cmdDisplayScores
            // 
            cmdDisplayScores.Enabled = false;
            cmdDisplayScores.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cmdDisplayScores.Location = new Point(308, 605);
            cmdDisplayScores.Name = "cmdDisplayScores";
            cmdDisplayScores.Size = new Size(144, 49);
            cmdDisplayScores.TabIndex = 5;
            cmdDisplayScores.Text = "Display Scores";
            cmdDisplayScores.UseVisualStyleBackColor = true;
            cmdDisplayScores.Click += cmdDisplayScores_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            richTextBox1.Enabled = false;
            richTextBox1.Location = new Point(43, 678);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(669, 206);
            richTextBox1.TabIndex = 6;
            richTextBox1.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 884);
            Controls.Add(richTextBox1);
            Controls.Add(cmdDisplayScores);
            Controls.Add(groupBoxAssignmentInfo);
            Controls.Add(groupBoxStudentInfo);
            Controls.Add(groupBoxNavigate);
            Controls.Add(cmdResetScores);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBoxNavigate.ResumeLayout(false);
            groupBoxStudentInfo.ResumeLayout(false);
            groupBoxStudentInfo.PerformLayout();
            groupBoxAssignmentInfo.ResumeLayout(false);
            groupBoxAssignmentInfo.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox txtNassignments;
        private TextBox txtNstudents;
        private Label lblNassignments;
        private Label lblNstudents;
        private Button cmdSubmitCounts;
        private Button cmdResetScores;
        private GroupBox groupBoxNavigate;
        private Button cmdLastStudent;
        private Button cmdNextStudent;
        private Button cmdPrevStudent;
        private Button cmdFirstStudent;
        private GroupBox groupBoxStudentInfo;
        private Button cmdSaveName;
        private TextBox txtStudentInfo;
        private Label lblStudentInfo;
        private GroupBox groupBoxAssignmentInfo;
        private Label lblEnterAssignmentScore;
        private TextBox txtAssignmentScore;
        private TextBox txtAssignmentNumber;
        private Label lblEnterAssignmentN;
        private Button cmdSaveScore;
        private Button cmdDisplayScores;
        private RichTextBox richTextBox1;
        private Label lblErrorMsg1;
        private Label lblErrorMsg2;
        private Label lblErrorMsg3;
        private Label lblErrorMsg5;
        private Label lblErrorMsg4;
    }
}
