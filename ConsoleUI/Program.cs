using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Core;

namespace ConsoleUI
{
    class Program
    {
        static void ChangePrice(Price price)
        {
            price.Value = 999;
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine(" POLYMORPHISM ");

            Activity[] activities =
            {
                new Workout()
                {
                    Name = "Кардіо",
                    WorkoutType = "Біг",
                    CaloriesBurned = 400,
                    DurationMinutes = 30,
                    WorkoutDate = DateTime.Now
                },

                new Workout()
                {
                    Name = "Силова",
                    WorkoutType = "Бокс",
                    CaloriesBurned = 700,
                    DurationMinutes = 60,
                    WorkoutDate = DateTime.Now
                }
            };

            foreach (Activity activity in activities)
            {
                activity.ShowInfo();
                Console.WriteLine("Calories: " + activity.CalculateCalories());
            }

            Console.WriteLine("\n INTERFACE ");

            ITrackable trackedProgress = new FitnessProgress();
            trackedProgress.TrackProgress();

            Console.WriteLine("\n COMPOSITION ");

            AppController controller = new AppController();
            controller.ShowConfiguration();

            Console.WriteLine("\n EXTENSION METHOD ");

            double calories = 500;
            Console.WriteLine(calories.ToCaloriesString());

            Console.WriteLine("\n WORKOUT MANAGER / FOREACH ");

            WorkoutManager manager = new WorkoutManager();

            manager.AddWorkout(new Workout()
            {
                WorkoutType = "Біг",
                DurationMinutes = 30,
                CaloriesBurned = 300,
                WorkoutDate = DateTime.Now
            });

            manager.AddWorkout(new Workout()
            {
                WorkoutType = "Бокс",
                DurationMinutes = 60,
                CaloriesBurned = 650,
                WorkoutDate = DateTime.Now
            });

            foreach (var item in manager)
            {
                Console.WriteLine(item.WorkoutType + " | " + item.CaloriesBurned.ToCaloriesString());
            }

            Console.WriteLine("\n DICTIONARY ");

            Dictionary<int, Workout> workoutDictionary = new Dictionary<int, Workout>();

            workoutDictionary.Add(1, new Workout()
            {
                WorkoutType = "Кардіо",
                DurationMinutes = 50,
                CaloriesBurned = 500,
                WorkoutDate = DateTime.Now
            });

            workoutDictionary.Add(2, new Workout()
            {
                WorkoutType = "Йога",
                DurationMinutes = 40,
                CaloriesBurned = 200,
                WorkoutDate = DateTime.Now
            });

            Workout foundWorkout;

            if (workoutDictionary.TryGetValue(1, out foundWorkout))
            {
                Console.WriteLine("Знайдено: " + foundWorkout.WorkoutType);
            }

            Console.WriteLine("\n HASHSET ");

            HashSet<string> tags = new HashSet<string>();

            tags.Add("Кардіо");
            tags.Add("Біг");
            tags.Add("Кардіо");

            foreach (var tag in tags)
            {
                Console.WriteLine(tag);
            }

            Console.WriteLine("\n STRUCT ");

            Price price = new Price();
            price.Value = 100;

            Console.WriteLine("До метода: " + price.Value);

            ChangePrice(price);

            Console.WriteLine("Після метода: " + price.Value);

            Console.WriteLine("\n BOXING ");

            object obj = 5;
            int number = (int)obj;

            Console.WriteLine("Object: " + obj);
            Console.WriteLine("Unboxed: " + number);

            Console.WriteLine("\n ARRAYLIST VS LIST ");

            Stopwatch sw = new Stopwatch();

            ArrayList arrayList = new ArrayList();

            sw.Start();

            for (int i = 0; i < 1000000; i++)
            {
                arrayList.Add(i);
            }

            sw.Stop();

            Console.WriteLine("ArrayList: " + sw.ElapsedMilliseconds + " ms");

            List<int> list = new List<int>();

            sw.Reset();
            sw.Start();

            for (int i = 0; i < 1000000; i++)
            {
                list.Add(i);
            }

            sw.Stop();

            Console.WriteLine("List<int>: " + sw.ElapsedMilliseconds + " ms");

            Console.WriteLine("\n SYSTEM INFO ");

            Console.WriteLine("OS Version: " + Environment.OSVersion);
            Console.WriteLine("Machine Name: " + Environment.MachineName);
            Console.WriteLine("64-bit OS: " + Environment.Is64BitOperatingSystem);

            long memory = GC.GetTotalMemory(false);

            Console.WriteLine("Використання пам'яті: " + memory + " bytes");

            Console.ReadKey();
        }
    }
}