using System;
using System.Drawing;
using Telerik.WinControls;
using System.Windows.Forms;
using TmWinForms.Extensions;
using Telerik.WinControls.UI;
using System.Threading.Tasks;

namespace TmWinForms
{
  partial class FormTreeview
  {
    void GotoEmptyPage() => Form.PvTreeview.SelectedPage = Form.PageEmpty;

    public RadTreeNode CurrentNode { get; private set; }

    public RadTreeNode PreviousNode { get; private set; }


    async void EventSelectedNodeChanged(object sender, RadTreeViewEventArgs e)
    {
      PreviousNode = CurrentNode;

      CurrentNode = e.Node;

      EventUserLeftNode(PreviousNode, CurrentNode); // Событие: Пользователь покинул элемент Treeview //

      if (e.Node == null) return;

      //Trace.WriteLine($"EventSelectedNodeChanged ---- {CurrentNode.Text} ---- {CurrentNode.Level}");

      if ((e.Node.Level == 0))    // Выбран элемент, который представляет собой группу элементов //
      {
        EventUserSelectedGroupNode(e.Node);
        GotoEmptyPage();
        return;
      }

      //if (Form.TvMain.HotTracking) Form.TvMain.HotTracking = false;

      TvForm subForm = e.Node.ZzGetSubForm(); // Попробуем узнать, какая форма соответствует данному элементу //

      if (subForm == null)
      {
        GotoEmptyPage();
        return;
      }

      if (subForm.Page != null)
      {
        if (subForm.Form.Visible == false) subForm.Form.Show();

        await Task.Delay(10);

        Form.PvTreeview.SelectedPage = subForm.Page;
      }
      else
      {
        GotoEmptyPage();
      }
    }
  }
}