using System;
using System.Collections.Generic;
using System.Windows.Forms;
using log0205025.Views;

namespace log020525.Views
{
  public partial class MainForm : Form, ISyncView
  {
    public event Action SyncRequested;

    public string SourceDirectory => txtSource.Text;
    public string TargetDirectory => txtTarget.Text;

    public MainForm()
    {
      InitializeComponent();
      btnSync.Click += (sender, args) => SyncRequested?.Invoke();
    }

    public void ShowMessage(string message)
    {
      MessageBox.Show(message);
    }

    public void DisplayLog(List<string> logs)
    {
      lstLog.Items.Clear();

      foreach (var log in logs)
      {
        lstLog.Items.Add(log);
      }
    }

    private void textBox3_TextChanged(object sender, EventArgs e)
    {

    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {

    }
  }
}
