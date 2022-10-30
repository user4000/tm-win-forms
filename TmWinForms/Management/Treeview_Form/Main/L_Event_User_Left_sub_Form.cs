using System;
using Telerik.WinControls.UI;
using System.Threading.Tasks;

namespace TmWinForms
{
  partial class FormTreeview
  {
    async Task EventUserLeftNode(RadForm form)
    {
      if (form == null) return;

      EventUserLeftTheForm(form);

      await EventUserLeftTheFormAsync(form);
    }

    void EventUserLeftTheForm(RadForm form)
    {
      if (form is IUserLeftTheForm)
      {
        (form as IUserLeftTheForm).EventUserLeftTheForm();
      }
    }

    async Task EventUserLeftTheFormAsync(RadForm form)
    {
      if (form is IUserLeftTheFormAsync)
      {
        await (form as IUserLeftTheFormAsync).EventUserLeftTheFormAsync();
      }
    }
  }
}