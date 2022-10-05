using System;

namespace TmWinForms.Logger
{
  public interface IFrameworkLogger
  {
    void Save(string message);

    void Save(string header, string message);

    void Save(MsgType type, string header, string message);

    void Save(Exception exception, string message, MsgType type = MsgType.Error);

  }
}