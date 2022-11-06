using System;
using Serilog;
using System.IO;
using System.Linq;
using System.Diagnostics;
using Telerik.WinControls;

namespace TmWinForms
{
  public class CxLogger : TmWinForms.Logger.IFrameworkLogger
  {
    const string Empty = "";

    internal bool FlagConfigured { get; private set; } = false;

    internal bool FlagStopWork { get; private set; } = true;

    string FolderOfLogFiles { get; set; } = CxLoggerConfig.directory;

    private CxLogger()
    {

    }

    internal static CxLogger Create()
    {
      CxLogger logger = new CxLogger();
      return logger;
    }

    public void DeleteOldLogFiles(int months = 12) => DeleteOldLogFiles(FolderOfLogFiles, months);

    void DeleteOldLogFiles(string folder, int months = 12)
    {
      months = -1 * Math.Abs(months);

      try
      {
        Directory.GetFiles(folder)
           .Select(file => new FileInfo(file))
           .Where(file => file.LastWriteTime < DateTime.Now.AddMonths(months))
           .ToList()
           .ForEach(file => file.Delete());
      }
      catch (Exception ex)
      {
        Trace.WriteLine("Error ! Failed to delete old log files!");
        Trace.WriteLine(ex.Message);
        Trace.WriteLine(ex.StackTrace);
      }
    }

    internal void Configure(string applicationName = Empty, string filePrefix = Empty)
    {
      if (FlagConfigured)
      {
        //RadMessageBox.Show("You must not configure the logger more than one time!", "Error !", System.Windows.Forms.MessageBoxButtons.OK, RadMessageIcon.Error);
        return;
      }

      string dateTime = DateTime.Now.ToString("yyyyMMdd_HHmmss");

      string folder = CxLoggerConfig.directory;

      if (string.IsNullOrWhiteSpace(filePrefix))
      {
        filePrefix = CxLoggerConfig.prefix;
      }

      if (string.IsNullOrWhiteSpace(applicationName) == false)
      {
        folder = $"{folder}/{applicationName}";
      }

      FolderOfLogFiles = folder;
      CheckOldLogFiles();
      string fileName = $"{folder}/{filePrefix}_{dateTime}.txt";
      CreateMainLogger(fileName);
      FlagConfigured = true;
      FlagStopWork = !FlagConfigured;
    }

    void CheckOldLogFiles()
    {
      DateTime today = DateTime.Today;
      double days = Math.Abs( (today - FrameworkManager.FrameworkSettings.TimeCheckOldLogFiles).TotalDays );
      if (days < 30) return;

      FrameworkManager.FrameworkSettings.TimeCheckOldLogFiles = today;
      DeleteOldLogFiles(FolderOfLogFiles, 12);
    }

    void CreateMainLogger(string fileName)
    {
      LoggerConfiguration config = new LoggerConfiguration()
        .MinimumLevel.Debug()
        .WriteTo.File
        (

          fileName,

          outputTemplate: CxLoggerConfig.outputTemplate,

          retainedFileCountLimit: CxLoggerConfig.retainedFileCountLimit,

          fileSizeLimitBytes: CxLoggerConfig.fileSizeLimitBytes,

          rollOnFileSizeLimit: CxLoggerConfig.rollOnFileSizeLimit,

          buffered: CxLoggerConfig.buffered,

          shared: CxLoggerConfig.shared,

          flushToDiskInterval: CxLoggerConfig.flushToDiskInterval,

          rollingInterval: Serilog.RollingInterval.Infinite,

          restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Debug

         );

      Log.Logger = config.CreateLogger();
    
      //RadMessageBox.Show($"Main logger created !!!  {MainLogger.GetType().FullName}");
    }

    internal void EventEndWork()
    {
      FlagStopWork = true;
      Log.CloseAndFlush();    
    }

    public void Save(string message)
    {
      Save(MsgType.Info, string.Empty, message);
    }

    public void Save(string header, string message)
    {
      Save(MsgType.Info, header, message);
    }

    public void Save(MsgType type, string header, string message)
    {
      if (FlagStopWork == true) return;

      string HeaderAndMessage = string.IsNullOrWhiteSpace(header) ? message : header + "; " + message;

      switch (type)
      {
        case MsgType.Debug: Log.Debug(HeaderAndMessage); break;
        case MsgType.Info: Log.Information(HeaderAndMessage); break;
        case MsgType.Ok: Log.Information(HeaderAndMessage); break;
        case MsgType.Fail: Log.Warning(HeaderAndMessage); break;
        case MsgType.Warning: Log.Warning(HeaderAndMessage); break;
        case MsgType.Error: Log.Error(HeaderAndMessage); break;
        default: Log.Debug(HeaderAndMessage); break;         
      }
    }

    public void Save(Exception exception, string message, MsgType type = MsgType.Error)
    {
      if (FlagStopWork == true) return;

      switch (type)
      {
        case MsgType.Debug: Log.Debug(exception, message); break;
        case MsgType.Info: Log.Information(exception, message); break;
        case MsgType.Ok: Log.Information(exception, message); break;
        case MsgType.Fail: Log.Warning(exception, message); break;
        case MsgType.Warning: Log.Error(exception, message); break;
        case MsgType.Error: Log.Fatal(exception, message); break;
        default: Log.Error(exception, message); break;
      }
    }
  }
}