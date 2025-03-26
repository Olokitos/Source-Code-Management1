using System;
using System.Data;
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
        private string connectionString = "server=localhost;database=CollegeDB;user=root;password=123456789;";

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
        // Database Connection Helper
        // --------------------------------------------------------------------
        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        // --------------------------------------------------------------------
        // CRUD Operations
        // --------------------------------------------------------------------
        
        /// <summary>
        /// Inserts a new College record into the database with error handling.
        /// </summary>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CollegeNameText.Text) ||
                string.IsNullOrWhiteSpace(CollegeCodeText.Text))
            {
                MessageBox.Show("Please enter both College Name and Code.");
                return;
            }

            int isActive = chkBox.Checked ? 1 : 0;
            string query = @"
                INSERT INTO College (CollegeName, CollegeCode, IsActive) 
                VALUES (@CollegeName, @CollegeCode, @IsActive)";

            try
            {
                using (MySqlConnection con = GetConnection())
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@CollegeName", CollegeNameText.Text);
                        cmd.Parameters.AddWithValue("@CollegeCode", CollegeCodeText.Text);
                        cmd.Parameters.AddWithValue("@IsActive", isActive);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("College Added!");
                ClearInputs();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding college: " + ex.Message);
            }
        }

        /// <summary>
        /// Updates the selected College record in the database with error handling.
        /// </summary>
        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (selectedCollegeID == 0)
            {
                MessageBox.Show("Please select a college first.");
                return;
            }

            if (string.IsNullOrWhiteSpace(CollegeNameText.Text) ||
                string.IsNullOrWhiteSpace(CollegeCodeText.Text))
            {
                MessageBox.Show("Please enter both College Name and Code.");
                return;
            }

            string query = @"
                UPDATE College 
                SET CollegeName = @CollegeName, CollegeCode = @CollegeCode 
                WHERE CollegeID = @CollegeID";

            try
            {
                using (MySqlConnection con = GetConnection())
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@CollegeID", selectedCollegeID);
                        cmd.Parameters.AddWithValue("@CollegeName", CollegeNameText.Text);
                        cmd.Parameters.AddWithValue("@CollegeCode", CollegeCodeText.Text);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("College Updated!");
                ClearInputs();
                selectedCollegeID = 0;
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating college: " + ex.Message);
            }
        }

        /// <summary>
        /// Deletes the selected College record from the database with error handling.
        /// </summary>
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
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                string query = "DELETE FROM College WHERE CollegeID = @CollegeID";

                try
                {
                    using (MySqlConnection con = GetConnection())
                    {
                        con.Open();
                        using (MySqlCommand cmd = new MySqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@CollegeID", selectedCollegeID);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("College Deleted!");
                    ClearInputs();
                    selectedCollegeID = 0;
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting college: " + ex.Message);
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

