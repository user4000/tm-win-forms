﻿using System;
using System.Windows.Forms;

namespace TmWinForms
{
  public partial class FrameworkManager
  {
    public static FxMain MainForm { get; private set; } = null;

    public static FrameworkService Service { get; } = FrameworkService.Create();

    public static PagesManager Pages { get; } = PagesManager.Create();

    public static CxMessageManager Ms { get; } = CxMessageManager.Create();

    public static CxLogger Log { get; } = CxLogger.Create();



    public static IMessageHub MsHub { get; } = MessageHub.Create();

    public static UserEvents Events { get; } = UserEvents.Create();


    public static T ApplicationSettings<T>() => (T)(object)Service.CurrentApplicationSettings;

    public static StandardFrameworkSettings FrameworkSettings { get; } = new StandardFrameworkSettings();




    public static void CreateLogger(string applicationName = "", string filePrefix = "")
    {
      Log.Configure(applicationName, filePrefix);
    }

    static void LoadFrameworkSettings()
    {
      // Программист не удосужился сконфигурировать логгер //
      // Сделаем это за него, с настройками по умолчанию   //
      if (Log.FlagConfigured == false) Log.Configure();

      FrameworkSettings.LoadFrameworkSettings();
      Events.OverrideLoadedFrameworkSettings?.Invoke();
      Events.BeforeMainFormIsCreated?.Invoke();
    }

    public static void Run() // Главная точка входа - запуск программы начинается с этого метода //
    {
      LoadFrameworkSettings();

      FxMain mainForm = CreateMainForm();

      ApplicationContext context = new ApplicationContext(mainForm);

      Application.Run(context);
    }
  }
}