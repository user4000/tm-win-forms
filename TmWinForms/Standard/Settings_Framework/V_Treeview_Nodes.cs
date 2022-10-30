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
    /// <summary>
    /// If this option is enabled, then regardless of the group settings, the tree element will expand.
    /// The property is stored in the file.
    /// </summary>
    [JsonProperty(Order = 28)]
    public bool TreeviewNavigationAlwaysExpandOnSelect { get; set; } = false;



    /// <summary>
    /// The property is stored in the file.
    /// </summary>
    [JsonProperty(Order = 30)]
    public int TreeviewPanelWidth { get; set; } = 250;



    /// <summary>
    /// The property is stored in the file.
    /// </summary>
    [JsonProperty(Order = 29)]
    public bool TreeviewEnableHotTracking { get; set; } = false;




    /// <summary>
    /// The property is stored in the file.
    /// </summary>
    [JsonProperty(Order = 35)]
    public bool AllowLoadingImagesForTreeviewFromFiles { get; set; } = false;




    /// <summary>
    /// The property is stored in the file.
    /// </summary>
    [JsonProperty(Order = 45)]
    public Color? ColorTreeviewBackground { get; set; } = null;



    /// <summary>
    /// The property is stored in the file.
    /// </summary>
    [JsonProperty(Order = 46)]
    public bool TreeviewIsLocatedOnTheLeftSide { get; set; } = true;











    public string TreeviewMenuItemExpand { get; set; } = "Expand";

    public string TreeviewMenuItemCollapse { get; set; } = "Collapse";


    /// <summary>
    /// The property is stored in the file.
    /// </summary>
    [JsonProperty(Order = 53)]
    public Font FontTreeviewGroupNode { get; set; } = null;


    /// <summary>
    /// The property is stored in the file.
    /// </summary>
    [JsonProperty(Order = 53)]
    public Font FontTreeviewSubFormNode { get; set; } = null;


    /// <summary>
    /// The property is stored in the file.
    /// </summary>

    [JsonProperty(Order = 51)]
    public Color ColorTreeviewGroupNode { get; set; } = Color.Black;


    /// <summary>
    /// The property is stored in the file.
    /// </summary>

    [JsonProperty(Order = 51)]
    public Color ColorTreeviewSubFormNode { get; set; } = Color.Black;


    /// <summary>
    /// The property is stored in the file.
    /// </summary>

    [JsonProperty(Order = 51)]
    public Color ColorTreeviewGroupNodeDisabled { get; set; } = Color.Gray;


    /// <summary>
    /// The property is stored in the file.
    /// </summary>

    [JsonProperty(Order = 51)]
    public Color ColorTreeviewSubFormNodeDisabled { get; set; } = Color.Gray;

  }
}