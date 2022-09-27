using Telerik.WinControls.UI;
using TmWinForms.Standard;

namespace TmWinForms.Extensions
{
  public static class XxGridViewRowInfo
  {
    public static string ZzGetCellValue(this GridViewRowInfo row, string FieldName) => row.Cells[CxStandard.GetGridColumnName(FieldName)].Value.ToString();
  }
}