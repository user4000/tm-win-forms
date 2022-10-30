using System;
using System.Threading.Tasks;

namespace TmWinForms
{
  partial class FormTreeview
  {
    public void EventUserVisitedTheForm()
    {
      foreach (var item in SubForms)
        if (item.Form is IUserVisitedTreeviewForm)
          (item.Form as IUserVisitedTreeviewForm).EventUserVisitedTreeviewForm();
    }

    public async Task EventUserVisitedTheFormAsync()
    {
      foreach (var item in SubForms)
        if (item.Form is IUserVisitedTheFormAsync)
          await (item.Form as IUserVisitedTheFormAsync).EventUserVisitedTheFormAsync();
    }
  }
}