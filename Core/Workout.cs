using System;

namespace Core
{
    public class Workout
    {
        public string WorkoutType { get; set; }
        public int DurationMinutes { get; set; }
        public double CaloriesBurned { get; set; }
        public DateTime WorkoutDate { get; set; }

        public override string ToString()
        {
            return $"Тренування: {WorkoutType}, Тривалість: {DurationMinutes} хв, Калорії: {CaloriesBurned}";
        }
    }
}