namespace Core
{
    public class AppController
    {
        private Configuration configuration;

        public AppController()
        {
            configuration = new Configuration();
        }

        public void ShowConfiguration()
        {
            System.Console.WriteLine(configuration.AppName);
        }
    }
}