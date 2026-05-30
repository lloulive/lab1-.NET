using Core;
using System;
using System.Windows;

namespace WPFUI
{
    public partial class WorkoutWindow : Window
    {
        public Workout Workout { get; private set; }

        public WorkoutWindow()
        {
            InitializeComponent();

            dateWorkout.SelectedDate = DateTime.Now;

            btnOk.Click += btnOk_Click;
            btnCancel.Click += btnCancel_Click;
        }

        public WorkoutWindow(Workout workout) : this()
        {
            txtWorkoutType.Text = workout.WorkoutType;
            txtDuration.Text = workout.DurationMinutes.ToString();
            txtCalories.Text = workout.CaloriesBurned.ToString();
            dateWorkout.SelectedDate = workout.WorkoutDate;

            Workout = workout;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            int duration;
            double calories;

            if (!int.TryParse(txtDuration.Text, out duration))
            {
                MessageBox.Show("Некоректна тривалість");
                return;
            }

            if (!double.TryParse(txtCalories.Text, out calories))
            {
                MessageBox.Show("Некоректна кількість калорій");
                return;
            }

            Workout = new Workout()
            {
                WorkoutType = txtWorkoutType.Text,
                DurationMinutes = duration,
                CaloriesBurned = calories,
                WorkoutDate = dateWorkout.SelectedDate ?? DateTime.Now
            };

            DialogResult = true;
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}