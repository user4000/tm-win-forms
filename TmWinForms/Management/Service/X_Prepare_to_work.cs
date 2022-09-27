using System;
using System.Drawing;
using System.Threading.Tasks;
using Telerik.WinControls.UI;
using System.Collections.Generic;
using System.Diagnostics;

namespace TmWinForms
{
  partial class FrameworkService
  {
    public void PlaceAllSubFormsToMainPageView()
    {
      while ( QueueForms.Count > 0 )
      {
        SubForm subForm = QueueForms.Dequeue();
        AddFormToPage(subForm);
      }

      FlagItIsTimeToAddStandardForms = true;

      CreateFormLog();
      CreateFormSetting();
      CreateFormExit();

      while (QueueForms.Count > 0)
      {
        SubForm subForm = QueueForms.Dequeue();
        AddFormToPage(subForm);
      }

      ExecStartWorkHandlerForEachSubForm();
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