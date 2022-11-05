using System;
using System.Collections.Generic;

namespace TmWinForms
{
  public partial class FrameworkService
  {
    internal void ExecStartWorkHandlerForEachSubForm()
    {
      foreach (KeyValuePair<string, SubForm> entry in DicForms) // Цикл по всем формам, располагающимся на страницах главного PageView //
      {
        entry.Value.ExecStartWorkHandler();
      }

      foreach (var formWithTreeviewElement in ListTreeview) // Цикл по всем формам вида FxTreeview //
      {
        formWithTreeviewElement.SetEvents();       // Установить все события, связанные с Treeview, для форм FxTreeview //
        formWithTreeviewElement.SetDefaultPage();
        // Выполнить событие IStartForm для каждой формы (относящейся к Treeview) //
        formWithTreeviewElement.ExecStartWorkHandlerForEachSubForm();
      }
    }

    internal void ExecEndWorkHandlerForEachSubForm()
    {
      foreach (var formWithTreeviewElement in ListTreeview) // Цикл по всем формам вида FxTreeview //
      {
        formWithTreeviewElement.ExecEndWorkHandlerForEachSubForm();
      }

      foreach (KeyValuePair<string, SubForm> entry in DicForms) // Цикл по всем формам, располагающимся на страницах главного PageView //
      {
        entry.Value.ExecEndWorkHandler();
      }
    }
  }
}