using Telerik.WinControls.UI;

namespace TmWinForms.Extensions
{
  public static class XxRadForm
  {
    public static FormTreeview ZzTreeview(this RadForm form)
    {
      return FrameworkManager.TvNodes.Select(form);
    }
  }
}