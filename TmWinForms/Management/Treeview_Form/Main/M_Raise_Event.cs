using System.Threading.Tasks;

namespace TmWinForms
{
  partial class FormTreeview
  {
    internal void RaiseEventLocalization(IFormLocalizer localizer)
    {
      foreach (var item in SubForms)
        if ((item.Form != null) && (item.Form is INeedLocalization))
        {
          localizer.Localization(item.Form);
        }
    }

    internal void RaiseEventUserForm(bool flag, string text, object arg)
    {
      foreach (var item in SubForms)
        if (item.Form is IEventUserForm)
        {
          (item.Form as IEventUserForm).EventUserForm(flag, text, arg);
        }
    }

    internal async Task RaiseEventUserFormAsync(bool flag, string text, object arg)
    {
      foreach (var item in SubForms)
        if (item.Form is IEventUserFormAsync)
        {
          await ((item.Form as IEventUserFormAsync).EventUserFormAsync(flag, text, arg));
        }
    }

    internal void RaiseEventConnection(bool connected, bool connectedFirstTime, string text, object arg)
    {
      foreach (var item in SubForms)
        if (item.Form is IConnection)
        {
          (item.Form as IConnection).EventConnected(connected, connectedFirstTime, text, arg);
        }
    }

    internal async Task RaiseEventConnectionAsync(bool connected, bool connectedFirstTime, string text, object arg)
    {
      foreach (var item in SubForms)
        if (item.Form is IConnectionAsync)
        {
          await ((item.Form as IConnectionAsync).EventConnectedAsync(connected, connectedFirstTime, text, arg));
        }
    }
  }
}