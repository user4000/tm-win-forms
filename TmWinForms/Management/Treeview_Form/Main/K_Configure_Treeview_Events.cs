using System;
using Telerik.WinControls.UI;
using static TmWinForms.FrameworkManager;

namespace TmWinForms
{
  partial class FormTreeview
  {
    bool NodesWereHidden { get; set; } = false;

    internal bool TreeviewIsCollapsed() => Form.PnTreeview.Width < 70;

    internal bool TreeviewIsTooWide() => Form.PnTreeview.Width > TreeviewMaxWidth;

    internal int TreeviewMaxWidth { get => ((3 * MainForm.Width) / 10); }


    internal void SetEvents() // Установить события, связанные с Treeview //
    {
      Form.TvMain.SelectedNodeChanged += new RadTreeView.RadTreeViewEventHandler(EventSelectedNodeChanged);

      Form.TvMain.Click += new EventHandler(EventUserClickedOnTreeview);

      Form.PnTreeview.Resize += new EventHandler(EventPanelTreeviewResize);
    }

    void EventUserClickedOnTreeview(object sender, EventArgs e)
    {
      if (Form.TvMain.Width < 150) Form.PnTreeview.Width = 250;
    }

    void EventPanelTreeviewResize(object sender, EventArgs e)
    {
      if (MainForm.WindowState == System.Windows.Forms.FormWindowState.Minimized) return;

      ShowMainNodes(TreeviewIsCollapsed() == false);

      if (TreeviewIsCollapsed() == false)
      {
        FrameworkSettings.TreeviewPanelWidth = Form.PnTreeview.Width;
      }

      if (TreeviewIsTooWide())
      {
        Form.PnTreeview.Width = TreeviewMaxWidth;
      }
    }

    void ShowMainNodes(bool show)
    {
      if ((show) && (NodesWereHidden == false)) return;
      NodesWereHidden = !show;
      foreach (RadTreeNode node in Form.TvMain.Nodes) node.Visible = show;
    }
  }
}