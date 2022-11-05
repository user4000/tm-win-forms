using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TmWinForms
{
  public partial class FrameworkService
  {
    public void RaiseEventUserForm(bool flag, string text, object arg)
    {
      foreach (KeyValuePair<string, SubForm> entry in DicForms) // Цикл по всем формам, располагающимся на страницах главного PageView //
      {
        entry.Value.RaiseEventUserForm(flag, text, arg);
      }

      foreach (var formWithTreeviewElement in ListTreeview) // Цикл по всем формам вида FxTreeview //
      {
        // Выполнить событие для каждой формы (относящейся к Treeview) //
        formWithTreeviewElement.RaiseEventUserForm(flag, text, arg);
      }
    }

    public async Task RaiseEventUserFormAsync(bool flag, string text, object arg)
    {
      foreach (KeyValuePair<string, SubForm> entry in DicForms) // Цикл по всем формам, располагающимся на страницах главного PageView //
      {
        await entry.Value.RaiseEventUserFormAsync(flag, text, arg);
      }

      foreach (var formWithTreeviewElement in ListTreeview) // Цикл по всем формам вида FxTreeview //
      {
        // Выполнить событие для каждой формы (относящейся к Treeview) //
        await formWithTreeviewElement.RaiseEventUserFormAsync(flag, text, arg);
      }
    }
  }
}