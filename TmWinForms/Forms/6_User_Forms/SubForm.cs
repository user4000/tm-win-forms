using System;
using System.Threading.Tasks;
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
      userForm.RadFormMustSaveReferenceToSubForm(form);
      return userForm;
    }

    internal static SubForm Create<T>(ushort idForm, string uniqueName, string pageText, bool enabled, bool visible) where T : RadForm, new()
    {
      T form = new T();      
      return Create(idForm, form, uniqueName, pageText, enabled, visible);
    }


    internal void RadFormMustSaveReferenceToSubForm(RadForm form)
    {
      form.RootElement.Tag = this;
    }


    internal static SubForm GetSubForm(RadForm form)
    {
      if ((form.RootElement.Tag != null) && (form.RootElement.Tag is SubForm)) return (form.RootElement.Tag as SubForm);
      return null;
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




    internal void RaiseEventUserForm(bool flag, string text, object arg)
    {
      if ((Form != null) && (Form is IEventUserForm))
      {
        IEventUserForm form = (IEventUserForm)Form;
        form.EventUserForm(flag, text, arg);
      };
    }

    internal async Task RaiseEventUserFormAsync(bool flag, string text, object arg)
    {
      if ((Form != null) && (Form is IEventUserFormAsync))
      {
        IEventUserFormAsync form = (IEventUserFormAsync)Form;
        await form.EventUserFormAsync(flag, text, arg);
      };
    }


    internal void RaiseEventConnection(bool connected, bool connectedFirstTime, string text, object arg)
    {
      if ((Form != null) && (Form is IConnection))
      {
        IConnection form = (IConnection)Form;
        form.EventConnected(connected, connectedFirstTime, text, arg);
      };
    }

    internal async Task RaiseEventConnectionAsync(bool connected, bool connectedFirstTime, string text, object arg)
    {
      if ((Form != null) && (Form is IConnectionAsync))
      {
        IConnectionAsync form = (IConnectionAsync)Form;
        await form.EventConnectedAsync(connected, connectedFirstTime, text, arg);
      };
    }
  }
}