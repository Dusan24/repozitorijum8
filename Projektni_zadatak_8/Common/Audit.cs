using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Audit:IDisposable
    {

        private static EventLog customLog = null;
        const string SourceName = "SecurityManager.Audit";
        const string LogName = "PZ8";

        static Audit()
        {
            try
            {
                /// create customLog handle
                if (!EventLog.SourceExists(SourceName))
                {
                    EventLog.CreateEventSource(SourceName, LogName);
                }
                customLog = new EventLog(LogName, Environment.MachineName, SourceName);

            }
            catch (Exception e)
            {
                customLog = null;
                Console.WriteLine("Error while trying to create log handle. Error = {0}", e.Message);
            }
        }

        public static void WriteEntry1(string message)
        {
            customLog.WriteEntry(message);
        }

        public static void WriteEntry2(string message)
        {
            customLog.WriteEntry(message,EventLogEntryType.Warning);
        }
        public void Dispose()
        {
            if (customLog != null)
            {
                customLog.Dispose();
                customLog = null;
            }
        }
    }
}
