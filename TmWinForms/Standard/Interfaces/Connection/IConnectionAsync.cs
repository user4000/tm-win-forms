using System.Threading.Tasks;

namespace TmWinForms
{
  public interface IConnectionAsync
  {
    Task EventConnectedAsync(bool connected, bool connectedFirstTime, string text, object arg);
  }
}