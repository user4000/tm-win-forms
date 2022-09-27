﻿using System;
using System.Windows.Forms;

namespace TmWinForms
{
  public partial class FrameworkManager
  {
    public static FxMain MainForm { get; private set; } = null;

    public static FrameworkService Service { get; } = FrameworkService.Create();



    public static T ApplicationSettings<T>() => (T)(object)Service.CurrentApplicationSettings;

    public static StandardFrameworkSettings FrameworkSettings { get; } = new StandardFrameworkSettings();








    public static void Run() // Главная точка входа - запуск программы начинается с этого метода //
    {
      FxMain mainForm = CreateMainForm();

      ApplicationContext context = new ApplicationContext(mainForm);
      Application.Run(context);
    }

    static FxMain CreateMainForm()
    {
      MainForm = new FxMain();

      Service.Configure(MainForm);

      //MainForm.Visible = false;

      MainForm.Text = string.Empty;

      MainForm.SetProperties();
      MainForm.SetEvents();

      MainForm.FormClosing += new FormClosingEventHandler(EventMainFormClosing);

      FrameworkSettings.RestoreMainFormLocationAndSize();

      return MainForm;
    }
  }
}