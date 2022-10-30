using System;
using Telerik.WinControls.UI;

namespace TmWinForms
{
  public class SubForm
  {
    public RadForm Form { get; }

    public ushort IdForm { get; }

    public Type TypeForm { get; }

    public string TypeName { get; }

    public string UniqueName { get; } = string.Empty;

    public string PageText { get; } = string.Empty;

    public RadPageViewPage Page { get; set; }


    public bool FlagTabEnabled { get; } = true; // Активна или отключена верхушка вкладки //

    public bool FlagTabVisible { get; } = true; // Видима или скрыта верхушка вкладки //


    protected SubForm(ushort idForm, RadForm form, string uniqueName, string pageText, bool enabled, bool visible)
    { 
      Form = form;
      UniqueName = uniqueName;
      PageText = pageText;
      FlagTabEnabled = enabled;
      FlagTabVisible = visible;

      IdForm = idForm;

      TypeForm = form.GetType();
      TypeName = TypeForm.FullName;
    }

    internal static SubForm Create(ushort idForm, RadForm form, string uniqueName, string pageText, bool enabled, bool visible)
    {
      SubForm userForm = new SubForm(idForm, form, uniqueName, pageText, enabled, visible);
      return userForm;
    }

    internal static SubForm Create<T>(ushort idForm, string uniqueName, string pageText, bool enabled, bool visible) where T : RadForm, new()
    {
      T form = new T();      
      return Create(idForm, form, uniqueName, pageText, enabled, visible);
    }












    internal void SetPage(RadPageViewPage page) => Page = page;


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
  }
}