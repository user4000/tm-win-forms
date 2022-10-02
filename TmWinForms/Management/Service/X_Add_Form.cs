using System;
using System.Drawing;
using System.Threading.Tasks;
using Telerik.WinControls.UI;
using System.Collections.Generic;
using Telerik.WinControls;

namespace TmWinForms
{
  partial class FrameworkService
  {
    ushort GetNextIdForm() => IdForm++;

    ushort IdStartForm { get; set; } = 0;

    HashSet<string> HsUniqueNames { get; } = new HashSet<string>();


    bool CheckNameIsUnique(string name)
    {
      bool result = false;

      if (HsUniqueNames.Contains(name))
      {
        RadMessageBox.Show($"Form name [{name}] is not unique !", "ERROR ! ", System.Windows.Forms.MessageBoxButtons.OK, RadMessageIcon.Error);
      }
      else
      {
        HsUniqueNames.Add(name);
        result = true;
      }

      if (string.IsNullOrWhiteSpace(name))
      {
        result = false;
        RadMessageBox.Show($"Form name is empty !", "ERROR ! ", System.Windows.Forms.MessageBoxButtons.OK, RadMessageIcon.Error);
      }

      return result;
    }


    public ushort AddForm(RadForm form, string uniqueName, string pageText, bool tabEnabled, bool tabVisible) // Добавление формы в очередь //
    {
      ushort id = GetNextIdForm();

      if (string.IsNullOrWhiteSpace(uniqueName)) uniqueName = form.GetType().FullName + "-" + id.ToString();

      if ( CheckNameIsUnique(uniqueName) == false) return 0;

      SubForm subForm = SubForm.Create(id, form, uniqueName, pageText, tabEnabled, tabVisible);

      QueueForms.Enqueue(subForm);

      return id;
    }

    public ushort AddForm<T>(string uniqueName, string pageText, bool tabEnabled, bool tabVisible) where T : RadForm, new() // Добавление формы в очередь //
    {
      ushort id = GetNextIdForm();

      if (string.IsNullOrWhiteSpace(uniqueName)) uniqueName = typeof(T).GetType().FullName + "-" + id.ToString();

      if (CheckNameIsUnique(uniqueName) == false) return 0;

      SubForm subForm = SubForm.Create<T>(id, uniqueName, pageText, tabEnabled, tabVisible);

      QueueForms.Enqueue(subForm);

      return id;
    }

    public void SetStartForm(ushort id)
    {
      IdStartForm = id;
    }

    internal void GotoStartForm()
    {
      if (IdStartForm == 0) return;
      foreach(var pair in DicForms)
      {
        if (pair.Value.IdForm == IdStartForm)
        {
          MainForm.PvMain.SelectedPage = pair.Value.Page;
          break;
        }
      }
    }
  }
}