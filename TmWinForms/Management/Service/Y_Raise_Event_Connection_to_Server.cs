using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TmWinForms
{
  public partial class FrameworkService
  {
    bool ConnectedToServerFirstTime { get; set; } = true;

    bool ConnectedToServerFirstTimeAsync { get; set; } = true;


    public void RaiseEventConnection(bool connected, string text, object arg)
    {
      foreach (KeyValuePair<string, SubForm> entry in DicForms) // Цикл по всем формам, располагающимся на страницах главного PageView //
      {
        entry.Value.RaiseEventConnection(connected, ConnectedToServerFirstTime, text, arg);
      }

      foreach (var formWithTreeviewElement in ListTreeview) // Цикл по всем формам вида FxTreeview //
      {
        // Выполнить событие для каждой формы (относящейся к Treeview) //
        formWithTreeviewElement.RaiseEventConnection(connected, ConnectedToServerFirstTime, text, arg);
      }

      if ((connected) && (ConnectedToServerFirstTime))
      {
        ConnectedToServerFirstTime = false;
      }
    }

    public async Task RaiseEventConnectionAsync(bool connected, string text, object arg)
    {
      foreach (KeyValuePair<string, SubForm> entry in DicForms) // Цикл по всем формам, располагающимся на страницах главного PageView //
      {
        await entry.Value.RaiseEventConnectionAsync(connected, ConnectedToServerFirstTimeAsync, text, arg);
      }

      foreach (var formWithTreeviewElement in ListTreeview) // Цикл по всем формам вида FxTreeview //
      {
        // Выполнить событие для каждой формы (относящейся к Treeview) //
        await formWithTreeviewElement.RaiseEventConnectionAsync(connected, ConnectedToServerFirstTimeAsync, text, arg);
      }

      if ((connected) && (ConnectedToServerFirstTimeAsync))
      {
        ConnectedToServerFirstTimeAsync = false;
      }
    }
  }
}