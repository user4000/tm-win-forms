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
  }
}