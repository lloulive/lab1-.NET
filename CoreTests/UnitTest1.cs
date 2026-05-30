using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core;
using System.Collections.Generic;
using System.Linq;

namespace CoreTests
{
    [TestClass]
    public class WorkoutTests
    {
        [TestMethod]
        public void CalculateCalories_ReturnsCaloriesBurned()
        {
            Workout workout = new Workout()
            {
                WorkoutType = "Біг",
                DurationMinutes = 30,
                CaloriesBurned = 300
            };

            double result = workout.CalculateCalories();

            Assert.AreEqual(300, result);
        }

        [TestMethod]
        public void WorkoutDuration_ShouldBePositive()
        {
            Workout workout = new Workout()
            {
                WorkoutType = "Бокс",
                DurationMinutes = 60,
                CaloriesBurned = 700
            };

            Assert.IsTrue(workout.DurationMinutes > 0);
        }

        [TestMethod]
        public void LinqFilter_ReturnsHighCalorieWorkouts()
        {
            List<Workout> workouts = new List<Workout>()
            {
                new Workout(){ WorkoutType = "Йога", CaloriesBurned = 200 },
                new Workout(){ WorkoutType = "Бокс", CaloriesBurned = 700 },
                new Workout(){ WorkoutType = "Біг", CaloriesBurned = 400 }
            };

            var filtered = workouts
                .Where(w => w.CaloriesBurned > 300)
                .ToList();

            Assert.AreEqual(2, filtered.Count);
        }

        [TestMethod]
        public void WorkoutType_ShouldNotBeEmpty()
        {
            Workout workout = new Workout()
            {
                WorkoutType = "Кардіо",
                DurationMinutes = 45,
                CaloriesBurned = 500
            };

            Assert.IsFalse(string.IsNullOrEmpty(workout.WorkoutType));
        }
    }
}
