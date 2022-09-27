using System;
using System.Threading.Tasks;
using Telerik.WinControls.UI;

namespace TmWinForms
{
  internal class SubForm
  {
    RadForm Form { get; set; }

    internal string PageName { get; } = string.Empty;

    internal string PageText { get; } = string.Empty;

    internal bool FlagTabEnabled { get; } = true; // Активна или отключена верхушка вкладки //

    internal bool FlagTabVisible { get; } = true; // Видима или скрыта верхушка вкладки //


    private SubForm(RadForm form, string pageName, string pageText, bool enabled, bool visible)
    { 
      Form = form;
      PageName = pageName;
      PageText = pageText;
      FlagTabEnabled = enabled;
      FlagTabVisible = visible;
    }

    internal static SubForm Create(RadForm form, string pageName, string pageText, bool enabled, bool visible)
    {
      SubForm userForm = new SubForm(form, pageName, pageText, enabled, visible);
      return userForm;
    }

    internal static SubForm Create<T>(string pageName, string pageText, bool enabled, bool visible) where T : RadForm, new()
    {
      T form = new T();      
      return Create(form, pageName, pageText, enabled, visible);
    }


    internal void ExecStartWorkHandler()
    {
      if ((Form != null) && (Form is IStartWork))
      {
        IStartWork form = (IStartWork)Form;
        form.EventStartWork();
      };
    }

    internal void ExecEndWorkHandler()
    {
      if ((Form != null) && (Form is IEndWork))
      {
        IEndWork form = (IEndWork)Form;
        form.EventEndWork();
      };
    }

    internal void Dispose(bool ExecuteEndWorkHandler)
    {
      if (Form != null)
      {
        ExecEndWorkHandler();
        Form.Visible = false;
        Form.Close();
        try { Form.Dispose(); } catch { };
        Form = null;
      }
    }
  }
}