using System.IO;
using System;

namespace LogViewer.Logging
{
    public class OutLog
    {
        public void Log(string logMsg)
        {
            using (StreamWriter writer = new StreamWriter("LogViewer.log",true))
            {
                
                writer.WriteLine("-----------------------------------------");
                writer.WriteLine("DateTime: " + DateTime.Now);
                writer.WriteLine(logMsg);
                writer.WriteLine("-----------------------------------------");
            }
        }
    }
}
