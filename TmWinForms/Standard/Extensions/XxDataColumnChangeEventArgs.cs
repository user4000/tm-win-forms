﻿using System.Data;

namespace TmWinForms.Extensions
{

  public static class XxDataColumnChangeEventArgs
  {
    public static string ZzProposedValue(this DataColumnChangeEventArgs e)
    {
      return e.ProposedValue==null ? string.Empty : e.ProposedValue.ToString();
    }
  }
}