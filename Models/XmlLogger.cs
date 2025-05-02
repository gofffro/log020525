using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace log020525.Models
{
  public static class XmlLogger
  {
    private static readonly string s_logFileName = "sync_log.xml";

    public static void SaveLog(List<SyncLogEntry> logEntries)
    {
      var serializer = new XmlSerializer(typeof(List<SyncLogEntry>));
      using (var stream = File.Create(s_logFileName))
      {
        serializer.Serialize(stream, logEntries);
      }
    }

    public static List<SyncLogEntry> LoadLog()
    {
      if (!File.Exists(s_logFileName))
      {
        return new List<SyncLogEntry>();
      }

      var serializer = new XmlSerializer(typeof(List<SyncLogEntry>));
      using (var stream = File.OpenRead(s_logFileName)) 
      {
        return (List<SyncLogEntry>)serializer.Deserialize(stream);
      }
    }
  }
}
