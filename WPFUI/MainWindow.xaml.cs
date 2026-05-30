using Core;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace WPFUI
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<Workout> workouts;

        public MainWindow()
        {
            InitializeComponent();

            workouts = new ObservableCollection<Workout>();

            workouts.Add(new Workout()
            {
                WorkoutType = "Біг",
                DurationMinutes = 30,
                CaloriesBurned = 300,
                WorkoutDate = DateTime.Now
            });

            workouts.Add(new Workout()
            {
                WorkoutType = "Бокс",
                DurationMinutes = 60,
                CaloriesBurned = 700,
                WorkoutDate = DateTime.Now
            });

            workoutsGrid.ItemsSource = workouts;

            btnAdd.Click += btnAdd_Click;
            btnEdit.Click += btnEdit_Click;
            btnDelete.Click += btnDelete_Click;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WorkoutWindow window = new WorkoutWindow();

            window.Owner = this;

            if (window.ShowDialog() == true)
            {
                workouts.Add(window.Workout);
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Workout selected = workoutsGrid.SelectedItem as Workout;

            if (selected == null)
            {
                MessageBox.Show("Оберіть тренування для редагування");
                return;
            }

            WorkoutWindow window = new WorkoutWindow(selected);

            window.Owner = this;

            if (window.ShowDialog() == true)
            {
                selected.WorkoutType = window.Workout.WorkoutType;
                selected.DurationMinutes = window.Workout.DurationMinutes;
                selected.CaloriesBurned = window.Workout.CaloriesBurned;
                selected.WorkoutDate = window.Workout.WorkoutDate;

                workoutsGrid.Items.Refresh();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Workout selected = workoutsGrid.SelectedItem as Workout;

            if (selected == null)
            {
                MessageBox.Show("Оберіть тренування для видалення");
                return;
            }

            MessageBoxResult result =
                MessageBox.Show(
                    "Видалити вибране тренування?",
                    "Підтвердження",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                workouts.Remove(selected);
            }
        }
    }
}