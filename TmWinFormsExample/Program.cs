using System;
using TmWinForms;
using System.IO;
using System.Threading;
using System.Reflection;
using System.Diagnostics;
using Telerik.WinControls;
using System.Windows.Forms;

namespace TmWinFormsExample
{
  static class Program
  {
    public static MySettings AppSettings { get => FrameworkManager.ApplicationSettings<MySettings>(); } // User custom settings in Property Grid //

    public static StandardFrameworkSettings FmSettings { get; } = FrameworkManager.FrameworkSettings; // Framework embedded settings //


    static void SaveToLog(string msg) => FrameworkManager.Log.Save(msg);

















    static void SetFrameworkSettingsBeforeLoadingFromTextFile()
    {
      string assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
      string applicationName = "Test_Application";

      FrameworkManager.Service.CreateApplicationSettings<MySettings>(assemblyName);
      FrameworkManager.CreateLogger(null, applicationName);
     
      /* Настройки фреймворка, которые не сохраняются в текстовом файле и требуют явного указания значений */

      //FmSettings.VisualEffectOnStart = true;
      //FmSettings.RememberMainFormLocation = true;
      //FmSettings.ConfirmExit = false;

      //FmSettings.ValueColumnWidthPercent = 50;

      //FrameworkSettings.MainFormCloseButtonActsAsMinimizeButton = true;
      //FrameworkSettings.MainFormCloseButtonMustNotCloseForm = true;

      //FmSettings.PageViewItemSpacing = 5;
      //FrameworkSettings.StripOrientation = Telerik.WinControls.UI.StripViewAlignment.Left; 
      //FmSettings.TabMinimumWidth = 150;
      //FmSettings.StripOrientation = AppSettings.MainPageOrientation;

      FmSettings.ConfirmExitButtonText = " Click me, my friend !";

      FmSettings.HeaderFormExit = "Test exit";
      FmSettings.HeaderFormLog = "Test log";
      FmSettings.HeaderFormSettings = "Test settings";
    }

    static void OverrideFrameworkSettingsAfterLoadingFromTextFile()
    {
      /* 
       Настройки фреймворка, которые сохраняются в текстовом файле и получают свои значения из текстового файла, но тем не менее
       значения эти могут быть явно перекрыты другими значениями, которые программист должен указать явно в этом методе.
       Это может быть нужно в тех случаях, когда в некотором приложении настройка не должна зависеть от значения в текстовом файле,
       а должна иметь явное значение и не допускать изменения этого значения.
      */


    }

    static void SetFrameworkSettingsAfterLoadingFromTextFile()
    {
      FrameworkManager.Events.OverrideLoadedFrameworkSettings = OverrideFrameworkSettingsAfterLoadingFromTextFile;
    }



    static void SetUserForms()
    {
      ushort f1 = FrameworkManager.Service.AddForm<FxForm1>("form1", "My Form 1", true, true);

      ushort f2 = FrameworkManager.Service.AddForm<FxForm2>("form2", "My Form 2", true, true);

      ushort f3 = FrameworkManager.Service.AddForm<FxForm3>("form3", "My Form 3", true, true);


      //FrameworkManager.Service.SetStartForm(f3);
      //FrameworkManager.Service.SetStartForm("form2");
    }

    static void SetApplicationEvents()
    {
      Action action1 = () => { SaveToLog("MainFormLoad"); };

      Action action2 = () => { SaveToLog("BeforeSubFormsAreCreated"); };

      Action action3 = () => { SaveToLog("BeforeMainFormBecomesVisible"); };

      Action action4 = () => { SaveToLog("MainFormShown"); };

      Action action5 = () => { SaveToLog("Start"); };

      Action action6 = () => { SaveToLog("StartByTimer"); };







      FrameworkManager.Events.MainFormLoad = action1;

      FrameworkManager.Events.BeforeSubFormsAreCreated = action2;

      // Then EventStartWork of each sub-form is executing //

      FrameworkManager.Events.BeforeMainFormBecomesVisible = action3;

      FrameworkManager.Events.MainFormShown = action4;

      FrameworkManager.Events.Start = action5;

      //FrameworkManager.FrameworkSettings.StartTimerIntervalMilliseconds = 500;

      FrameworkManager.Events.StartByTimer = action6;
    }



























    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      SetExceptionHandler();
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      // Сначала установим настройки фреймворка которые не сохраняются в текстовом файле //
      SetFrameworkSettingsBeforeLoadingFromTextFile();

