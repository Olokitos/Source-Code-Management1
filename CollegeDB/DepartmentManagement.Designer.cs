namespace CollegeDB
{
    partial class DepartmentManagement
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
            CollegeComboBox = new ComboBox();
            DepartmentNameText = new TextBox();
            DepartmentCodeText = new TextBox();
            label1 = new Label();
            label2 = new Label();
            dataGridViewDepartment = new DataGridView();
            SaveButton = new Button();
            UpdateButton = new Button();
            DeleteButton = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDepartment).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // CollegeComboBox
            // 
            CollegeComboBox.FormattingEnabled = true;
            CollegeComboBox.Location = new Point(596, 122);
            CollegeComboBox.Name = "CollegeComboBox";
            CollegeComboBox.Size = new Size(206, 28);
            CollegeComboBox.TabIndex = 0;
            CollegeComboBox.SelectedIndexChanged += CollegeComboBox_SelectedIndexChanged;
            // 
            // DepartmentNameText
            // 
            DepartmentNameText.Location = new Point(90, 123);
            DepartmentNameText.Name = "DepartmentNameText";
            DepartmentNameText.Size = new Size(212, 27);
            DepartmentNameText.TabIndex = 1;
            // 
            // DepartmentCodeText
            // 
            DepartmentCodeText.Location = new Point(353, 123);
            DepartmentCodeText.Name = "DepartmentCodeText";
            DepartmentCodeText.Size = new Size(214, 27);
            DepartmentCodeText.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(90, 82);
            label1.Name = "label1";
            label1.Size = new Size(133, 20);
            label1.TabIndex = 3;
            label1.Text = "Department Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(353, 82);
            label2.Name = "label2";
            label2.Size = new Size(128, 20);
            label2.TabIndex = 4;
            label2.Text = "Department Code";
            // 
            // dataGridViewDepartment
            // 
            dataGridViewDepartment.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewDepartment.Location = new Point(808, 32);
            dataGridViewDepartment.Name = "dataGridViewDepartment";
            dataGridViewDepartment.RowHeadersWidth = 51;
            dataGridViewDepartment.Size = new Size(434, 431);
            dataGridViewDepartment.TabIndex = 5;
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(208, 258);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(94, 58);
            SaveButton.TabIndex = 6;
            SaveButton.Text = "SAVE";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // UpdateButton
            // 
            UpdateButton.Location = new Point(335, 258);
            UpdateButton.Name = "UpdateButton";
            UpdateButton.Size = new Size(94, 58);
            UpdateButton.TabIndex = 7;
            UpdateButton.Text = "UPDATE";
            UpdateButton.UseVisualStyleBackColor = true;
            UpdateButton.Click += UpdateButton_Click;
            // 
            // DeleteButton
            // 
            DeleteButton.Location = new Point(460, 258);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(94, 58);
            DeleteButton.TabIndex = 8;
            DeleteButton.Text = "DELETE";
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.images;
            pictureBox1.Location = new Point(12, 321);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(240, 160);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // DepartmentManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.images1;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1254, 475);
            Controls.Add(pictureBox1);
            Controls.Add(DeleteButton);
            Controls.Add(UpdateButton);
            Controls.Add(SaveButton);
            Controls.Add(dataGridViewDepartment);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(DepartmentCodeText);
            Controls.Add(DepartmentNameText);
            Controls.Add(CollegeComboBox);
            Name = "DepartmentManagement";
            Text = "DepartmentManagement";
            Load += DepartmentManagement_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewDepartment).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox CollegeComboBox;
        private TextBox DepartmentNameText;
        private TextBox DepartmentCodeText;
        private Label label1;
        private Label label2;
        private DataGridView dataGridViewDepartment;
        private Button SaveButton;
        private Button UpdateButton;
        private Button DeleteButton;
        private PictureBox pictureBox1;
    }
}