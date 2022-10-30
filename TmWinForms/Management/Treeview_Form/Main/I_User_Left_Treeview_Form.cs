using System;
using System.Threading.Tasks;

namespace TmWinForms
{
  partial class FormTreeview
  {
    public void EventUserLeftTheForm()
    {
      foreach (var item in SubForms)
        if (item.Form is IUserLeftTreeviewForm)
          (item.Form as IUserLeftTreeviewForm).EventUserLeftTreeviewForm();
    }

    public async Task EventUserLeftTheFormAsync()
    {
      foreach (var item in SubForms)
        if (item.Form is IUserLeftTheFormAsync)
          await (item.Form as IUserLeftTheFormAsync).EventUserLeftTheFormAsync();
    }
  }
}