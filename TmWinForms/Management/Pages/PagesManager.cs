using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.WinControls.UI;

namespace TmWinForms
{
  public partial class PagesManager
  {
    FxMain MainForm { get; set; }

    RadPageView PvMain { get; set; }

    PagesManager()
    {

    }

    internal void Configure(FxMain mainForm)
    {
      MainForm = mainForm;
      PvMain = MainForm.PvMain;
      PvMain.SelectedPageChanged += new EventHandler(EventPageChanged);
    }


    internal static PagesManager Create() => new PagesManager();
  }
}