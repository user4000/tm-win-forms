using System;
using System.Diagnostics;
using Telerik.WinControls.UI;

namespace TmWinForms
{
  partial class FrameworkService
  {
    bool SelectPage(RadPageViewPage page)
    {
      if (page == MainForm.PageExit) return false;
      MainForm.PvMain.SelectedPage = page;
      return true;
    }

    /// <summary>
    /// Setting the form to be selected after the application starts
    /// </summary>
    
    public void SetStartForm(ushort id)
    {
      IdStartForm = id;
      if (FormExists(id) == false)
      {
        Trace.WriteLine($"[TmWinForms] framework: Warning! There is no form with id = {id}");
      }
    }

    
    /// <summary>
    /// Setting the form to be selected after the application starts
    /// </summary>

    public void SetStartForm(string UniqueFormName)
    {
      CodeStartForm = UniqueFormName;
      if (FormExists(UniqueFormName) == false)
      {
        Trace.WriteLine($"[TmWinForms] framework: Warning! There is no form with unique form name = {UniqueFormName}");
      }
    }

    internal void GotoStartForm() // Перейти на стартовую форму (если, конечно, такая форма была задана программистом) //
    {
      bool startForm = this.GotoStartFormInner();
      if (startForm == false) this.GotoStartFormUsingStringCode();
    }

    bool GotoStartFormInner()
    {
      if (IdStartForm == 0) return false;

      bool result = false;

      foreach (var pair in DicForms)
      {
        if (pair.Value.IdForm == IdStartForm)
        {
          result = SelectPage(pair.Value.Page);
          break;
        }
      }

      return result;
    }

    bool GotoStartFormUsingStringCode()
    {
      if (string.IsNullOrWhiteSpace(CodeStartForm)) return false;

      bool result = false;

      foreach (var pair in DicForms)
      {
        if (pair.Value.UniqueName == CodeStartForm)
        {
          result = SelectPage(pair.Value.Page);
          break;
        }
      }

      return result;
    }
  }
}