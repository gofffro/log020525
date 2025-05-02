using System;
using System.Collections.Generic;
using System.IO;

namespace log020525.Models
{
  public class DirectorySynchronizer
  {
    public List<string> SyncDirectories(string sourcePath, string targetPath)
    {
      var synchronizationLog = new List<string>();
      var logEntries = new List<SyncLogEntry>();

      var previousLogEntries = XmlLogger.LoadLog();

      SyncOneWay(sourcePath, targetPath, synchronizationLog, logEntries, previousLogEntries);
      SyncOneWay(targetPath, sourcePath, synchronizationLog, logEntries, previousLogEntries);

      XmlLogger.SaveLog(logEntries);
      JsonLogger.SaveLog(logEntries);

      return synchronizationLog;
    }

    private void SyncOneWay(string sourceDirectory, string targetDirectory, List<string> synchronizationLog, List<SyncLogEntry> logEntries, List<SyncLogEntry> previousLogEntries)
    {
      var sourceFilePaths = Directory.GetFiles(sourceDirectory);
      var targetFilePaths = Directory.GetFiles(targetDirectory);

      var targetFileNamesSet = new HashSet<string>();

      foreach (string targetFilePath in targetFilePaths)
      {
        string targetFileName = Path.GetFileName(targetFilePath);
        targetFileNamesSet.Add(targetFileName);
      }

      foreach (string sourceFilePath in sourceFilePaths)
      {
        string sourceFileName = Path.GetFileName(sourceFilePath);
        string correspondingTargetPath = Path.Combine(targetDirectory, sourceFileName);
        DateTime sourceLastModified = File.GetLastWriteTime(sourceFilePath);

        if (!ShouldSynchronize(sourceFileName, sourceLastModified, previousLogEntries))
        {
          continue;
        }

        if (!File.Exists(correspondingTargetPath))
        {
          File.Copy(sourceFilePath, correspondingTargetPath);
          synchronizationLog.Add($"Файл \"{sourceFileName}\" создан");
          logEntries.Add(new SyncLogEntry
          {
            FileName = sourceFileName,
            Action = "создан",
            Timestamp = DateTime.Now
          });
        }
        else
        {
          DateTime targetLastModified = File.GetLastWriteTime(correspondingTargetPath);

          if (sourceLastModified > targetLastModified)
          {
            File.Copy(sourceFilePath, correspondingTargetPath, true);
            synchronizationLog.Add($"Файл \"{sourceFileName}\" изменен");
            logEntries.Add(new SyncLogEntry
            {
              FileName = sourceFileName,
              Action = "изменен",
              Timestamp = DateTime.Now
            });
          }
        }
      }

      foreach (string targetFilePath in targetFilePaths)
      {
        string targetFileName = Path.GetFileName(targetFilePath);
        string correspondingSourcePath = Path.Combine(sourceDirectory, targetFileName);

        if (!File.Exists(correspondingSourcePath))
        {
          File.Delete(targetFilePath);
          synchronizationLog.Add($"Файл \"{targetFileName}\" удален");
          logEntries.Add(new SyncLogEntry
          {
            FileName = targetFileName,
            Action = "удален",
            Timestamp = DateTime.Now
          });
        }
      }
    }

    private bool ShouldSynchronize(string fileName, DateTime currentModifiedTime, List<SyncLogEntry> previousLogEntries)
    {
      SyncLogEntry lastLog = previousLogEntries.FindLast(entry => entry.FileName == fileName && (entry.Action == "изменен" || entry.Action == "создан"));

      return lastLog == null || currentModifiedTime > lastLog.Timestamp;
    }
  }
}
