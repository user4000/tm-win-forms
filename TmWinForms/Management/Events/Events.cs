using System;
using System.Threading.Tasks;
using Telerik.WinControls.UI;
using static TmWinForms.FrameworkManager;

namespace TmWinForms
{
  public class UserEvents
  {
    public Action<RadPageViewPage> ActionUserVisitedPage { get; set; }

    public Action<RadPageViewPage> ActionUserLeftPage { get; set; }

    UserEvents()
    {

    }

    public static UserEvents Create() => new UserEvents();
  }
}