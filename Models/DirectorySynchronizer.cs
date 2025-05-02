using System.Collections.Generic;
using System.IO;

namespace log020525.Models
{
  public class DirectorySynchronizer
  {
    public List<string> SyncDirectories(string sourcePath, string targetPath)
    {
      var syncLog = new List<string>();

      SyncOneWay(sourcePath, targetPath, syncLog);
      SyncOneWay(targetPath, sourcePath, syncLog);

      return syncLog;
    }

    private void SyncOneWay(string sourceDir, string targetDir, List<string> syncLog)
    {
      var sourceFiles = Directory.GetFiles(sourceDir);
      var targetFiles = Directory.GetFiles(targetDir);

      var targetFileNames = new HashSet<string>();
      foreach (var targetFilePath in targetFiles)
      {
        var targetFileName = Path.GetFileName(targetFilePath);
        targetFileNames.Add(targetFileName);
      }

      foreach (var sourceFilePath in sourceFiles)
      {
        var sourceFileName = Path.GetFileName(sourceFilePath);
        var targetFilePath = Path.Combine(targetDir, sourceFileName);

        if (!File.Exists(targetFilePath))
        {
          File.Copy(sourceFilePath, targetFilePath);
          syncLog.Add($"Файл \"{sourceFileName}\" создан");
        }
        else
        {
          var sourceModified = File.GetLastWriteTime(sourceFilePath);
          var targetModified = File.GetLastWriteTime(targetFilePath);

          if (sourceModified > targetModified)
          {
            File.Copy(sourceFilePath, targetFilePath, true);
            syncLog.Add($"Файл \"{sourceFileName}\" изменен");
          }
        }
      }
    }
  }
}
