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

        static void ChangePrice(Price price) {
            
            price.Value = 999;

        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine(" STRUCT ");

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

            List<Workout> workouts = new List<Workout>()
{
    new Workout(){ WorkoutType="Біг", DurationMinutes=30, CaloriesBurned=300, WorkoutDate=DateTime.Now },

    new Workout(){ WorkoutType="Кардіо", DurationMinutes=50, CaloriesBurned=500, WorkoutDate=DateTime.Now },

    new Workout(){ WorkoutType="Йога", DurationMinutes=40, CaloriesBurned=200, WorkoutDate=DateTime.Now },

    new Workout(){ WorkoutType="Бокс", DurationMinutes=60, CaloriesBurned=650, WorkoutDate=DateTime.Now },

    new Workout(){ WorkoutType="Плавання", DurationMinutes=45, CaloriesBurned=450, WorkoutDate=DateTime.Now },

    new Workout(){ WorkoutType="Велосипед", DurationMinutes=55, CaloriesBurned=480, WorkoutDate=DateTime.Now },

    new Workout(){ WorkoutType="Стретчінг", DurationMinutes=20, CaloriesBurned=150, WorkoutDate=DateTime.Now },

    new Workout(){ WorkoutType="Силова", DurationMinutes=70, CaloriesBurned=700, WorkoutDate=DateTime.Now },

    new Workout(){ WorkoutType="Кросфіт", DurationMinutes=80, CaloriesBurned=750, WorkoutDate=DateTime.Now },

    new Workout(){ WorkoutType="Танці", DurationMinutes=35, CaloriesBurned=320, WorkoutDate=DateTime.Now }
};

            Console.WriteLine("\n WHERE ");

            var filtered = workouts.Where(w => w.CaloriesBurned > 400);

            foreach (var w in filtered)
            {
                Console.WriteLine(w.WorkoutType + " " + w.CaloriesBurned);
            }

            Console.WriteLine("\n ORDERBY ");

            var sorted = workouts
                .OrderBy(w => w.WorkoutType)
                .ThenBy(w => w.DurationMinutes);

            foreach (var w in sorted)
            {
                Console.WriteLine(w.WorkoutType + " " + w.DurationMinutes);
            }

            Console.WriteLine("\n SELECT ");

            var names = workouts.Select(w => w.WorkoutType);

            foreach (var n in names)
            {
                Console.WriteLine(n);
            }

            Console.WriteLine("\n FIRSTORDEFAULT ");

            var first = workouts.FirstOrDefault(w => w.WorkoutType == "Бокс");

            if (first != null)
            {
                Console.WriteLine(first.WorkoutType + " знайден");
            }
            else
            {
                Console.WriteLine("Не знайден");
            }

            Console.ReadKey();

            // Информация о системе
            Console.WriteLine(" Інформація о системі ");

            Console.WriteLine("OS Version: " + Environment.OSVersion);
            Console.WriteLine("Machine Name: " + Environment.MachineName);
            Console.WriteLine("64-bit OS: " + Environment.Is64BitOperatingSystem);

            // Память
            long memory = GC.GetTotalMemory(false);

            Console.WriteLine("Використання пам'яті: " + memory + " bytes");

            Console.WriteLine("\n Об'єкти ");

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