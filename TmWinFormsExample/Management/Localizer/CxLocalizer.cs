using System.Windows.Forms;
using Telerik.WinControls.UI;
using TmWinForms;

namespace TmWinFormsExample
{
  public class CxLocalizer : IFormLocalizer
  {
    public void Localization(RadForm form)
    {
      foreach(Control control in form.Controls)
      {
        control.Text = "test " + control.Text;
      }    
    }
  }
}