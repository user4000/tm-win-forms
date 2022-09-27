using System;
using System.Drawing;
using System.Threading.Tasks;
using Telerik.WinControls.UI;
using System.Collections.Generic;

namespace TmWinForms
{
  partial class FrameworkService
  {
    public void PlaceAllSubFormsToMainPageView()
    {
      while( QueueForms.Count > 0)
      {
        var subForm = QueueForms.Dequeue();
        AddFormToPage(subForm);
      }
    }
  }
}