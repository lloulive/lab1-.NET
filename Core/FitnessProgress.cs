using System;

namespace Core
{
    public class FitnessProgress
    {
        public double WeightLost { get; set; }
        public int CompletedWorkouts { get; set; }
        public DateTime LastUpdate { get; set; }
        public bool GoalAchieved { get; set; }

        public override string ToString()
        {
            return $"Втрата ваги: {WeightLost} кг, Тренування: {CompletedWorkouts}";
        }
    }
}