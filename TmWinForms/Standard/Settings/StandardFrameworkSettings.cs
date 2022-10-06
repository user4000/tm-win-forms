using System;
using System.IO;
using System.Drawing;
using Newtonsoft.Json;
using TmWinForms.Tools;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using static TmWinForms.FrameworkManager;

namespace TmWinForms
{
  [JsonObject(MemberSerialization.OptIn)]
  public partial class StandardFrameworkSettings : StandardJsonSettings<StandardFrameworkSettings>
  {
    private int tabMinWidth = 100;


    /// <summary>
    /// The property is stored in the file.
    /// </summary>
    
    [JsonProperty]
    public int TabMinimumWidth // Минимальная ширина вкладки //
    {
      get => tabMinWidth;
      set
      {
        bool ValueIsOk = ((value >= 30) && (value <= 500));
        if (ValueIsOk)
          tabMinWidth = value;
        else
          tabMinWidth = 100;
      }
    }

    public string ThemeName { get; set; } = string.Empty; // Если пользователь задаст это значение, то фреймворк постарается найти и применить данную тему //





    private Font pageViewFont = new Font("Verdana", 9, FontStyle.Regular);



    /// <summary>
    /// The property is stored in the file.
    /// </summary>

    [JsonProperty]
    public Font PageViewFont
    {
      get => pageViewFont;
      set
      {
        bool CheckIsNull = FrameworkManager.MainForm?.PvMain?.Font == null ? true : false;
        bool ValueIsOK = ((value.Size >= 6) && (value.Size <= 30));

        if (ValueIsOK)
        {
          pageViewFont = value;
          if (CheckIsNull == false) FrameworkManager.MainForm.PvMain.Font = pageViewFont;
        }
      }
    }


    /// <summary>
    /// The property is stored in the file.
    /// </summary>

    [JsonProperty]
    public Font FontAlertCaption { get; set; } = new Font("Verdana", 9);


    /// <summary>
    /// The property is stored in the file.
    /// </summary>
    
    [JsonProperty]
    public Font FontAlertText { get; set; } = new Font("Verdana", 9);

    /// <summary>
    /// The property is stored in the file.
    /// </summary>

    [JsonProperty]
    public StripViewAlignment StripOrientation { get; set; } = StripViewAlignment.Top;




    /*-----------------------------------------------------------------------------------------------------*/
    public PageViewItemSizeMode ItemSizeMode { get; set; } = PageViewItemSizeMode.EqualHeight; //PageViewItemSizeMode.Individual ;
                                                                                               /*-----------------------------------------------------------------------------------------------------*/

    /// <summary>
    /// The property is stored in the file.
    /// </summary>

    [JsonProperty]
    public int PageViewItemSpacing { get; set; } = 10;
    /*-----------------------------------------------------------------------------------------------------*/





    private Size pageViewItemSize = new Size(100, 27);
    public Size PageViewItemSize
    {
      get => pageViewItemSize;
      set
      {
        bool CheckIsNull = MainForm?.PvMain?.ItemSize == null ? true : false;
        bool ValueIsOK = ((value.Height >= 10) && (value.Width >= 10));

        if (ValueIsOK)
        {
          pageViewItemSize = value;
          if (CheckIsNull == false) MainForm.PvMain.ItemSize = pageViewItemSize;
        }
      }
    }










    private int maxAlertCount = 5;






    /// <summary>
    /// The property is stored in the file.
    /// </summary>

    [JsonProperty]
    public int MaxAlertCount
    {
      get => maxAlertCount;
      set { if ((value > 0) && (value < 11)) maxAlertCount = value; }
    }




    public bool LimitNumberOfAlerts { get; set; } = true;




    private MsgPos defaultAlertPosition = MsgPos.BottomRight;
    public MsgPos DefaultAlertPosition
    {
      get => defaultAlertPosition;
      set { if ((value != MsgPos.Unknown) && (value != MsgPos.ScreenCenter) && (value != MsgPos.Manual)) defaultAlertPosition = value; }
    }





    private int secondsAlertAutoClose = 7;


    /// <summary>
    /// The property is stored in the file.
    /// </summary>

    [JsonProperty]
    public int SecondsAlertAutoClose
    {
      get => secondsAlertAutoClose;
      set { if ((value >= 1) && (value <= 864000)) secondsAlertAutoClose = value; }
    }





    private byte valueColumnWidthPercent = 0;

    /// <summary>
    /// The property is stored in the file.
    /// </summary>

    [JsonProperty]
    public byte ValueColumnWidthPercent
    {
      get => valueColumnWidthPercent;
      set { if ((value <= 90) && (value >= 10)) valueColumnWidthPercent = value; }
    }


    private Padding propertyGridPadding = new Padding(30, 30, 30, 30);
    public Padding PropertyGridPadding
    {
      get => propertyGridPadding;
      set
      {
        if
          (
          (value.Left <= 300) &&
          (value.Left >= 10) &&
          (value.Right <= 300) &&
          (value.Right >= 10) &&
          (value.Top <= 300) &&
          (value.Top >= 10) &&
          (value.Bottom <= 300) &&
          (value.Bottom >= 10)
          )
          propertyGridPadding = value;
      }
    }

    private string headerFormSettings = "Settings";

    public string HeaderFormSettings
    {
      get => headerFormSettings;
      set
      {
        if (!string.IsNullOrWhiteSpace(value)) headerFormSettings = value;
      }
    }







    private string headerFormExit = "Exit";

