using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace log020525.Models
{
  public static class JsonLogger
  {
    private static readonly string s_LogFileName = "sync_log.json";

    public static void SaveLog(List<SyncLogEntry> logEntries)
    {
      var json = JsonSerializer.Serialize(logEntries, new JsonSerializerOptions { WriteIndented = true });
      File.WriteAllText(s_LogFileName, json);
    }

    public static List<SyncLogEntry> LoadLog()
    {
      if (!File.Exists(s_LogFileName))
      {
        return new List<SyncLogEntry>();
      }
      var json = File.ReadAllText(s_LogFileName);
      return JsonSerializer.Deserialize<List<SyncLogEntry>>(json);
    }
  }
}
