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
  partial class StandardFrameworkSettings
  {

    public bool LimitNumberOfAlerts { get; set; } = true;



    /// <summary>
    /// The property is stored in the file.
    /// </summary>

    [JsonProperty(Order = 10)]
    public Font FontAlertCaption { get; set; } = new Font("Verdana", 9);



    /// <summary>
    /// The property is stored in the file.
    /// </summary>

    [JsonProperty(Order = 10)]
    public Font FontAlertText { get; set; } = new Font("Verdana", 9);










    private int maxAlertCount = 5;

    /// <summary>
    /// The property is stored in the file.
    /// </summary>

    [JsonProperty(Order = 20)]
    public int MaxAlertCount
    {
      get => maxAlertCount;
      set { if ((value > 0) && (value < 11)) maxAlertCount = value; }
    }




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

    [JsonProperty(Order = 25)]
    public int SecondsAlertAutoClose
    {
      get => secondsAlertAutoClose;
      set { if ((value >= 1) && (value <= 864000)) secondsAlertAutoClose = value; }
    }
  }
}