using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CollegeDB
{
    public partial class Form1 : Form
    {
        // --------------------------------------------------------------------
        // Fields
        // --------------------------------------------------------------------
        private int selectedCollegeID = 0;
        private string logFile = "activity.log";

        // --------------------------------------------------------------------
        // Constructor
        // --------------------------------------------------------------------
        public Form1()
        {
            InitializeComponent();
        }

        // --------------------------------------------------------------------
        // Form Events
        // --------------------------------------------------------------------
        private void Form1_Load(object sender, EventArgs e)
        {
            // Load data on startup
            LoadData();
        }

        // --------------------------------------------------------------------
        // Logging Utility
        // --------------------------------------------------------------------
        private void LogActivity(string message)
        {
            try
            {
                string logEntry = $"{DateTime.Now}: {message}{Environment.NewLine}";
                File.AppendAllText(logFile, logEntry);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Logging failed: " + ex.Message);
            }
        }

        // --------------------------------------------------------------------
        // Data Loading
        // --------------------------------------------------------------------
        private void LoadData()
        {
            try
            {
                Database db = new Database();
                DataTable dt = db.GetDataTable(
                    "SELECT CollegeID, CollegeName, CollegeCode, " +
                    "CASE WHEN IsActive = 1 THEN 'Yes' ELSE 'No' END AS IsActive " +
                    "FROM College"
                );
                dataGridView1.DataSource = dt;
                LogActivity("Data loaded successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
                LogActivity("Error loading data: " + ex.Message);
            }
        }

        // --------------------------------------------------------------------
        // Input Validation
        // --------------------------------------------------------------------
        private bool IsInputValid()
        {
            if (string.IsNullOrWhiteSpace(CollegeNameText.Text) ||
                string.IsNullOrWhiteSpace(CollegeCodeText.Text))
            {
                MessageBox.Show("Please enter both College Name and Code.");
                return false;
            }
            return true;
        }

        // --------------------------------------------------------------------
        // CRUD Operations
        // --------------------------------------------------------------------
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (!IsInputValid())
            {
                return;
            }

            int isActive = chkBox.Checked ? 1 : 0;
            string query = @"
                INSERT INTO College (CollegeName, CollegeCode, IsActive) 
                VALUES (@CollegeName, @CollegeCode, @IsActive)";

            try
            {
                Database db = new Database();
                int rows = db.ExecuteNonQuery(query,
                    new MySqlParameter("@CollegeName", CollegeNameText.Text),
                    new MySqlParameter("@CollegeCode", CollegeCodeText.Text),
                    new MySqlParameter("@IsActive", isActive)
                );

                MessageBox.Show("College Added!");
                LogActivity("College added successfully.");
                ClearInputs();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding college: " + ex.Message);
                LogActivity("Error adding college: " + ex.Message);
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (selectedCollegeID == 0)
            {
                MessageBox.Show("Please select a college first.");
                return;
            }

            if (!IsInputValid())
            {
                return;
            }

            string query = @"
                UPDATE College 
                SET CollegeName = @CollegeName, CollegeCode = @CollegeCode 
                WHERE CollegeID = @CollegeID";

            try
            {
                Database db = new Database();
                int rows = db.ExecuteNonQuery(query,
                    new MySqlParameter("@CollegeID", selectedCollegeID),
                    new MySqlParameter("@CollegeName", CollegeNameText.Text),
                    new MySqlParameter("@CollegeCode", CollegeCodeText.Text)
                );

                MessageBox.Show("College Updated!");
                LogActivity("College updated successfully. ID: " + selectedCollegeID);
                ClearInputs();
                selectedCollegeID = 0;
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating college: " + ex.Message);
                LogActivity("Error updating college: " + ex.Message);
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (selectedCollegeID == 0)
            {
                MessageBox.Show("Please select a college first.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this college?",
                "Confirm Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                string query = "DELETE FROM College WHERE CollegeID = @CollegeID";

                try
                {
                    Database db = new Database();
                    int rows = db.ExecuteNonQuery(query,
                        new MySqlParameter("@CollegeID", selectedCollegeID)
                    );

                    MessageBox.Show("College Deleted!");
                    LogActivity("College deleted successfully. ID: " + selectedCollegeID);
                    ClearInputs();
                    selectedCollegeID = 0;
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting college: " + ex.Message);
                    LogActivity("Error deleting college: " + ex.Message);
                }
            }
        }

        // --------------------------------------------------------------------
        // Utility Methods
        // --------------------------------------------------------------------
        private void ClearInputs()
        {
            CollegeNameText.Clear();
            CollegeCodeText.Clear();
            chkBox.Checked = false;
        }

        // --------------------------------------------------------------------
        // Additional Button Handlers
        // --------------------------------------------------------------------
        private void LoadButton_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void DepartmentButton_Click(object sender, EventArgs e)
        {
            DepartmentManagement dept = new DepartmentManagement();
            dept.Show();
        }

        // --------------------------------------------------------------------
        // DataGridView Events
        // --------------------------------------------------------------------
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedCollegeID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["CollegeID"].Value);
                CollegeNameText.Text = dataGridView1.Rows[e.RowIndex].Cells["CollegeName"].Value.ToString();
                CollegeCodeText.Text = dataGridView1.Rows[e.RowIndex].Cells["CollegeCode"].Value.ToString();
                string isActiveText = dataGridView1.Rows[e.RowIndex].Cells["IsActive"].Value.ToString();
                chkBox.Checked = (isActiveText == "Yes");
            }
        }
    }
}
