using Telerik.WinControls.UI;

namespace TmWinForms
{
  public class TvManager
  {
    FxMain MainForm { get; set; }

    FrameworkService FmService { get; set; }

    FormTreeview Empty { get; set; }

    TvManager()
    {

    }

    internal void Configure(FxMain mainForm, FrameworkService service)
    {
      MainForm = mainForm;
      FmService = service;
      //Empty = FormTreeview.Create("empty object", "no text", true, true);
    }

    internal static TvManager Create() => new TvManager();


    public FormTreeview Select(int index = 0)
    {
      if (FmService.ListTreeview.Count > index) return FmService.ListTreeview[index];
      return null;
    }

    public FormTreeview Select(string uniqueName)
    {
      foreach (var item in FmService.ListTreeview) if (item.UniqueName == uniqueName) return item;
      return null;
    }

    public FormTreeview Select(RadForm form)
    {
      foreach (var item in FmService.ListTreeview) if (item.ContainsForm(form)) return item;
      return null;
    }

    internal void SetTreeviewBackgroundColor()
    {
      foreach (var item in FmService.ListTreeview) item.SetTreeviewBackgroundColor();
    }
  }
}