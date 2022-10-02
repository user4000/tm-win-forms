using System;
using Telerik.WinControls.UI;
using static TmWinForms.FrameworkManager;

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

      Events.ActionUserLeftPage?.Invoke(page);

      if (Service.DicPages.ContainsKey(page) == false) return;
      if (Service.DicPages.TryGetValue(page, out RadForm form))
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

      Events.ActionUserVisitedPage?.Invoke(page);

      if (Service.DicPages.ContainsKey(page) == false) return;
      if (Service.DicPages.TryGetValue(page, out RadForm form))
      {
        if (form is IUserVisitedTheForm)
        {
          (form as IUserVisitedTheForm).EventUserVisitedTheForm();
        }
      }

      //string test = $"Current page = {GetCurrentPageName()};  Prevoius page = {GetPreviousPageName()}";
      //MainForm.Text = test;
    }

    public string GetCurrentPageText() => CurrentPage == null ? "NULL" : CurrentPage.Text;

    public string GetPreviousPageText() => PreviousPage == null ? "NULL" : PreviousPage.Text;
  }
}