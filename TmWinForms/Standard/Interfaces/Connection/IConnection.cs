namespace TmWinForms
{
  public interface IConnection
  {
    void EventConnected(bool connected, bool connectedFirstTime, string text, object arg);
  }
}