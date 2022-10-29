using System;
using System.Threading.Tasks;
using Telerik.WinControls.UI;
using static TmWinForms.FrameworkManager;

namespace TmWinForms
{
  public partial class PagesManager
  {
    public RadPageViewPage CurrentPage { get; private set; } = null;

    public RadPageViewPage PreviousPage { get; private set; } = null;



    async void EventPageChanged(object sender, EventArgs e)
    {
      PreviousPage = CurrentPage;

      CurrentPage = PvMain.SelectedPage;

      await EventUserLeftThePage(PreviousPage);

      await EventPageChanged(CurrentPage);
    }

    async Task EventUserLeftThePage(RadPageViewPage page)
    {
      if (page == null) return;

      if ((CurrentPage == FrameworkManager.MainForm.PageExit) && (FrameworkSettings.ConfirmExit == false)) return;

      Events.UserLeftPage?.Invoke(page);

      if (Service.DicPages.ContainsKey(page) == false) return;
      if (Service.DicPages.TryGetValue(page, out RadForm form))
      {
        if (form is IUserLeftTheForm)
        {
          (form as IUserLeftTheForm).EventUserLeftTheForm();
        }

        if (form is IUserLeftTheFormAsync)
        {
          await (form as IUserLeftTheFormAsync).EventUserLeftTheFormAsync();
        }
      }
    }

    async Task EventPageChanged(RadPageViewPage page)
    {
      if (page == null) return;

      Events.UserVisitedPage?.Invoke(page);

      if (Service.DicPages.ContainsKey(page) == false) return;
      if (Service.DicPages.TryGetValue(page, out RadForm form))
      {
        if (form is IUserVisitedTheForm)
        {
          (form as IUserVisitedTheForm).EventUserVisitedTheForm();
        }

        if (form is IUserVisitedTheFormAsync)
        {
          await (form as IUserVisitedTheFormAsync).EventUserVisitedTheFormAsync();
        }
      }

      //string test = $"Current page = {GetCurrentPageName()};  Prevoius page = {GetPreviousPageName()}";
      //MainForm.Text = test;
    }

    public string GetCurrentPageText() => CurrentPage == null ? "NULL" : CurrentPage.Text;

    public string GetPreviousPageText() => PreviousPage == null ? "NULL" : PreviousPage.Text;
  }
}