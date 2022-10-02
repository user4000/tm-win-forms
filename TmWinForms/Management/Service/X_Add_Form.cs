using System;
using System.Drawing;
using Telerik.WinControls;
using System.Threading.Tasks;
using Telerik.WinControls.UI;
using System.Collections.Generic;
using static TmWinForms.FrameworkManager;

namespace TmWinForms
{
  partial class FrameworkService
  {
    ushort GetNextIdForm() => IdForm++;

    ushort IdStartForm { get; set; } = 0;

    string CodeStartForm { get; set; } = string.Empty;

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

    public void SetStartForm(string UniqueFormName)
    {
      CodeStartForm = UniqueFormName;
    }

    internal bool GotoStartForm()
    {
      if (IdStartForm == 0) return false;

      bool result = false;

      foreach(var pair in DicForms)
      {
        if (pair.Value.IdForm == IdStartForm)
        {
          MainForm.PvMain.SelectedPage = pair.Value.Page;
          result = true;
          break;
        }
      }

      return result;
    }

    internal bool GotoStartFormUsingStringCode()
    {
      if (string.IsNullOrWhiteSpace(CodeStartForm)) return false;

      bool result = false;

      foreach (var pair in DicForms)
      {
        if (pair.Value.UniqueName == CodeStartForm)
        {
          MainForm.PvMain.SelectedPage = pair.Value.Page;
          result = true;
          break;
        }
      }

      return result;
    }
  }
}