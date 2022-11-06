using System;
using System.Collections.Generic;

namespace TmWinForms
{
  public class Group
  {
    public string Text { get; private set; }

    public string Code { get; private set; }

    public string Rank { get; private set; }


    public bool ExpandOnSelect { get; private set; } = false;

    public bool CollapseOnExit { get; private set; } = false;

    public CxNode Node { get; private set; }

    public List<TvForm> Forms { get; } = new List<TvForm>();

    private Group()
    {

    }

    private Group(string code, string text, string rank, bool expandOnSelect, bool collapseOnExit)
    {
      Text = text ?? string.Empty;
      Code = code ?? string.Empty;
      Rank = rank ?? string.Empty;
      ExpandOnSelect = expandOnSelect;
      CollapseOnExit = collapseOnExit;

      if (string.IsNullOrWhiteSpace(Code))
      {
        FrameworkManager.Error("Error!", "The unique code of the group is empty!");
      }
    }

    internal static Group Create(string code, string text, string rank, bool expandOnSelect, bool collapseOnExit)
    {
      Group group = new Group(code, text, rank, expandOnSelect, collapseOnExit);
      return group;
    }

    internal void EventFormAddedToGroup(TvForm tvForm)
    {
      Forms.Add(tvForm);
    }

    internal void SetText(string text) => Text = text;

    internal void SetNode(CxNode node) => Node = node;





    public void Enable(bool enable)
    {
      Node.Enabled = enable;
      foreach (var node in Node.Nodes)
      {
        node.Enabled = enable;
      }
    }

    public void Show(bool show)
    {
      Node.Visible = show;
      foreach (var node in Node.Nodes)
      {
        node.Visible = show;
      }
    }

    public void EnableItems(bool enable)
    {
      foreach(var node in Node.Nodes)
      {
        node.Enabled = enable;
      }
    }

    public void ShowItems(bool show)
    {
      foreach (var node in Node.Nodes)
      {
        node.Visible = show;
      }
    }

    public void Goto()
    {
      Node.TreeView.SelectedNode = Node;
    }

    public void Expand()
    {
      Node.ExpandAll();
    }

    public void Collapse()
    {
      Node.Collapse();
    }
  }
}
