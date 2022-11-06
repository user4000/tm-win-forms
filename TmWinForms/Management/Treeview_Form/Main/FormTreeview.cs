using System;
using Telerik.WinControls.UI;
using System.Collections.Generic;
using static TmWinForms.FrameworkManager;

namespace TmWinForms
{
  public partial class FormTreeview : IUserVisitedTheForm, IUserVisitedTheFormAsync, IUserLeftTheForm, IUserLeftTheFormAsync
  {
    List<Group> Groups { get; } = new List<Group>();

    List<TvForm> SubForms { get; } = new List<TvForm>();

    HashSet<string> GroupCodes { get; } = new HashSet<string>();

    ushort IdFormTreeview { get; set; } = 0;

    FxTreeview Form { get; } = new FxTreeview();

    int RankGroup { get; set; } = 1001;

    Group LastCreatedGroup { get; set; }

    #region FxTreeview properties
    public string UniqueName { get; }

    string PageText { get; }

    bool TabEnabled { get; }

    bool TabVisible { get; }

    #endregion

    FormTreeview()
    {

    }

    FormTreeview(string uniqueName, string pageText, bool tabEnabled, bool tabVisible)
    {
      UniqueName = uniqueName;
      PageText = pageText;
      TabEnabled = tabEnabled;
      TabVisible = tabVisible;
    }

    public static FormTreeview Create(string uniqueName, string pageText, bool tabEnabled, bool tabVisible)
    {
      FormTreeview formTreeview = new FormTreeview(uniqueName, pageText, tabEnabled, tabVisible);

      formTreeview.Form.Configure(formTreeview);

      formTreeview.IdFormTreeview = Service.AddForm(formTreeview.Form, uniqueName, pageText, tabEnabled, tabVisible);

      formTreeview.AdjustMainPageviewAndTreeview();

      formTreeview.AdjustStripViewContainer();

      formTreeview.SetContextMenuForTreeview();

      Service.ListTreeview.Add(formTreeview);

      return formTreeview;
    }

    public FormTreeview AddGroup(string code, string text, bool expandOnSelect, bool collapseOnExit)
    {
      if (GroupCodes.Contains(code))
      {
        Error("Error !", $"Group code is not unique! Code = {code}");
      }

      LastCreatedGroup = Group.Create(code, text, (RankGroup++).ToString(), expandOnSelect, collapseOnExit);

      Groups.Add(LastCreatedGroup);

      GroupCodes.Add(code);

      AddGroupNode(LastCreatedGroup);

      return this;
    }

    public FormTreeview AddForm(RadForm form, string uniqueName, string pageText, bool enabled, bool visible)
    {
      if (LastCreatedGroup == null) return this;

      TvForm subForm = TvForm.CreateForm(Service.GetNextIdForm(), this, LastCreatedGroup, form, uniqueName, pageText, enabled, visible);

      SubForms.Add(subForm);

      AddFormNode(subForm);

      return this;
    }

    public FormTreeview AddForm<T>(string uniqueName, string pageText, bool enabled, bool visible) where T : RadForm, new()
    {
      if (LastCreatedGroup == null) return this;

      T form = new T();

      TvForm subForm = TvForm.CreateForm(Service.GetNextIdForm(), this, LastCreatedGroup, form, uniqueName, pageText, enabled, visible);

      SubForms.Add(subForm);

      AddFormNode(subForm);

      return this;
    }

    internal void SetTreeviewBackgroundColor()
    {
      Form.TvMain.TreeViewElement.BackColor = FrameworkSettings.ColorTreeviewBackground ?? Form.BackColor; // Form.SplitterMainVertical.BackColor;
    }



    internal void ExecStartWorkHandlerForEachSubForm()
    {
      foreach (var item in SubForms)
        if (item.Form is IStartWork)
        {
          (item.Form as IStartWork).EventStartWork();
        }
    }

    internal void ExecEndWorkHandlerForEachSubForm()
    {
      foreach (var item in SubForms)
        if (item.Form is IEndWork)
        {
          (item.Form as IEndWork).EventEndWork();
        }
    }

    public bool ContainsForm(RadForm form)
    {
      foreach (var item in SubForms) if (item.Form == form) return true;
      return false;
    }

    public Group GetGroup(string uniqueCode)
    {
      foreach (var group in Groups)
        if (group.Code == uniqueCode) return group;
      return null;
    }

    public void EnableGroup(string uniqueCode, bool enable)
    {
      GetGroup(uniqueCode)?.Enable(enable);
    }

    public void ShowGroup(string uniqueCode, bool show)
    {
      GetGroup(uniqueCode)?.Show(show);
    }

    public void GotoGroup(string uniqueCode)
    {
      GetGroup(uniqueCode)?.Goto();
    }

    public void EnableGroupItems(string uniqueCode, bool enable)
    {
      GetGroup(uniqueCode)?.EnableItems(enable);
    }

    public void ShowGroupItems(string uniqueCode, bool show)
    {
      GetGroup(uniqueCode)?.ShowItems(show);
    }
  }
}