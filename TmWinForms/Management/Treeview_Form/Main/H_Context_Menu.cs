using System;
using System.Drawing;
using System.ComponentModel;
using Telerik.WinControls.UI;
using static TmWinForms.FrameworkManager;

namespace TmWinForms
{
  partial class FormTreeview
  {
    void SetContextMenuForTreeview()
    {
      RadContextMenu menu = new RadContextMenu(Form.TvMain.Container);

      menu.DropDown.Font = Form.TvMain.Font;

      Size minSize = new Size(150, 30);

      RadMenuSeparatorItem separator = new RadMenuSeparatorItem();
      menu.Items.Add(separator);

      RadMenuItem item = new RadMenuItem(FrameworkSettings.TreeviewMenuItemCollapse);
      item.Name = "ItemCollapse";
      menu.Items.Add(item);
      item.MinSize = minSize;
      item.Click += new EventHandler(EventTreeviewCollapse);



      separator = new RadMenuSeparatorItem();
      menu.Items.Add(separator);

      item = new RadMenuItem(FrameworkSettings.TreeviewMenuItemExpand);
      item.Name = "ItemExpand";
      menu.Items.Add(item);
      item.MinSize = minSize;
      item.Click += new EventHandler(EventTreeviewExpand);

      separator = new RadMenuSeparatorItem();
      menu.Items.Add(separator);

      Form.TvMain.RadContextMenu = menu;

      menu.DropDownOpening += new CancelEventHandler(EventTreeviewContextMenuOpening);
    }

    private void EventTreeviewContextMenuOpening(object sender, CancelEventArgs e)
    {
      if (Form.TvMain.Width < 100) e.Cancel = true;
    }

    private void EventTreeviewExpand(object sender, EventArgs e)
    {
      foreach (var node in Form.TvMain.Nodes)
      {
        if (node is CxNode)
        {
          CxNode item = node as CxNode; // Откроем все группы, кроме Exit //
          if (item != null)
          {
            item.Expand();
          }
        }
      }
    }

    private void EventTreeviewCollapse(object sender, EventArgs e)
    {
      foreach (var node in Form.TvMain.Nodes)
      {
        node.Collapse(); // Свернём все группы //
      }
    }
  }
}