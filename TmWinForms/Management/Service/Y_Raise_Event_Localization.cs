using System;
using System.Collections.Generic;

namespace TmWinForms
{
  public partial class FrameworkService
  {
    bool LocalizationHasBeenExecuted { get; set; } = false;

    public void RaiseEventLocalization(IFormLocalizer localizer, bool runOnlyOnce = true)
    {
      if ((LocalizationHasBeenExecuted) && (runOnlyOnce)) return;

      LocalizationHasBeenExecuted = true;

      foreach (KeyValuePair<string, SubForm> entry in DicForms) // Цикл по всем формам, располагающимся на страницах главного PageView //
      {
        if (entry.Value.Form is INeedLocalization) localizer.Localization(entry.Value.Form);
      }

      foreach (var formWithTreeviewElement in ListTreeview) // Цикл по всем формам вида FxTreeview //
      {
        // Выполнить событие для каждой формы (относящейся к Treeview) //
        formWithTreeviewElement.RaiseEventLocalization(localizer);
      }
    }
  }
}