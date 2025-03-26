namespace CollegeDB
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
            CollegeNameText = new TextBox();
            CollegeCodeText = new TextBox();
            SaveButton = new Button();
            UpdateButton = new Button();
            DeleteButton = new Button();
            LoadButton = new Button();
            dataGridView1 = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            DepartmentButton = new Button();
            chkBox = new CheckBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // CollegeNameText
            // 
            CollegeNameText.Location = new Point(295, 131);
            CollegeNameText.Name = "CollegeNameText";
            CollegeNameText.Size = new Size(125, 27);
            CollegeNameText.TabIndex = 0;
            // 
            // CollegeCodeText
            // 
            CollegeCodeText.Location = new Point(469, 131);
            CollegeCodeText.Name = "CollegeCodeText";
            CollegeCodeText.Size = new Size(125, 27);
            CollegeCodeText.TabIndex = 1;
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(150, 257);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(94, 29);
            SaveButton.TabIndex = 2;
            SaveButton.Text = "SAVE";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // UpdateButton
            // 
            UpdateButton.Location = new Point(280, 257);
            UpdateButton.Name = "UpdateButton";
            UpdateButton.Size = new Size(94, 29);
            UpdateButton.TabIndex = 3;
            UpdateButton.Text = "UPDATE";
            UpdateButton.UseVisualStyleBackColor = true;
            UpdateButton.Click += UpdateButton_Click;
            // 
            // DeleteButton
            // 
            DeleteButton.Location = new Point(422, 257);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(94, 29);
            DeleteButton.TabIndex = 4;
            DeleteButton.Text = "DELETE";
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // LoadButton
            // 
            LoadButton.Location = new Point(563, 257);
            LoadButton.Name = "LoadButton";
            LoadButton.Size = new Size(94, 29);
            LoadButton.TabIndex = 5;
            LoadButton.Text = "LOAD";
            LoadButton.UseVisualStyleBackColor = true;
            LoadButton.Click += LoadButton_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(663, 35);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(572, 409);
            dataGridView1.TabIndex = 6;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(295, 78);
            label1.Name = "label1";
            label1.Size = new Size(115, 20);
            label1.TabIndex = 7;
            label1.Text = "COLLEGE NAME";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(466, 78);
            label2.Name = "label2";
            label2.Size = new Size(112, 20);
            label2.TabIndex = 8;
            label2.Text = "COLLEGE CODE";
            // 
            // DepartmentButton
            // 
            DepartmentButton.Location = new Point(150, 367);
            DepartmentButton.Name = "DepartmentButton";
            DepartmentButton.Size = new Size(185, 64);
            DepartmentButton.TabIndex = 9;
            DepartmentButton.Text = "Go to Department";
            DepartmentButton.UseVisualStyleBackColor = true;
            DepartmentButton.Click += DepartmentButton_Click;
            // 
            // chkBox
            // 
            chkBox.AutoSize = true;
            chkBox.Location = new Point(319, 181);
            chkBox.Name = "chkBox";
            chkBox.Size = new Size(82, 24);
            chkBox.TabIndex = 10;
            chkBox.Text = "IsActive";
            chkBox.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.images;
            pictureBox1.Location = new Point(4, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(240, 160);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 11;
            pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.uclm;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1269, 479);
            Controls.Add(pictureBox1);
            Controls.Add(chkBox);
            Controls.Add(DepartmentButton);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(LoadButton);
            Controls.Add(DeleteButton);
            Controls.Add(UpdateButton);
            Controls.Add(SaveButton);
            Controls.Add(CollegeCodeText);
            Controls.Add(CollegeNameText);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox CollegeNameText;
        private TextBox CollegeCodeText;
        private Button SaveButton;
        private Button UpdateButton;
        private Button DeleteButton;
        private Button LoadButton;
        private DataGridView dataGridView1;
        private Label label1;
        private Label label2;
        private Button DepartmentButton;
        private CheckBox chkBox;
        private PictureBox pictureBox1;
    }
}
