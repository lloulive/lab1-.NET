using Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
using System.Xml.Linq;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine(" LAB 5: JSON SERIALIZATION ");

            List<Workout> workouts = new List<Workout>()
            {
                new Workout()
                {
                    WorkoutType = "Біг",
                    DurationMinutes = 30,
                    CaloriesBurned = 300,
                    WorkoutDate = DateTime.Now
                },

                new Workout()
                {
                    WorkoutType = "Бокс",
                    DurationMinutes = 60,
                    CaloriesBurned = 700,
                    WorkoutDate = DateTime.Now
                },

                new Workout()
                {
                    WorkoutType = "Йога",
                    DurationMinutes = 40,
                    CaloriesBurned = 200,
                    WorkoutDate = DateTime.Now
                }
            };

            string jsonPath = "workouts.json";

            string json = JsonConvert.SerializeObject(workouts, Formatting.Indented);

            File.WriteAllText(jsonPath, json);

            Console.WriteLine("JSON файл збережено");

            Console.WriteLine("\n JSON DESERIALIZATION ");

            if (File.Exists(jsonPath))
            {
                try
                {
                    string loadedJson = File.ReadAllText(jsonPath);

                    List<Workout> loadedWorkouts =
                        JsonConvert.DeserializeObject<List<Workout>>(loadedJson);

                    foreach (var item in loadedWorkouts)
                    {
                        Console.WriteLine(item.WorkoutType + " | " + item.CaloriesBurned + " kcal");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Помилка читання JSON: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Файл JSON не знайдено");
            }

            Console.WriteLine("\n XML EXPORT ");

            XDocument xml =
                new XDocument(
                    new XElement("Workouts",

                        workouts
                        .Where(w => w.CaloriesBurned > 300)
                        .Select(w =>

                            new XElement("Workout",

                                new XElement("Type", w.WorkoutType),
                                new XElement("DurationMinutes", w.DurationMinutes),
                                new XElement("CaloriesBurned", w.CaloriesBurned),
                                new XElement("WorkoutDate", w.WorkoutDate)
                            )
                        )
                    )
                );

            string xmlPath = "workouts.xml";

            xml.Save(xmlPath);

            Console.WriteLine("XML файл збережено");

            Console.WriteLine("\n IDisposable / USING ");

            using (LogResourceManager rm = new LogResourceManager("log.txt"))
            {
                rm.Log("Програма запущена");
                rm.Log("Дані тренувань збережено у JSON");
                rm.Log("Дані тренувань експортовано у XML");
            }

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