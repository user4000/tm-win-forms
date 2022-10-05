﻿using System;
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
    public static MySettings ApplicationSettings { get => FrameworkManager.ApplicationSettings<MySettings>(); } // User custom settings in Property Grid //

    public static StandardFrameworkSettings FrameworkSettings { get; } = FrameworkManager.FrameworkSettings; // Framework embedded settings //


    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      SetExceptionHandler();
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      string assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
      string applicationName = "Test_Application";

      FrameworkManager.Service.CreateApplicationSettings<MySettings>(assemblyName);

      FrameworkManager.CreateLogger(null, applicationName);
      
        
      // Сначала установим настройки фреймворка //

      FrameworkSettings.VisualEffectOnStart = true;
      FrameworkSettings.RememberMainFormLocation = true;
      FrameworkSettings.ConfirmExit = false;
      FrameworkSettings.ValueColumnWidthPercent = 50;
      FrameworkSettings.ConfirmExitButtonText = " Click me, my friend !";

      FrameworkSettings.HeaderFormExit = "Test exit";
      FrameworkSettings.HeaderFormLog = "Test log";
      FrameworkSettings.HeaderFormSettings = "Test settings";

      //FrameworkSettings.MainFormCloseButtonActsAsMinimizeButton = true;
      //FrameworkSettings.MainFormCloseButtonMustNotCloseForm = true;

      FrameworkSettings.PageViewItemSpacing = 5;
      FrameworkSettings.StripOrientation = Telerik.WinControls.UI.StripViewAlignment.Left;
      FrameworkSettings.TabMinimumWidth = 150;



      // Затем укажем какие формы нужно создать на вкладках главной формы //

      ushort f1 = FrameworkManager.Service.AddForm<FxForm1>("form1", "My Form 1", true, true);

      ushort f2 = FrameworkManager.Service.AddForm<FxForm2>("form2", "My Form 2", true, true);

      ushort f3 = FrameworkManager.Service.AddForm<FxForm3>("form3", "My Form 3", true, true);


      //FrameworkManager.Service.SetStartForm(f3);
      //FrameworkManager.Service.SetStartForm("form2");


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