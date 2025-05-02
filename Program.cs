using System;
using System.Windows.Forms;
using log020525.Presenters;
using log020525.Views;

namespace log020525
{
  static class Program
  {
    static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      var form = new MainForm();
      var presenter = new SyncPresenter(form);

      Application.Run(form);
    }
  }
}
