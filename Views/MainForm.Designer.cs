namespace log020525.Views
{
  partial class MainForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.txtSource = new System.Windows.Forms.TextBox();
      this.txtTarget = new System.Windows.Forms.TextBox();
      this.btnSync = new System.Windows.Forms.Button();
      this.lstLog = new System.Windows.Forms.ListBox();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.textBox2 = new System.Windows.Forms.TextBox();
      this.textBox3 = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // txtSource
      // 
      this.txtSource.Location = new System.Drawing.Point(51, 89);
      this.txtSource.Name = "txtSource";
      this.txtSource.Size = new System.Drawing.Size(252, 20);
      this.txtSource.TabIndex = 0;
      // 
      // txtTarget
      // 
      this.txtTarget.Location = new System.Drawing.Point(416, 89);
      this.txtTarget.Name = "txtTarget";
      this.txtTarget.Size = new System.Drawing.Size(252, 20);
      this.txtTarget.TabIndex = 1;
      // 
      // btnSync
      // 
      this.btnSync.Location = new System.Drawing.Point(447, 205);
      this.btnSync.Name = "btnSync";
      this.btnSync.Size = new System.Drawing.Size(221, 108);
      this.btnSync.TabIndex = 2;
      this.btnSync.Text = "Синхронизировать";
      this.btnSync.UseVisualStyleBackColor = true;
      // 
      // lstLog
      // 
      this.lstLog.FormattingEnabled = true;
      this.lstLog.Location = new System.Drawing.Point(92, 205);
      this.lstLog.Name = "lstLog";
      this.lstLog.Size = new System.Drawing.Size(172, 108);
      this.lstLog.TabIndex = 3;
      // 
      // textBox1
      // 
      this.textBox1.BackColor = System.Drawing.SystemColors.Menu;
      this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.textBox1.Location = new System.Drawing.Point(51, 70);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(252, 13);
      this.textBox1.TabIndex = 4;
      this.textBox1.Text = "Введите адрес первой директории (Пример C:\\1)";
      this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
      // 
      // textBox2
      // 
      this.textBox2.BackColor = System.Drawing.SystemColors.Menu;
      this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.textBox2.Location = new System.Drawing.Point(416, 70);
      this.textBox2.Name = "textBox2";
      this.textBox2.Size = new System.Drawing.Size(252, 13);
      this.textBox2.TabIndex = 5;
      this.textBox2.Text = "Введите адрес второй директории (Пример C:\\2)";
      // 
      // textBox3
      // 
      this.textBox3.BackColor = System.Drawing.SystemColors.Menu;
      this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.textBox3.Location = new System.Drawing.Point(92, 186);
      this.textBox3.Name = "textBox3";
      this.textBox3.Size = new System.Drawing.Size(252, 13);
      this.textBox3.TabIndex = 6;
      this.textBox3.Text = "Логи, что поменялось";
      this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.textBox3);
      this.Controls.Add(this.textBox2);
      this.Controls.Add(this.textBox1);
      this.Controls.Add(this.lstLog);
      this.Controls.Add(this.btnSync);
      this.Controls.Add(this.txtTarget);
      this.Controls.Add(this.txtSource);
      this.Name = "MainForm";
      this.Text = "MainForm";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox txtSource;
    private System.Windows.Forms.TextBox txtTarget;
    private System.Windows.Forms.Button btnSync;
    private System.Windows.Forms.ListBox lstLog;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.TextBox textBox2;
    private System.Windows.Forms.TextBox textBox3;
  }
}