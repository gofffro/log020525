using log020525.Models;
using log0205025.Views;

namespace log020525.Presenters
{
  public class SyncPresenter
  {
    private readonly ISyncView _view;
    private readonly DirectorySynchronizer _directorySynchronizer;

    public SyncPresenter(ISyncView view)
    {
      _view = view;
      _directorySynchronizer = new DirectorySynchronizer();

      _view.SyncRequested += OnSyncRequested;
    }

    private void OnSyncRequested()
    {
      var sourceDirectory = _view.SourceDirectory;
      var targetDirectory = _view.TargetDirectory;

      if (string.IsNullOrWhiteSpace(sourceDirectory) || string.IsNullOrWhiteSpace(targetDirectory))
      {
        _view.ShowMessage("Укажите обе директории");
        return;
      }

      var syncLog = _directorySynchronizer.SyncDirectories(sourceDirectory, targetDirectory);

      _view.DisplayLog(syncLog);
    }
  }
}
