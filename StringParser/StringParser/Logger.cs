namespace StringParser
{
    using System.IO;

    class Logger
    {
        public static void Log(string path, string msg = null)
        {
            if (!File.Exists(path))  
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    if (msg != null) sw.WriteLine(msg);
                    else sw.WriteLine("Something went wrong...");
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    if (msg != null) sw.WriteLine(msg);
                    else sw.WriteLine("Something went wrong...");
                }
            }
        }
    }
}
