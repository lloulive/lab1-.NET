using System;
using System.IO;

namespace Core
{
    public class LogResourceManager : IDisposable
    {
        private StreamWriter writer;

        public LogResourceManager(string path)
        {
            writer = new StreamWriter(path, true);
        }

        public void Log(string message)
        {
            writer.WriteLine(message);
        }

        public void Dispose()
        {
            if (writer != null)
            {
                writer.Close();
                Console.WriteLine("Ресурс звільнено");
            }
        }
    }
}
