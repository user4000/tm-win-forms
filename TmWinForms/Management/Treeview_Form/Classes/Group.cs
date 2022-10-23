using System;
using System.Threading.Tasks;

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
    }

    internal static Group Create(string code, string text, string rank, bool expandOnSelect, bool collapseOnExit)
    {
      Group group = new Group(code, text, rank, expandOnSelect, collapseOnExit);
      return group;
    }

    internal void SetText(string text) => Text = text;

    internal void SetNode(CxNode node) => Node = node;
  }
}
