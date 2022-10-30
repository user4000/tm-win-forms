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

      
      ExecStartWorkHandlerForEachSubForm(); // Выполнить событие IStartForm для каждой формы //
    }

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