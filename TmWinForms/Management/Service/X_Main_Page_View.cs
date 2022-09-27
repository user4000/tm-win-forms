using System;
using System.Threading.Tasks;
using Telerik.WinControls.UI;

namespace TmWinForms
{
  partial class FrameworkService
  {
    /// <summary>
    /// Valid argument values = TOP, LEFT, RIGHT, BOTTOM
    /// </summary>
    public void SetPageViewOrientation(StripViewAlignment StripOrientation)
    {
      PageViewContentOrientation ItemOrienation =
        ((StripOrientation == StripViewAlignment.Left) || (StripOrientation == StripViewAlignment.Right))
        ? PageViewContentOrientation.Horizontal : PageViewContentOrientation.Auto;

      ((RadPageViewStripElement)(MainForm.PvMain.GetChildAt(0))).StripAlignment = StripOrientation;
      ((RadPageViewStripElement)(MainForm.PvMain.GetChildAt(0))).ItemContentOrientation = ItemOrienation;
    }
  }
}