      // Потом установим настройки фреймворка, которые сохраняются в текстовом файле, но их значения мы хотим явно переопределить //
      SetFrameworkSettingsAfterLoadingFromTextFile();

      // Затем укажем какие формы нужно создать на вкладках главной формы //
      SetUserForms();

      // Затем следует настроить события фреймворка //
      SetApplicationEvents();

      // Далее следует запуск фреймворка //
      FrameworkManager.Run();
    }








































    public static void Debug(string message)
    {
      //if (EnterNewBlock) System.Diagnostics.Debug.Indent(); else System.Diagnostics.Debug.Unindent();
      System.Diagnostics.Debug.WriteLine(message);
    }

    public static void SetExceptionHandler()
    {
      //==========================================================================================================================
      // Add the event handler for handling UI thread exceptions to the event.
      Application.ThreadException += new ThreadExceptionEventHandler(UIThreadException);

      // Set the unhandled exception mode to force all Windows Forms errors to go through our handler.
      Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

      // Add the event handler for handling non-UI thread exceptions to the event. 
      AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomainUnhandledException);
      //==========================================================================================================================
    }

    // Creates the error message and displays it.
    private static DialogResult ShowThreadExceptionDialog(string title, Exception ex)
    {
      string errorMsg = "An application error occurred. Please contact the adminstrator " + "with the following information:\n\n";
      errorMsg = errorMsg + ex.Message + "\n\nStack Trace:\n" + ex.StackTrace;

      FxMessage FormMessage = FxMessage.Create();
      FormMessage.ShowMessage(errorMsg);
      return DialogResult.Abort;
      /*
      return RadMessageBox.Show(errorMsg, title, MessageBoxButtons.AbortRetryIgnore, RadMessageIcon.Error);
      return MessageBox.Show(errorMsg, title, MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop);
      */
    }

    public static void UIThreadException(object sender, ThreadExceptionEventArgs t)
    {
      DialogResult result = DialogResult.Cancel;
      try
      {
        result = ShowThreadExceptionDialog("UI thread exception. An error has been occurred", t.Exception);
        Directory.CreateDirectory("log");
        LogErrorToFile(t.Exception);
      }
      catch (Exception ex)
      {
        try
        {
          //RadMessageBox.Show("Fatal Windows Forms Error", "Fatal Windows Forms Error", MessageBoxButtons.OK, RadMessageIcon.Error);
          RadMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, RadMessageIcon.Error);
        }
        finally
        {
          Application.Exit();
        }
      }

      // Exits the program when the user clicks Abort.
      if (result == DialogResult.Abort)
        Application.Exit();
    }

    // Handle the UI exceptions by showing a dialog box, and asking the user whether
    // or not they wish to abort execution.
    // N_O_T_E: This exception cannot be kept from terminating the application - it can only 
    // log the event, and inform the user about it. 
    public static void CurrentDomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
      try
      {
        Exception ex = (Exception)e.ExceptionObject;
        string errorMsg = "An application error occurred. Please contact the adminstrator " +
            "with the following information:\n\n";

        // Since we can't prevent the app from terminating, log this to the event log.
        if (!EventLog.SourceExists("ThreadException"))
        {
          EventLog.CreateEventSource("ThreadException", "Application");
        }

        // Create an EventLog instance and assign its source.
        EventLog myLog = new EventLog() { Source = "ThreadException" };
        myLog.WriteEntry(errorMsg + ex.Message + "\n\nStack Trace:\n" + ex.StackTrace);
        LogErrorToFile(ex);
      }
      catch (Exception exc)
      {
        try
        {
          MessageBox.Show
            ("Fatal Non-UI Error. Could not write the error to the event log. Reason: "
              + exc.Message, "Fatal Non-UI Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
        finally
        {
          Application.Exit();
        }
      }
    }

    public static void LogErrorToFile(Exception ex)
    {
      string time = DateTime.Now.ToString("yyyy-MM-dd--HH-mm-ss");
      string filePath = $@"log\Error_{time}.txt";
      using (StreamWriter writer = new StreamWriter(filePath, true))
      {
        writer.WriteLine("-----------------------------------------------------------------------------");
        writer.WriteLine("Date : " + DateTime.Now.ToString());
        writer.WriteLine();

        while (ex != null)
        {
          writer.WriteLine(ex.GetType().FullName);
          writer.WriteLine("Message : " + ex.Message);
          writer.WriteLine("StackTrace : " + ex.StackTrace);

          ex = ex.InnerException;
        }
      }
    }
  }
}