    public string HeaderFormExit
    {
      get => headerFormExit;
      set
      {
        if (!string.IsNullOrWhiteSpace(value)) headerFormExit = value;
      }
    }







    private string headerFormLog = "Message log";

    public string HeaderFormLog
    {
      get => headerFormLog;
      set
      {
        if (!string.IsNullOrWhiteSpace(value)) headerFormLog = value;
      }
    }









    public string ConfirmExitButtonText { get; set; } = string.Empty;










    /// <summary>
    /// The property is stored in the file.
    /// </summary>

    [JsonProperty]
    public bool MainFormCloseButtonActsAsMinimizeButton { get; set; } = false;

    /// <summary>
    /// The property is stored in the file.
    /// </summary>
    /// 
    [JsonProperty]
    public bool MainFormCloseButtonMustNotCloseForm { get; set; } = false;

    /// <summary>
    /// The property is stored in the file.
    /// </summary>

    [JsonProperty]
    public bool HideMainPageViewBeforeMainFormIsShown { get; set; } = false;





    /// <summary>
    /// The property is stored in the file.
    /// </summary>

    [JsonProperty]
    public bool ConfirmExit { get; set; } = false;


    /// <summary>
    /// The property is stored in the file.
    /// </summary>

    [JsonProperty]
    public bool RememberMainFormLocation { get; set; } = false;

    /// <summary>
    /// The property is stored in the file.
    /// </summary>

    [JsonProperty]
    public bool VisualEffectOnStart { get; set; } = false;

    /// <summary>
    /// The property is stored in the file.
    /// </summary>

    [JsonProperty]
    public bool VisualEffectOnExit { get; set; } = false;

    /// <summary>
    /// The property is stored in the file.
    /// </summary>

    [JsonProperty]
    public Point MainFormLocation { get; set; } = default(Point);

    /// <summary>
    /// The property is stored in the file.
    /// </summary>

    [JsonProperty]
    public Size MainFormSize { get; set; } = default(Size);

    /// <summary>
    /// The property is stored in the file.
    /// </summary>

    [JsonProperty]
    public DateTime TimeCheckOldLogFiles { get; set; } = new DateTime(2022, 1, 1);

    /// <summary>
    /// The property is stored in the file.
    /// </summary>

    [JsonProperty]
    public bool FlagMinimizeMainFormBeforeClosing { get; set; } = true;

    /// <summary>
    /// The property is stored in the file.
    /// </summary>

    [JsonProperty]
    public int StartTimerIntervalMilliseconds { get; set; } = 200;


    /// <summary>
    /// The property is stored in the file.
    /// </summary>

    [JsonProperty]
    public bool FlagMinimizeMainFormToSystemTray { get; set; } = false;


    /// <summary>
    /// The property is stored in the file.
    /// Set value to "true" if your program is a service application, i.e. application must work as a server.
    /// </summary>

    [JsonProperty]
    public bool FlagMainFormStartMinimized { get; set; } = false;










    private void GetMainFormLocation()
    {
      if (MainForm.WindowState != FormWindowState.Normal) return;

      this.MainFormSize = MainForm.Size;
      this.MainFormLocation = MainForm.Location;
    }

    private void CheckErrorFileNamedAsDirectory()
    {
      if (File.Exists(DefaultFolderUserSettings))
        try
        {
          File.Delete(DefaultFolderUserSettings);
        }
        catch (Exception ex)
        {
          string h = $"Could not delete file <<{DefaultFolderUserSettings}>> which prevents to save framework settings";
          FrameworkManager.SaveErrorToTextFile(h, ex);
          //Log.Save(ex, h, MsgType.Error);
          //Ms.Error(h, ex).Pos(MsgPos.BottomRight).Delay(10).Create();
        }
    }

    internal override void Save(string fileName = FrameworkSettingsFileName)
    {
      //if (RememberMainFormLocation == false) return;

      //if (MainForm.WindowState != FormWindowState.Normal) return;

      GetMainFormLocation();

      CheckErrorFileNamedAsDirectory();
      try
      {
        base.Save(fileName);
      }
      catch (Exception ex)
      {
        string h = $"Could not save framework settings file {fileName}";
        FrameworkManager.SaveErrorToTextFile(h, ex);
        //Log.Save(ex, h, MsgType.Error);
        //Ms.Error(h, ex).Pos(MsgPos.BottomRight).Delay(10).Create();
      }
    }








    StandardFrameworkSettings SettingsLoadedFromFile { get; set; }

    internal void LoadFrameworkSettings()
    {
      StandardFrameworkSettings settings = null;

      try
      {
        settings = Load();
        SettingsLoadedFromFile = settings;
      }
      catch (Exception ex)
      {
        string h = "Could not load framework settings.";
        FrameworkManager.SaveErrorToTextFile(h, ex);
        //Log.Save(ex, h, MsgType.Fail);
        //Ms.Error(h, ex).Pos(MsgPos.BottomRight).Delay(10).Create();
      };


      if (settings == null)
        try
        {
          CxTools.CreateDirectoryForFile(FrameworkSettingsFileName);
        }
        catch (Exception ex)
        {
          string h = "Could not create directory for framework settings file.";
          FrameworkManager.SaveErrorToTextFile(h, ex);
          //Log.Save(ex, h, MsgType.Error);
          //Ms.Error(h, ex).Pos(MsgPos.BottomRight).Delay(10).Create();
        }



      RestoreValuesFromFile();
    }
  }
}