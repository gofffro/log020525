using System;
using System.Collections.Generic;

namespace log0205025.Views
{
  public interface ISyncView
  {
    string SourceDirectory { get; }
    string TargetDirectory { get; }

    event Action SyncRequested;

    void ShowMessage(string message);
    void DisplayLog(List<string> synchronizationLogs);
  }
}
