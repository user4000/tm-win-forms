using System.Data;
using System.Linq;

namespace TmWinForms.Extensions
{
  internal static class XxDataTable
  {
    internal static DataRow ZzFindRowByKey(this DataTable Table, string KeyField, string KeyValue) => Table.Select($"{KeyField}={KeyValue}").FirstOrDefault();

  }
}