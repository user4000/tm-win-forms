using System;
using Telerik.WinControls.UI;

namespace TmWinForms
{
  public class TvForm : SubForm
  {
    public RadTreeNode NodeForm { get; private set; }

    public RadTreeNode NodeGroup { get; private set; }

    public Group FormGroup { get; private set; }

    public bool FlagNodeEnabled { get; } = true;

    public bool FlagNodeVisible { get; } = true; 


    protected TvForm(ushort idForm, Group group, RadForm form, string uniqueName, string pageText, bool enabled, bool visible)
     : base(idForm,  form, uniqueName, pageText, enabled, visible)
    {
      FormGroup = group;
    }

    internal static TvForm CreateForm(ushort idForm, Group group, RadForm form, string uniqueName, string pageText, bool enabled, bool visible)
    {
      TvForm userForm = new TvForm(idForm, group, form, uniqueName, pageText, enabled, visible);
      return userForm;
    }

    internal static TvForm CreateForm<T>(ushort idForm, Group group, string uniqueName, string pageText, bool enabled, bool visible) where T : RadForm, new()
    {
      T form = new T();
      return CreateForm(idForm, group, form, uniqueName, pageText, enabled, visible);
    }



    internal void SetNodeForm(RadTreeNode node) => NodeForm = node;

    internal void SetNodeGroup(RadTreeNode node) => NodeGroup = node;

  }
}