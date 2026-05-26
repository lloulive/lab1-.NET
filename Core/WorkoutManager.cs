using System.Collections;
using System.Collections.Generic;

namespace Core
{
    public class WorkoutManager : IEnumerable<Workout>
    {
        private List<Workout> workouts = new List<Workout>();

        public void AddWorkout(Workout workout)
        {
            workouts.Add(workout);
        }

        public IEnumerator<Workout> GetEnumerator()
        {
            foreach (var workout in workouts)
            {
                yield return workout;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
