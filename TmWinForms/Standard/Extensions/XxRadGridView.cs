using System;
using Telerik.WinControls.UI;
using System.Collections.Generic;

namespace TmWinForms.Extensions
{
  internal static class XxRadGridView
  {
    private static string ZzGetStringValue(this RadGridView grid, string GridColumnName)
    {// Получим значение ячейки в указанном столбце текущей строки //
      string s = string.Empty;
      if (grid.SelectedRows.Count > 0)
      try
      {
        GridViewRowInfo row = grid.SelectedRows[0];
        s = row.Cells[GridColumnName].Value.ToString() ?? string.Empty;
      }
      catch 
      {
         // TmWinForms.Logger.Manager.Log.Save(ex, "ZzGetStringValue");
      }
      return s;
    }

    internal static string ZzGetStringValueByFieldName(this RadGridView grid, string FieldName) => ZzGetStringValue(grid, CxStandard.GetGridColumnName(FieldName));

    internal static void ZzLoadColumnWidth(this RadGridView grid, Dictionary<string, int> d)
    {
      int width = 0;
      try
      {
        for (int i = 0; i < grid.ColumnCount; i++)
          if (d.TryGetValue(grid.Columns[i].FieldName, out width))
            grid.Columns[i].Width = width;
      }
      catch { }
    }

    internal static void ZzDisposeAllColumns(this RadGridView grid)
    {
      GridViewDataColumn col;
      for (int i = 0; i < grid.ColumnCount; i++)
      {
        col = grid.Columns[0];
        grid.Columns.Remove(col);
        col.FieldName = string.Empty;
        col.Dispose();
      }
      grid.Columns.Clear();
    }

    internal static void ZzDispose(this RadGridView grid)
    {
      grid.Visible = false;
      grid.DataSource = null;
      grid.ZzDisposeAllColumns();
      grid.Dispose();
    }
  }
}