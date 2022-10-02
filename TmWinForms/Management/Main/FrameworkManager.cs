using System;
using System.Windows.Forms;

namespace TmWinForms
{
  public partial class FrameworkManager
  {
    public static FxMain MainForm { get; private set; } = null;

    public static FrameworkService Service { get; } = FrameworkService.Create();

    public static PagesManager Pages { get; } = PagesManager.Create();

    public static CxMessageManager Ms { get; } = CxMessageManager.Create();

    public static IMessageHub MsHub { get; } = MessageHub.Create();



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

      Pages.Configure(MainForm);

      //MainForm.Visible = false;

      MainForm.Text = string.Empty;

      MainForm.SetProperties();

      MainForm.SetEvents();

      MainForm.FormClosing += new FormClosingEventHandler(EventMainFormClosing);

      MainForm.Shown += new EventHandler(EventMainFormShown);

      FrameworkSettings.RestoreMainFormLocationAndSize();

      return MainForm;
    }
  }
}