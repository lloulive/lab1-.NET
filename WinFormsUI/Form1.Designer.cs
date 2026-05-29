namespace WinFormsUI
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
            dataGridViewWorkouts = new DataGridView();
            btnAdd = new Button();
            btnDelete = new Button();
            btnSaveJson = new Button();
            btnLoadJson = new Button();
            btnSaveXml = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewWorkouts).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewWorkouts
            // 
            dataGridViewWorkouts.AllowUserToAddRows = false;
            dataGridViewWorkouts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewWorkouts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewWorkouts.Dock = DockStyle.Top;
            dataGridViewWorkouts.Location = new Point(0, 0);
            dataGridViewWorkouts.MultiSelect = false;
            dataGridViewWorkouts.Name = "dataGridViewWorkouts";
            dataGridViewWorkouts.ReadOnly = true;
            dataGridViewWorkouts.RowHeadersWidth = 51;
            dataGridViewWorkouts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewWorkouts.Size = new Size(800, 188);
            dataGridViewWorkouts.TabIndex = 0;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(661, 211);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Додати";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(661, 246);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Видалити";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnSaveJson
            // 
            btnSaveJson.Location = new Point(661, 315);
            btnSaveJson.Name = "btnSaveJson";
            btnSaveJson.Size = new Size(94, 29);
            btnSaveJson.TabIndex = 3;
            btnSaveJson.Text = "Зберегти JSON";
            btnSaveJson.UseVisualStyleBackColor = true;
            // 
            // btnLoadJson
            // 
            btnLoadJson.Location = new Point(661, 350);
            btnLoadJson.Name = "btnLoadJson";
            btnLoadJson.Size = new Size(94, 29);
            btnLoadJson.TabIndex = 4;
            btnLoadJson.Text = "Завантажити JSON";
            btnLoadJson.UseVisualStyleBackColor = true;
            // 
            // btnSaveXml
            // 
            btnSaveXml.Location = new Point(661, 281);
            btnSaveXml.Name = "btnSaveXml";
            btnSaveXml.Size = new Size(94, 29);
            btnSaveXml.TabIndex = 5;
            btnSaveXml.Text = "Зберегти XML";
            btnSaveXml.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSaveXml);
            Controls.Add(btnLoadJson);
            Controls.Add(btnSaveJson);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(dataGridViewWorkouts);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridViewWorkouts).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewWorkouts;
        private Button btnAdd;
        private Button btnDelete;
        private Button btnSaveJson;
        private Button btnLoadJson;
        private Button btnSaveXml;
    }
}
