using System;
using System.Text;
using System.Threading.Tasks;
using Telerik.WinControls.UI;

namespace TmWinForms
{
  public partial class PagesManager
  {
    public RadPageViewPage CurrentPage { get; private set; } = null;

    public RadPageViewPage PreviousPage { get; private set; } = null;

    void EventPageChanged(object sender, EventArgs e)
    {
      PreviousPage = CurrentPage;

      EventUserLeftThePage(PreviousPage);

      CurrentPage = PvMain.SelectedPage;

      EventPageChanged(CurrentPage);
    }

    void EventUserLeftThePage(RadPageViewPage page)
    {
      if (page == null) return;
      if (FrameworkManager.Service.DicPages.ContainsKey(page) == false) return;
      if (FrameworkManager.Service.DicPages.TryGetValue(page, out RadForm form))
      {
        if (form is IUserLeftTheForm)
        {
          (form as IUserLeftTheForm).EventUserLeftTheForm();
        }
      }
    }

    void EventPageChanged(RadPageViewPage page)
    {
      if (page == null) return;
      if (FrameworkManager.Service.DicPages.ContainsKey(page) == false) return;
      if (FrameworkManager.Service.DicPages.TryGetValue(page, out RadForm form))
      {
        if (form is IUserVisitedTheForm)
        {
          (form as IUserVisitedTheForm).EventUserVisitedTheForm();
        }
      }
    }
  }
}