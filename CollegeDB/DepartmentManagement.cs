using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CollegeDB
{
    public partial class DepartmentManagement : Form
    {
        private int selectedDepartmentID = 0; // Track selected department

        public DepartmentManagement()
        {
            InitializeComponent();
        }

        private void DepartmentManagement_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            Database db = new Database();
            dataGridViewDepartment.DataSource = db.GetDataTable(
                "SELECT d.DepartmentID, d.DepartmentName, d.DepartmentCode, d.CollegeID, c.CollegeName, " +
                "CASE WHEN d.IsActive = 1 THEN 'Yes' ELSE 'No' END AS IsActive " +
                "FROM Department d " +
                "INNER JOIN College c ON d.CollegeID = c.CollegeID " +
                "WHERE d.IsActive = 1 AND c.IsActive = 1"
            );

            // Load only active colleges into ComboBox
            CollegeComboBox.DataSource = db.GetDataTable("SELECT CollegeID, CollegeName FROM College WHERE IsActive = 1");
            CollegeComboBox.DisplayMember = "CollegeName";
            CollegeComboBox.ValueMember = "CollegeID";
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(DepartmentNameText.Text) || string.IsNullOrWhiteSpace(DepartmentCodeText.Text))
            {
                MessageBox.Show("Please enter both Department Name and Code.");
                return;
            }

            int collegeID = Convert.ToInt32(CollegeComboBox.SelectedValue);
            string query = "INSERT INTO Department (DepartmentName, DepartmentCode, CollegeID, IsActive) VALUES (@Name, @Code, @CollegeID, 1)";

            Database db = new Database();
            db.ExecuteQuery(query, new MySqlParameter("@Name", DepartmentNameText.Text),
                                   new MySqlParameter("@Code", DepartmentCodeText.Text),
                                   new MySqlParameter("@CollegeID", collegeID));

            MessageBox.Show("Department Added!");
            LoadData();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (selectedDepartmentID == 0)
            {
                MessageBox.Show("Please select a department first.");
                return;
            }

            string query = "UPDATE Department SET DepartmentName = @Name, DepartmentCode = @Code, CollegeID = @CollegeID WHERE DepartmentID = @DeptID";

            Database db = new Database();
            db.ExecuteQuery(query, new MySqlParameter("@Name", DepartmentNameText.Text),
                                   new MySqlParameter("@Code", DepartmentCodeText.Text),
                                   new MySqlParameter("@CollegeID", Convert.ToInt32(CollegeComboBox.SelectedValue)),
                                   new MySqlParameter("@DeptID", selectedDepartmentID));

            MessageBox.Show("Department Updated!");
            LoadData();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (selectedDepartmentID == 0)
            {
                MessageBox.Show("Please select a department first.");
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to delete this department?",
                                                  "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                string query = "UPDATE Department SET IsActive = 0 WHERE DepartmentID = @DeptID";
                Database db = new Database();
                db.ExecuteQuery(query, new MySqlParameter("@DeptID", selectedDepartmentID));

                MessageBox.Show("Department Soft Deleted!");
                LoadData();
                selectedDepartmentID = 0;
            }
        }

        private void dataGridViewDepartment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedDepartmentID = Convert.ToInt32(dataGridViewDepartment.Rows[e.RowIndex].Cells["DepartmentID"].Value);
                DepartmentNameText.Text = dataGridViewDepartment.Rows[e.RowIndex].Cells["DepartmentName"].Value.ToString();
                DepartmentCodeText.Text = dataGridViewDepartment.Rows[e.RowIndex].Cells["DepartmentCode"].Value.ToString();
                CollegeComboBox.SelectedValue = Convert.ToInt32(dataGridViewDepartment.Rows[e.RowIndex].Cells["CollegeID"].Value);
            }
        }

        private void CollegeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // This event is kept in case you need to handle changes in CollegeComboBox in the future
        }
    }
}
