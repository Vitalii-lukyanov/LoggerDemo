using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LoggerApp
{
    public class Logger: IDisposable
    {
        private static Logger instance;
        private static object locker1 = new object();
        private static object locker2 = new object();
        //StreamWriter _Writer;
        static string path = "C:\\Users\\Tom\\source\\repos\\LoggerApp\\LoggerApp\\logs.txt";
        public static Logger GetInctance()
        {
            lock (locker1)
            {
                if (instance == null)
                    instance = new Logger();
            }
            return instance;
        }

        public Logger()
        {
            createFile(path);
            //_Writer = new StreamWriter(path, true, Encoding.UTF8);
        }
        private void createFile(string path)
        {
            if (!File.Exists(path))
            {
                File.Create(path);
            }
            
        }

        public void writeLog(string message)
        {
            lock (locker2)
            {
                using(StreamWriter _Writer = new StreamWriter(path, true, Encoding.UTF8))
                {
                    _Writer.WriteLine(message);
                }
                    
            }
        }


        public async Task writeLogAsync(string message)
        {
                 await Task.Run(() => writeLog(message));
        }

        public async Task writeLogAsync(Exception e)
        {
            var message = $"{DateTime.Now}  {e.Source}  {e.Message}";
            await Task.Run(() => writeLog(message));
        }

        public void Dispose()
        {
           // _Writer.Close();
        }
    }
}
