using System;
using Telerik.WinControls.UI;
using System.Threading.Tasks;

namespace TmWinForms
{
  partial class FormTreeview
  {
    void EventUserVisitedTheForm(RadForm form)
    {
      if (form is IUserVisitedTheForm)
      {
        (form as IUserVisitedTheForm).EventUserVisitedTheForm();
      }
    }

    async Task EventUserVisitedTheFormAsync(RadForm form)
    {
      if (form is IUserVisitedTheFormAsync)
      {
        await (form as IUserVisitedTheFormAsync).EventUserVisitedTheFormAsync();
      }
    }  
  }
}