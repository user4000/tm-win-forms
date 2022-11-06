using System;
using System.Drawing;
using TmWinForms.Themes;
using System.Windows.Forms;
using Telerik.WinControls;

namespace TmWinForms
{
  public partial class FrameworkManager
  {
    public static FxMain MainForm { get; private set; } = null;

    public static FrameworkService Service { get; } = FrameworkService.Create();

    public static PagesManager Pages { get; } = PagesManager.Create();

    public static TvManager TvNodes { get; } = TvManager.Create();


    public static CxMessageManager Ms { get; } = CxMessageManager.Create();


    public static CxLogger Log { get; } = CxLogger.Create();

    public static IMessageHub MsHub { get; } = MessageHub.Create();

    public static UserEvents Events { get; } = UserEvents.Create();

    public static CxThemeManager ThemeManager { get; } = CxThemeManager.Create();





    public static T ApplicationSettings<T>() => (T)(object)Service.CurrentApplicationSettings;

    public static StandardFrameworkSettings FrameworkSettings { get; } = new StandardFrameworkSettings();



    public static Icon IconApplication { get; private set; }

    public static Icon IconSystemTray  { get; private set; }


    public static bool FlagSystemTrayIconIsConfigured { get; private set; } = false; // Пользователь хочет использовать иконку приложения в системном лотке //


    static bool FlagServiceApplication() // Является ли данное приложение сервером ? //
    {
      return 
        (FrameworkSettings.FlagMainFormStartMinimized) && 
        (FlagSystemTrayIconIsConfigured) && 
        (IconSystemTray != null);
    }



    public static void SetApplicationIcon(Icon icon)
    {
      if (icon != null)
      {
        IconApplication = icon;
      }
    }

    /// <summary>
    /// If you call this method the icon of the application will appear in the system tray.
    /// </summary>
    /// <param name="icon"></param>
    public static void SetIconForSystemTray(Icon icon)
    {
      if (icon != null)
      {
        IconSystemTray = icon;
      }
      FlagSystemTrayIconIsConfigured = true;
    }




    static FrameworkManager()
    {

    }



    static void SetIconDefaultValuesIfTheyHaveNoAnyValue()
    {
      if (IconApplication == null) IconApplication = Properties.Resources.ApplicationIcon;
      if (IconSystemTray == null) IconSystemTray = Properties.Resources.ApplicationIcon;
    }








    public static void CreateLogger(string applicationName = "", string filePrefix = "")
    {
      Log.Configure(applicationName, filePrefix);
    }

    static void LoadFrameworkSettings()
    {
      // Может быть, что программист не удосужился сконфигурировать логгер. Сделаем это за него, с настройками по умолчанию //
      Log.Configure(); 

      FrameworkSettings.LoadFrameworkSettings();

      Events.OverrideLoadedFrameworkSettings?.Invoke();   // При необходимости перезапишем значение настроек фреймворка //

      FrameworkSettings.CheckFrameworkSettings();         // Проверка согласованности настроек фреймворка //

      Events.BeforeMainFormIsCreated?.Invoke();
    }

    internal static void Error(string header, string message)
    {
      RadMessageBox.Show(message, header, MessageBoxButtons.OK, RadMessageIcon.Error);
      throw new ApplicationException($"{header}\r\n{message}");
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