using System;
using System.Collections.Generic;

namespace TmWinForms
{
  partial class FrameworkService
  {
    void AddFormsFromQueueToPageView()
    {
      while ( QueueForms.Count > 0 )
      {
        SubForm subForm = QueueForms.Dequeue();
        AddFormToPage(subForm);
      }
    }

    public void PlaceAllSubFormsToMainPageView()
    {
      AddFormsFromQueueToPageView(); // Добавляем формы из очереди на Page View //

      FlagItIsTimeToAddStandardForms = true;

      CreateFormSetting(); 
      CreateFormLog();
      CreateFormExit();

      AddFormsFromQueueToPageView(); // Добавляем формы из очереди на Page View //

      // Выполнить событие IStartForm для каждой формы, которая поддерживает этот интерфейс //
      ExecStartWorkHandlerForEachSubForm();

      foreach (var formWithTreeviewElement in ListTreeview) formWithTreeviewElement.SetEvents(); // Установить все события, связанные с Treeview, для форм FxTreeview //
    }

    internal void ExecStartWorkHandlerForEachSubForm()
    {
      foreach (KeyValuePair<string, SubForm> entry in DicForms)
      {
        entry.Value.ExecStartWorkHandler();
      }
    }

    internal void ExecEndWorkHandlerForEachSubForm()
    {
      foreach (KeyValuePair<string, SubForm> entry in DicForms)
        entry.Value.ExecEndWorkHandler();
    }
  }
}