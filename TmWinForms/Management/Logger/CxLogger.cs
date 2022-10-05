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

    Serilog.Core.Logger MainLogger { get; set; }

    internal bool Configured { get; private set; } = false;

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
      if (Configured)
      {
        RadMessageBox.Show("You must not configure the logger more than one time!", "Error !", System.Windows.Forms.MessageBoxButtons.OK, RadMessageIcon.Error);
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
      Configured = true;
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

      MainLogger = config.CreateLogger();
    }

    internal void EventEndWork()
    {
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
      string HeaderAndMessage = header + "; " + message;

      switch (type)
      {
        case MsgType.Debug: MainLogger.Debug(HeaderAndMessage); break;
        case MsgType.Info: MainLogger.Information(HeaderAndMessage); break;
        case MsgType.Ok: MainLogger.Information(HeaderAndMessage); break;
        case MsgType.Fail: MainLogger.Warning(HeaderAndMessage); break;
        case MsgType.Warning: MainLogger.Warning(HeaderAndMessage); break;
        case MsgType.Error: MainLogger.Error(HeaderAndMessage); break;
        default: MainLogger.Debug(HeaderAndMessage); break;
      }
    }

    public void Save(Exception exception, string message, MsgType type = MsgType.Error)
    {
      switch (type)
      {
        case MsgType.Debug: MainLogger.Debug(exception, message); break;
        case MsgType.Info: MainLogger.Information(exception, message); break;
        case MsgType.Ok: MainLogger.Information(exception, message); break;
        case MsgType.Fail: MainLogger.Warning(exception, message); break;
        case MsgType.Warning: MainLogger.Error(exception, message); break;
        case MsgType.Error: MainLogger.Fatal(exception, message); break;
        default: MainLogger.Error(exception, message); break;
      }
    }
  }
}