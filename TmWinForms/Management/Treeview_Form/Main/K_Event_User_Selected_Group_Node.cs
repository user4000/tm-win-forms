using System;
using TmWinForms.Extensions;
using Telerik.WinControls.UI;
using static TmWinForms.FrameworkManager;

namespace TmWinForms
{
  partial class FormTreeview
  {
    void EventUserSelectedGroupNode(RadTreeNode node) // Выбран элемент, который представляет собой группу элементов //
    {
      if ((node.Level > 0) || ((node is CxNode) == false)) return;

      CxNode customNode = node as CxNode;

      if ((customNode == null) || (customNode.MyGroup == null)) return;

      Group group = customNode.ZzGetGroup();

      if (group == null) return;

      if (((group.ExpandOnSelect) || (FrameworkSettings.TreeviewNavigationAlwaysExpandOnSelect)) && (!node.Expanded)) node.Expand();
    }
  }
}