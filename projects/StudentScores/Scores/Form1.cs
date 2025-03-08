namespace Scores
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Number of Students
        /// </summary>
        int numberOfStudents;

        /// <summary>
        /// Number of Assignments
        /// </summary>
        int numberOfAssignments;

        /// <summary>
        /// Index of Students
        /// </summary>
        int indexOfStudent;

        /// <summary>
        /// Array of Student Names
        /// </summary>
        string[] studentNames;

        /// <summary>
        /// Array of Student Scores
        /// </summary>
        int[,] studentScores;

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This method is used to validate user input. 
        /// It is used to validate number of students, number of assignments, student name, assignment number, assignment score.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="result"></param>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        private bool ValidateInput(string input, out int result, int minValue, int maxValue)
        {
            if (!int.TryParse(input, out result) || result < minValue || result > maxValue)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// This method is used when user submits number of students and number of assignments
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSubmitCounts_Click(object sender, EventArgs e)
        {
            bool isStudentValid = ValidateInput(txtNstudents.Text, out numberOfStudents, 1, 10);
            bool isAssignmentValid = ValidateInput(txtNassignments.Text, out numberOfAssignments, 1, 99);

            // Validate user input for number of students
            if (!isStudentValid)
            {
                lblErrorMsg1.Text = "Please enter a number between 1 and 10.";
                lblErrorMsg1.Visible = true;
                txtNstudents.Clear();
            }
            else
            {
                lblErrorMsg1.Visible = false;
            }

            // Validate user input for number of assignments
            if (!isAssignmentValid)
            {
                lblErrorMsg2.Text = "Please enter a number between 1 and 99.";
                lblErrorMsg2.Visible = true;
                txtNassignments.Clear();
            }
            else
            {
                lblErrorMsg2.Visible = false;
            }

            // Check both conditions
            if (!isStudentValid || !isAssignmentValid)
            {
                return;
            }

            //Enable bottom part of screen
            EnableControls(true);

            //Create arrays
            studentNames = new string[numberOfStudents];
            studentScores = new int[numberOfStudents, numberOfAssignments];

            // Initialize arrays
            for (int i = 0; i < numberOfStudents; i++)
            {
                studentNames[i] = "Student #" + (i + 1);
                for (int j = 0; j < numberOfAssignments; j++)
                {
                    studentScores[i, j] = 0;
                }
            }
            lblEnterAssignmentN.Text = "Enter Assignment Number (1-" + numberOfAssignments + "):";

        }

        /// <summary>
        /// This method enables the lower part of the form
        /// </summary>
        /// <param name="enable"></param>
        private void EnableControls(bool enable)
        {
            groupBoxNavigate.Enabled = true;
            groupBoxStudentInfo.Enabled = true;
            groupBoxAssignmentInfo.Enabled = true;
            cmdDisplayScores.Enabled = true;
            richTextBox1.Enabled = true;
            groupBox1.Enabled = false;
        }

        /// <summary>
        /// This method enables the upper part of the form
        /// </summary>
        /// <param name="enable"></param>
        private void DisableControls(bool enable)
        {
            groupBoxNavigate.Enabled = false;
            groupBoxStudentInfo.Enabled = false;
            groupBoxAssignmentInfo.Enabled = false;
            cmdDisplayScores.Enabled = false;
            richTextBox1.Enabled = false;
            groupBox1.Enabled = true;
        }

        /// <summary>
        /// This method displays student data
        /// </summary>
        private void DisplayStudentData()
        {
            // Generate header
            string header = "STUDENT\t";
            for (int i = 1; i <= numberOfAssignments; i++)
            {
                header += "#" + i + "\t";
            }
            header += "AVG\t GRADE";

            // Display header
            richTextBox1.Text = header + "\n";

            // Display student scores
            for (int i = 0; i < numberOfStudents; i++)
            {
                string studentInfo = studentNames[i] + "\t";
                int totalScore = 0;

                // Display individual assignment scores
                for (int j = 0; j < numberOfAssignments; j++)
                {
                    studentInfo += studentScores[i, j] + "\t";
                    totalScore += studentScores[i, j];
                }

                // Calculate average and add to the string
                double averageScore = totalScore / (double)numberOfAssignments;
                studentInfo += averageScore.ToString("F2") + "\t";

                // Add grade letter using the GradeLetter() method
                studentInfo += GradeLetter(averageScore);

                // Display studentInfo
                richTextBox1.Text += studentInfo + "\n";
            }
        }

        #region Navigation

        /// <summary>
        /// This method is used to navigate to the first student
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdFirstStudent_Click(object sender, EventArgs e)
        {
            // Set index to the first student (zero-based)
            indexOfStudent = 0;

            // Update lblStudentInfo label
            lblStudentInfo.Text = "";
            lblStudentInfo.Text = "Student #" + (indexOfStudent + 1);
        }

        /// <summary>
        /// This method is used to navigate to the previous student
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdPrevStudent_Click(object sender, EventArgs e)
        {
            // Move student index down by 1, but don't go below zero
            if (indexOfStudent > 0)
            {
                indexOfStudent--;                
            }
            
            // Update lblStudentInfo label
            lblStudentInfo.Text = "";
            lblStudentInfo.Text = "Student #" + (indexOfStudent + 1);
        }

        /// <summary>
        /// This method is used to navigate to the next student
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdNextStudent_Click(object sender, EventArgs e)
        {
            // Move student index up by 1, but don't go above the number of students
            if (indexOfStudent < numberOfStudents - 1)
            {
                indexOfStudent++;
            }

            // Update lblStudentInfo label
            lblStudentInfo.Text = "";
            lblStudentInfo.Text = "Student #" + (indexOfStudent + 1);
        }

        /// <summary>
        /// This method is used to navigate to the last student
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdLastStudent_Click(object sender, EventArgs e)
        {
            // Set index to the last student
            indexOfStudent = numberOfStudents - 1;

            // Update lblStudentInfo label
            lblStudentInfo.Text = "";
            lblStudentInfo.Text = "Student #" + (indexOfStudent + 1);
        }

        #endregion

        #region Save and Display Student Info

        /// <summary>
        /// This method saves the student's name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSaveName_Click(object sender, EventArgs e)
        {
            // Validate name (make sure it's not blank)
            if (string.IsNullOrWhiteSpace(txtStudentInfo.Text)) 
            {
                lblErrorMsg3.Text = "Name cannot be blank.";
                lblErrorMsg3.Visible = true;
                txtStudentInfo.Clear();
            }
            else
            {
                lblErrorMsg3.Visible = false;
            }
            // Save name based on the index
            studentNames[indexOfStudent] = txtStudentInfo.Text;

            // Clear the textbox
            txtStudentInfo.Text = "";

            // Clear richTextBox when new data is entered
            richTextBox1.Clear();

            //Tell user to click Display Scores for updated results
            richTextBox1.Text = "Click \"Display Scores\" to view updated results.";
        }

        /// <summary>
        /// This method saves student's assignment score and the assignment number
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSaveScore_Click(object sender, EventArgs e)
        {
          
            // Validate assignment number input
            bool isAssignmentNumberValid = ValidateInput(txtAssignmentNumber.Text, out int assignmentNumber, 1, numberOfAssignments);

            // Validate assignment score input
            bool isAssignmentScoreValid = ValidateInput(txtAssignmentScore.Text, out int assignmentScore, 0, 100);

            // Display error message for invalid assignment number
            if (!isAssignmentNumberValid)
            {
                lblErrorMsg4.Text = "Invalid input for assignment number.";
                lblErrorMsg4.Visible = true;
                txtAssignmentNumber.Clear();
            }
            else
            {
                lblErrorMsg4.Visible = false;
            }

            // Display error message for invalid assignment score
            if (!isAssignmentScoreValid)
            {
                lblErrorMsg5.Text = "Invalid input for assignment score.";
                lblErrorMsg5.Visible = true;
                txtAssignmentScore.Clear();
            }
            else 
            { 
                lblErrorMsg5.Visible = false;
            }

            // Check both conditions together to display both error messages
            if (!isAssignmentNumberValid || !isAssignmentScoreValid)
            {
                return; 
            }

            // Save student's score to the array studentScores
            studentScores[indexOfStudent, assignmentNumber - 1] = assignmentScore;

            //Clear textbox
            txtAssignmentNumber.Text = "";
            txtAssignmentScore.Text = "";

            // Clear richTextBox when new data is entered
            richTextBox1.Clear();

            //Tell user to click Display Scores for updated results
            richTextBox1.Text = "Click \"Display Scores\" to view updated results.";
        }

        /// <summary>
        /// This method calls DisplayStudentData() method when Display Score button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdDisplayScores_Click(object sender, EventArgs e)
        {
            DisplayStudentData();
        }

        /// <summary>
        /// method to calculate grade letter
        /// </summary>
        /// <param name="averageScore"></param>
        /// <returns></returns>
        private string GradeLetter(double averageScore)
        {
            // determine the grade letter based on the average score
            if (averageScore >= 93)
                return "A";
            else if (averageScore >= 90)
                return "A-";
            else if (averageScore >= 87)
                return "B+";
            else if (averageScore >= 83)
                return "B";
            else if (averageScore >= 80)
                return "B-";
            else if (averageScore >= 77)
                return "C+";
            else if (averageScore >= 73)
                return "C";
            else if (averageScore >= 70)
                return "C-";
            else if (averageScore >= 67)
                return "D+";
            else if (averageScore >= 63)
                return "D";
            else if (averageScore >= 60)
                return "D-";
            else
                return "E";
        }

        #endregion

        /// <summary>
        /// This method resets the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdResetScores_Click(object sender, EventArgs e)
        {
            // Clear arrays
            Array.Clear(studentNames, 0, studentNames.Length);
            Array.Clear(studentScores, 0, studentScores.Length);

            // Reset labels and textboxes
            txtNstudents.Text = "";
            txtNassignments.Text = "";

            lblStudentInfo.Text = "Student #1";
            lblEnterAssignmentN.Text = "Enter Assignment Number (1-X):";

            txtStudentInfo.Text = "";
            txtAssignmentNumber.Text = "";
            txtAssignmentScore.Text = "";

            // Clear richTextBox
            richTextBox1.Clear();

            //Enable top
            DisableControls(true);
        }
    }
}
