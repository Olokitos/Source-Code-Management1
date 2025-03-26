using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CollegeDB
{
    public partial class Form1 : Form
    {
        private int selectedCollegeID = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData(); // Load data on startup
        }

        private void LoadData()
        {
            Database db = new Database();
            DataTable dt = db.GetDataTable("SELECT CollegeID, CollegeName, CollegeCode, CASE WHEN IsActive = 1 THEN 'Yes' ELSE 'No' END AS IsActive FROM College");
            dataGridView1.DataSource = dt;
        }

        // Registration button
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CollegeNameText.Text) || string.IsNullOrWhiteSpace(CollegeCodeText.Text))
            {
                MessageBox.Show("Please enter both College Name and Code.");
                return;
            }

            int isActive = chkBox.Checked ? 1 : 0; // If checkbox is checked, set to 1 (Yes), else 0 (No)

            string query = "INSERT INTO College (CollegeName, CollegeCode, IsActive) VALUES (@CollegeName, @CollegeCode, @IsActive)";

            using (MySqlConnection con = new MySqlConnection("server=localhost;database=CollegeDB;user=root;password=123456789;"))
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
            CollegeNameText.Clear();
            CollegeCodeText.Clear();
            chkBox.Checked = false; // Reset checkbox after adding
            LoadData(); // Reload data after inserting
        }

        // Improved update button
        private void UpdateButton_Click(object sender, EventArgs e)
        {
            // Validate that a college is selected and input fields are not empty.
            if (selectedCollegeID == 0)
            {
                MessageBox.Show("Please select a college first.");
                return;
            }

            if (string.IsNullOrWhiteSpace(CollegeNameText.Text) || string.IsNullOrWhiteSpace(CollegeCodeText.Text))
            {
                MessageBox.Show("Please enter both College Name and Code.");
                return;
            }

            string query = "UPDATE College SET CollegeName = @CollegeName, CollegeCode = @CollegeCode WHERE CollegeID = @CollegeID";

            using (MySqlConnection con = new MySqlConnection("server=localhost;database=CollegeDB;user=root;password=123456789;"))
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
            CollegeNameText.Clear();
            CollegeCodeText.Clear();
            selectedCollegeID = 0; // Reset selection
            LoadData(); // Reload data after updating
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (selectedCollegeID == 0)
            {
                MessageBox.Show("Please select a college first.");
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to delete this college?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                string query = "DELETE FROM College WHERE CollegeID = @CollegeID";

                using (MySqlConnection con = new MySqlConnection("server=localhost;database=CollegeDB;user=root;password=123456789;"))
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@CollegeID", selectedCollegeID);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("College Deleted!");
                CollegeNameText.Clear();
                CollegeCodeText.Clear();
                selectedCollegeID = 0; // Reset selection
                LoadData(); // Reload data after deletion
            }
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            LoadData(); // Simply reload data
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure a valid row is clicked
            {
                selectedCollegeID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["CollegeID"].Value);
                CollegeNameText.Text = dataGridView1.Rows[e.RowIndex].Cells["CollegeName"].Value.ToString();
                CollegeCodeText.Text = dataGridView1.Rows[e.RowIndex].Cells["CollegeCode"].Value.ToString();

                // Set checkbox state based on IsActive column
                string isActiveText = dataGridView1.Rows[e.RowIndex].Cells["IsActive"].Value.ToString();
                chkBox.Checked = isActiveText == "Yes";
            }
        }

        private void DepartmentButton_Click(object sender, EventArgs e)
        {
            DepartmentManagement dept = new DepartmentManagement();
            dept.Show();
        }
    }
}
