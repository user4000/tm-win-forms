using System;
using System.Drawing;
using Telerik.WinControls;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using TmWinForms.Extensions;
using static TmWinForms.FrameworkManager;

namespace TmWinForms
{
  partial class FormTreeview
  {
    DateTime TimeDockSideChange { get; set; } = new DateTime(2022, 1, 1);

    internal void ChangeTreeviewDockSide()
    {
      var diffInSeconds = Math.Abs((DateTime.Now - TimeDockSideChange).TotalSeconds);
      if (diffInSeconds < 2) return;

      TimeDockSideChange = DateTime.Now;

      DockStyle dock = (Form.PnTreeview.Dock == DockStyle.Right ? DockStyle.Left : DockStyle.Right);
      Form.PnTreeview.Dock = dock;
      Form.SplitterMainVertical.Dock = dock;
    }

    internal void AdjustMainPageviewAndTreeview() // Настроим центральные элементы главной формы //
    {
      bool leftSide = FrameworkSettings.TreeviewIsLocatedOnTheLeftSide;
      DockStyle dock = leftSide ? DockStyle.Left : DockStyle.Right;

      Form.PnTreeview.Dock = dock;
      Form.SplitterMainVertical.Dock = dock;
      Form.PvTreeview.Dock = DockStyle.Fill;
      Form.SplitterMainVertical.BringToFront();
      Form.PvTreeview.BringToFront();
      Form.PnTreeview.ShowBorder(false);

      //PnTreeview.PanelElement.PanelBorder.Visibility = ElementVisibility.Collapsed;

      Form.TvMain.LineColor = Color.FromArgb(180, 180, 180);
      Form.TvMain.LineStyle = TreeLineStyle.Dot;

      //TvMain.Padding = new Padding(10, 5, 5, 5);

      Form.TvMain.ShowExpandCollapse = true;
      Form.PnTreeview.Width = FrameworkSettings.TreeviewPanelWidth;
    }

    internal void AdjustStripViewContainer() // Полосу, отображающую вкладки, нужно скрыть //
    {
      ((StripViewItemContainer)(Form.PvTreeview.GetChildAt(0).GetChildAt(0))).Padding = new Padding(0);
      ((StripViewItemContainer)(Form.PvTreeview.GetChildAt(0).GetChildAt(0))).Visibility = ElementVisibility.Collapsed;
    }
  }
}