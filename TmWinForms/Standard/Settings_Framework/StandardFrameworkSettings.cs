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
    StandardFrameworkSettings SettingsLoadedFromFile { get; set; }






    private int tabMinWidth = 100;

    /// <summary>
    /// The property is stored in the file.
    /// </summary>

    [JsonProperty(Order = 1)]
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






    private Font pageViewFont = new Font("Verdana", 9, FontStyle.Regular);

    /// <summary>
    /// The property is stored in the file.
    /// </summary>

    [JsonProperty(Order = 2)]
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

    [JsonProperty(Order = 10)]
    public StripViewAlignment StripOrientation { get; set; } = StripViewAlignment.Top;




    public PageViewItemSizeMode ItemSizeMode { get; set; } = PageViewItemSizeMode.EqualHeight; //PageViewItemSizeMode.Individual ;



    /// <summary>
    /// The property is stored in the file.
    /// </summary>

    [JsonProperty(Order = 15)]
    public int PageViewItemSpacing { get; set; } = 10;












    private byte valueColumnWidthPercent = 50;

    /// <summary>
    /// The property is stored in the file.
    /// </summary>

    [JsonProperty(Order = 80)]
    public byte ValueColumnWidthPercent
    {
      get => valueColumnWidthPercent;
      set { if ((value <= 90) && (value >= 10)) valueColumnWidthPercent = value; }
    }






















    public string ConfirmExitButtonText { get; set; } = string.Empty;







    /// <summary>
    /// The property is stored in the file.
    /// </summary>

    [JsonProperty(Order = 50)]

    public string MainFormCaption { get; set; } = string.Empty; 




    /// <summary>
    /// The property is stored in the file.
    /// </summary>

    [JsonProperty(Order = 70)]

    public string ThemeName { get; set; } = string.Empty; // Если пользователь задаст это значение, то фреймворк постарается найти и применить данную тему //






    /// <summary>
    /// The property is stored in the file.
    /// </summary>

    [JsonProperty(Order = 90)]
    public bool MainFormCloseButtonActsAsMinimizeButton { get; set; } = false;

    /// <summary>
    /// The property is stored in the file.
    /// </summary>

    [JsonProperty(Order = 90)]
    public bool MainFormCloseButtonMustNotCloseForm { get; set; } = false;

    /// <summary>
    /// The property is stored in the file.
    /// </summary>

    [JsonProperty(Order = 25)]
    public bool HideMainPageViewBeforeMainFormIsShown { get; set; } = false;





    /// <summary>
    /// The property is stored in the file.
    /// </summary>

    [JsonProperty(Order = 75)]
    public bool ConfirmExit { get; set; } = false;


    /// <summary>
    /// The property is stored in the file.
    /// </summary>

    [JsonProperty(Order = 5)]
    public bool RememberMainFormLocation { get; set; } = false;

    /// <summary>
    /// The property is stored in the file.
    /// </summary>

    [JsonProperty(Order = 95)]
    public bool VisualEffectOnStart { get; set; } = false;

    /// <summary>
    /// The property is stored in the file.
    /// </summary>

    [JsonProperty(Order = 95)]
    public bool VisualEffectOnExit { get; set; } = false;

    /// <summary>
    /// The property is stored in the file.
    /// </summary>

    [JsonProperty(Order = 1)]
    public Point MainFormLocation { get; set; } = default(Point);

    /// <summary>
    /// The property is stored in the file.
    /// </summary>

    [JsonProperty(Order = 1)]
    public Size MainFormSize { get; set; } = default(Size);

    /// <summary>
    /// The property is stored in the file.
    /// </summary>

    [JsonProperty(Order = 35)]
    public DateTime TimeCheckOldLogFiles { get; set; } = new DateTime(2022, 1, 1);

    /// <summary>
    /// The property is stored in the file.
    /// </summary>

    [JsonProperty(Order = 96)]
    public bool FlagMinimizeMainFormBeforeClosing { get; set; } = true;

    /// <summary>
    /// The property is stored in the file.
    /// </summary>

    [JsonProperty(Order = 50)]
    public int StartTimerIntervalMilliseconds { get; set; } = 200;


    /// <summary>
    /// The property is stored in the file.
    /// </summary>
 
    [JsonProperty(Order = 51)]
    public int StartTimerAsyncIntervalMilliseconds { get; set; } = 2000;







    /// <summary>
    /// The property is stored in the file.
    /// </summary>

    [JsonProperty(Order = 99)]
    public bool FlagMinimizeMainFormToSystemTray { get; set; } = false;


    /// <summary>
    /// The property is stored in the file.
    /// Set value to "true" if your program is a service application, i.e. application must work as a server.
    /// </summary>

    [JsonProperty(Order = 100)]
    public bool FlagMainFormStartMinimized { get; set; } = false;




  }
}