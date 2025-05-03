using System;

namespace log020525.Models
{
  public class SyncLogEntry
  {
    public string FileName { get; set; }
    public string Action { get; set; }
    public DateTime Timestamp { get; set; }
  }
}
