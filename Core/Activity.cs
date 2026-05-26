namespace Core
{
    public abstract class Activity
    {
        public string Name { get; set; }

        public virtual void ShowInfo()
        {
            System.Console.WriteLine("Активность: " + Name);
        }

        public abstract double CalculateCalories();
    }
}