using System;
using TmWinForms.Extensions;
using Telerik.WinControls.UI;

namespace TmWinForms
{
  partial class FormTreeview
  {
    void EventUserLeftNode(RadTreeNode nodePrevious, RadTreeNode nodeCurrent) // Событие: Пользователь покинул элемент Treeview //
    {
      Group groupPrevious = nodePrevious.ZzGetGroup();

      if (groupPrevious == null) return;

      Group groupCurrent = nodeCurrent.ZzGetGroup();

      RadTreeNode parentPrevious = nodePrevious.Level == 0 ? nodePrevious : nodePrevious.Parent;

      if (parentPrevious == null) return;

      RadTreeNode parentCurrent = nodeCurrent.Level == 0 ? nodeCurrent : nodeCurrent.Parent;

      if (parentCurrent == null) return;

      if ((parentPrevious != parentCurrent) && (groupPrevious.CollapseOnExit))
      {
        parentPrevious.Collapse();
      }
    }
  }
}