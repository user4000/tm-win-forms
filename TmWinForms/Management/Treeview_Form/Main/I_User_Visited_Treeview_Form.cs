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
        if (item.Form is IUserVisitedTreeviewFormAsync)
          await (item.Form as IUserVisitedTreeviewFormAsync).EventUserVisitedTreeviewFormAsync();
    }
  }
}