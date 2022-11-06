using Telerik.WinControls.UI;

namespace TmWinForms
{
  public class TvManager  // Обеспечивает выбор объекта FormTreeview //
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


    internal void SetTreeviewBackgroundColor()
    {
      foreach (var item in FmService.ListTreeview) item.SetTreeviewBackgroundColor();
    }


    public FormTreeview Select(int indexOfTreeview = 0)
    {
      if (FmService.ListTreeview.Count > indexOfTreeview) return FmService.ListTreeview[indexOfTreeview];
      return null;
    }

    public FormTreeview Select(string uniqueNameOfTreeview)
    {
      foreach (var item in FmService.ListTreeview) if (item.UniqueName == uniqueNameOfTreeview) return item;
      return null;
    }

    public FormTreeview Select(RadForm form)
    {
      //foreach (var item in FmService.ListTreeview) if (item.ContainsForm(form)) return item;

      SubForm subForm = SubForm.GetSubForm(form);
      if ((subForm != null) && (subForm is TvForm))
      {
        return ((subForm as TvForm).Treeview);
      }

      return null;
    }
  }
}