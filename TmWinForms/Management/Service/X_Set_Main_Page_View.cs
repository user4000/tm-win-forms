using System;
using Telerik.WinControls.UI;
using static TmWinForms.FrameworkManager;

namespace TmWinForms
{
  partial class FrameworkService
  {
    internal StripViewAlignment OrientationStripMainPageView { get; private set; } = StripViewAlignment.Top;


    private void SetPageViewStripProperties(RadPageView pageView)
    {
      RadPageViewStripElement element = (RadPageViewStripElement)pageView.GetChildAt(0);

      element.ShowItemPinButton = false;
      element.StripButtons = StripViewButtons.Scroll;      
      element.ItemAlignment = StripViewItemAlignment.Near;
      element.ItemFitMode = StripViewItemFitMode.FillHeight;
      element.ShowItemCloseButton = false;
      element.ItemSpacing = FrameworkSettings.PageViewItemSpacing;


      //element.ItemSizeMode = PageViewItemSizeMode.Individual;
      // If user set orientation before creating of [RadPageView] we can apply this setting now since the object exists //

      SetMainPageViewTabOrientation(OrientationStripMainPageView);
    }

    /// <summary>
    /// Valid argument values = TOP, LEFT, RIGHT, BOTTOM
    /// </summary>
    public void SetMainPageViewTabOrientation(StripViewAlignment StripOrientation)
    {
      PageViewContentOrientation ItemOrienation =
        ((StripOrientation == StripViewAlignment.Left) || (StripOrientation == StripViewAlignment.Right))
        ? PageViewContentOrientation.Horizontal : PageViewContentOrientation.Auto;

      ((RadPageViewStripElement)(MainForm.PvMain.GetChildAt(0))).StripAlignment = StripOrientation;
      ((RadPageViewStripElement)(MainForm.PvMain.GetChildAt(0))).ItemContentOrientation = ItemOrienation;
    }


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