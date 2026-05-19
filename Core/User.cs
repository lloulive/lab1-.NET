namespace Core
{
    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }
        public bool IsPremium { get; set; }

        public override string ToString()
        {
            return $"Користувач: {Name}, Вік: {Age}, Вага: {Weight}, Premium: {IsPremium}";
        }
    }
}
