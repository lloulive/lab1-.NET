using System;
using System.Drawing;
using System.Windows.Forms;
using Core;

namespace WinFormsUI
{
    public class WorkoutEditForm : Form
    {
        private TextBox txtWorkoutType;
        private NumericUpDown numDuration;
        private NumericUpDown numCalories;
        private DateTimePicker dtpWorkoutDate;
        private Button btnOk;
        private Button btnCancel;

        public Workout? Workout { get; private set; }

        public WorkoutEditForm()
        {
            Text = "Додати тренування";
            Width = 400;
            Height = 300;
            StartPosition = FormStartPosition.CenterParent;

            Label lblType = new Label();
            lblType.Text = "Тип тренування:";
            lblType.Location = new Point(20, 20);
            lblType.Width = 120;

            txtWorkoutType = new TextBox();
            txtWorkoutType.Location = new Point(160, 20);
            txtWorkoutType.Width = 180;

            Label lblDuration = new Label();
            lblDuration.Text = "Тривалість:";
            lblDuration.Location = new Point(20, 60);
            lblDuration.Width = 120;

            numDuration = new NumericUpDown();
            numDuration.Location = new Point(160, 60);
            numDuration.Minimum = 1;
            numDuration.Maximum = 500;

            Label lblCalories = new Label();
            lblCalories.Text = "Калорії:";
            lblCalories.Location = new Point(20, 100);
            lblCalories.Width = 120;

            numCalories = new NumericUpDown();
            numCalories.Location = new Point(160, 100);
            numCalories.Minimum = 1;
            numCalories.Maximum = 5000;
            numCalories.DecimalPlaces = 2;

            Label lblDate = new Label();
            lblDate.Text = "Дата:";
            lblDate.Location = new Point(20, 140);
            lblDate.Width = 120;

            dtpWorkoutDate = new DateTimePicker();
            dtpWorkoutDate.Location = new Point(160, 140);
            dtpWorkoutDate.Width = 180;

            btnOk = new Button();
            btnOk.Text = "OK";
            btnOk.Location = new Point(80, 200);
            btnOk.Click += btnOk_Click;

            btnCancel = new Button();
            btnCancel.Text = "Cancel";
            btnCancel.Location = new Point(200, 200);
            btnCancel.Click += btnCancel_Click;

            Controls.Add(lblType);
            Controls.Add(txtWorkoutType);
            Controls.Add(lblDuration);
            Controls.Add(numDuration);
            Controls.Add(lblCalories);
            Controls.Add(numCalories);
            Controls.Add(lblDate);
            Controls.Add(dtpWorkoutDate);
            Controls.Add(btnOk);
            Controls.Add(btnCancel);
        }

        private void btnOk_Click(object? sender, EventArgs e)
        {
            Workout = new Workout()
            {
                WorkoutType = txtWorkoutType.Text,
                DurationMinutes = (int)numDuration.Value,
                CaloriesBurned = (double)numCalories.Value,
                WorkoutDate = dtpWorkoutDate.Value
            };

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
