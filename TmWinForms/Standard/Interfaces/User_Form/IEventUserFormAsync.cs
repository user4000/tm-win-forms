using System.Threading.Tasks;

namespace TmWinForms
{
  public interface IEventUserFormAsync
  {
    Task EventUserFormAsync(bool flag, string text, object arg);
  }
}