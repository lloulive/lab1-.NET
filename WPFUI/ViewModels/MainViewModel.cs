using Core;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Newtonsoft.Json;
using System.IO;

namespace WPFUI.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly string filePath =
    Path.Combine(
        AppDomain.CurrentDomain.BaseDirectory,
        "workouts_mvvm.json");

        public ObservableCollection<Workout> Workouts { get; set; }

        private Workout selectedWorkout;

        public Workout SelectedWorkout
        {
            get
            {
                return selectedWorkout;
            }
            set
            {
                selectedWorkout = value;
                OnPropertyChanged("SelectedWorkout");
            }
        }

        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand SaveCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel()
        {
            Workouts = new ObservableCollection<Workout>();

            Workouts.Add(new Workout()
            {
                WorkoutType = "Біг",
                DurationMinutes = 30,
                CaloriesBurned = 300,
                WorkoutDate = DateTime.Now
            });

            Workouts.Add(new Workout()
            {
                WorkoutType = "Бокс",
                DurationMinutes = 60,
                CaloriesBurned = 700,
                WorkoutDate = DateTime.Now
            });

            AddCommand = new RelayCommand(AddWorkout);
            DeleteCommand = new RelayCommand(DeleteWorkout);
            EditCommand = new RelayCommand(EditWorkout);
            SaveCommand = new RelayCommand(SaveWorkouts);
        }

        private void AddWorkout(object parameter)
        {
            Workouts.Add(new Workout()
            {
                WorkoutType = "Нове тренування",
                DurationMinutes = 30,
                CaloriesBurned = 250,
                WorkoutDate = DateTime.Now
            });
        }

        private void DeleteWorkout(object parameter)
        {
            if (SelectedWorkout != null)
            {
                Workouts.Remove(SelectedWorkout);
            }
        }

        private void EditWorkout(object parameter)
        {
            if (SelectedWorkout != null)
            {
                int index = Workouts.IndexOf(SelectedWorkout);

                if (index >= 0)
                {
                    Workouts[index] = new Workout()
                    {
                        WorkoutType = "Редаговане тренування",
                        DurationMinutes = 45,
                        CaloriesBurned = 500,
                        WorkoutDate = DateTime.Now
                    };
                }
            }
        }

        private void SaveWorkouts(object parameter)
        {
            string json = JsonConvert.SerializeObject(
                Workouts,
                Formatting.Indented);

            File.WriteAllText("workouts_mvvm.json", json);
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(
                    this,
                    new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}