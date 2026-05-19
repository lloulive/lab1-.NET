using System;
using Core;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Информация о системе
            Console.WriteLine("=== Інформація о системі ===");

            Console.WriteLine("OS Version: " + Environment.OSVersion);
            Console.WriteLine("Machine Name: " + Environment.MachineName);
            Console.WriteLine("64-bit OS: " + Environment.Is64BitOperatingSystem);

            // Память
            long memory = GC.GetTotalMemory(false);

            Console.WriteLine("Використання пам'яті: " + memory + " bytes");

            Console.WriteLine("\n=== Об'єкти ===");

            // User
            User user = new User()
            {
                Name = "Арсеній",
                Age = 19,
                Weight = 90,
                IsPremium = true
            };

            // Workout
            Workout workout = new Workout()
            {
                WorkoutType = "Кардіо",
                DurationMinutes = 40,
                CaloriesBurned = 450,
                WorkoutDate = DateTime.Now
            };

            // Progress
            FitnessProgress progress = new FitnessProgress()
            {
                WeightLost = 3.2,
                CompletedWorkouts = 15,
                LastUpdate = DateTime.Now,
                GoalAchieved = false
            };

            // Вывод
            Console.WriteLine(user);

            Console.WriteLine(workout);

            Console.WriteLine(progress);

            Console.ReadKey();
        }
    }
}