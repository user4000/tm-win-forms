using System;
using System.Drawing;
using TmWinForms.Tools;
using Telerik.WinControls;
using System.Windows.Forms;
using System.ComponentModel;
using Telerik.WinControls.UI;
using System.Collections.Concurrent;

namespace TmWinForms
{
  public class TmAlertService
  {
    private int ConstDx { get; } = 10;

    private int ConstDy { get; } = 10;

    private int ScreenHeight { get => Screen.PrimaryScreen.WorkingArea.Height; }

    private int ScreenWidth { get => Screen.PrimaryScreen.WorkingArea.Width; }

    private int AlertHeaderMaxLength { get; } = 200;

    private int AlertMessageMaxLength { get; } = 2000;

    private PopupCloseInfo AlertCloseInfo { get; } = null;

    private FrameworkService Service { get; } = null;

    private Container ContainerForAlerts { get; } = new Container();

    private TmAlertPainter Painter { get; } = new TmAlertPainter();

    private TmAlert PreviousAlert { get; set; } = null;

    private ConcurrentQueue<TmAlert> QueueAlert { get; } = new ConcurrentQueue<TmAlert>();

    internal TmAlertService(FrameworkService HostService, RadForm OwnerOfContainer)
    {
      Service = HostService;
      AlertCloseInfo = new PopupCloseInfo(RadPopupCloseReason.Mouse, this);
      ContainerForAlerts.Add(OwnerOfContainer);
    }

    public void ShowAlert(TmMessage Message)
    {
      TmAlert Alert = new TmAlert(ContainerForAlerts)
      {
        CaptionText = Message.Header.Length > AlertHeaderMaxLength ? Message.Header.StringLeft(AlertHeaderMaxLength) : Message.Header,
        ContentText = Message.Text.Length > AlertMessageMaxLength ? Message.Text.StringLeft(AlertMessageMaxLength) : Message.Text,
        AutoCloseDelay = Message.AutoCloseDelay > 0 ? Message.AutoCloseDelay : FrameworkManager.FrameworkSettings.SecondsAlertAutoClose
      };

      Painter.SetColor(Alert, Message.MessageType);
      SetAlertPicture(Alert, Message);
      SetAlertFont(Alert);

      CheckDelaySeconds(Alert, Message);
      CheckPosition(Alert, Message);
      CheckAlertPinButton(Alert, Message.FlagShowPinButton);
      CheckAlertHasIndividualSize(Alert, Message);
      CheckAlertPinned(Alert, Message.FlagPinned);
      CheckAlertCloseOnClick(Alert, Message.FlagCloseOnClick);
      CheckRemovePreviousAlerts(Alert, Message.FlagRemovePreviousAlerts);
      
      Alert.Show();

      //CorrectAlertPosition(Alert, Message.AlertControl);
      CorrectAlertPosition(Alert, Message.AlertControl, Message.AlertRadElement);

      MoveAlertToScreenCenter(Alert, Message.AlertPosition, Message.AlertControl);
      CheckAlertHasOffset(Alert, Message.AlertOffset);
      CheckPreviousAlert(Alert);
      CheckQueue(Alert);
      PreviousAlert = Alert;
    }

    private void CheckQueue(TmAlert Alert)
    {
      if ((FrameworkManager.FrameworkSettings.LimitNumberOfAlerts) && (Alert != null))
      {
        QueueAlert.Enqueue(Alert);
        if (QueueAlert.Count > FrameworkManager.FrameworkSettings.MaxAlertCount)
          if (QueueAlert.TryDequeue(out TmAlert item))
          {
            item?.Hide(); item?.Dispose();
          }
      }
    }

    private void CheckPreviousAlert(TmAlert Alert)
    {
      if (PreviousAlert == null) return;
      if (CxTools.SquareOfDistance(PreviousAlert.Popup.Location, Alert.Popup.Location) < 25)
      {
        PreviousAlert.Popup.Location = new Point(PreviousAlert.Popup.Location.X - 30, PreviousAlert.Popup.Location.Y - 30);
      }
    }

    private void CheckAlertCloseOnClick(TmAlert Alert, bool FlagCloseOnClick)
    {
      if (FlagCloseOnClick) Alert.Popup.Click += (s, e) => Alert.Popup.ClosePopup(AlertCloseInfo);
    }

    private void SetAlertFont(TmAlert Alert)
    {
      Alert.Popup.AlertElement.CaptionElement.TextAndButtonsElement.Font = FrameworkManager.FrameworkSettings.FontAlertCaption;
      Alert.Popup.AlertElement.ContentElement.Font = FrameworkManager.FrameworkSettings.FontAlertText;
    }

    private bool EnoughSpaceForPicture(TmMessage Message)
    {
      return (Message.AlertSize == CxStandard.ZeroSize) || (Message.AlertSize.Height == 0) || (Message.AlertSize.Height > 60);
    }

    private void SetAlertPicture(TmAlert Alert, TmMessage Message)
    {
      if ((Message.FlagIcon) && (EnoughSpaceForPicture(Message)))
        Alert.ContentImage = Service.GetImageByMessageType(Message.MessageType);
    }

    private void CheckAlertPinned(TmAlert Alert, bool FlagPinned)
    {
      Alert.IsPinned = FlagPinned;
    }

    private void CheckRemovePreviousAlerts(TmAlert Alert, bool RemovePrevious)
    {
      if (RemovePrevious) RemoveAllAlerts();
    }

    private void CheckAlertPinButton(TmAlert Alert, bool FlagShowPinButton)
    {
      Alert.ShowPinButton = FlagShowPinButton;
    }

    private void CheckPosition(TmAlert Alert, TmMessage Message)
    {
      if (Message.AlertControl == null)
      {
        if (Message.AlertPosition == MsgPos.ScreenCenter) // Screen Center position //
          Alert.ScreenPosition = AlertScreenPosition.Manual;
        else
          Alert.ScreenPosition = (AlertScreenPosition)((Message.AlertPosition == MsgPos.Unknown) ? FrameworkManager.FrameworkSettings.DefaultAlertPosition : Message.AlertPosition);
      }
      else
      {
        Alert.ScreenPosition = AlertScreenPosition.Manual;
      }
    }

    private void CheckDelaySeconds(TmAlert Alert, TmMessage Message)
    {
      Alert.AutoCloseDelay = Message.AutoCloseDelay > 0 ? Message.AutoCloseDelay : FrameworkManager.FrameworkSettings.SecondsAlertAutoClose;
    }

    private void CorrectAlertPosition(TmAlert Alert, Control AlertControl, RadElement AlertElement)
    {
      // Попробуем привязать координаты всплывающего окна к координатам элемента типа Control или RadElement //
      if ((AlertControl == null) && (AlertElement == null)) return;
      if (AlertElement != null)
        CorrectAlertPosition(Alert, AlertElement);
      else
        CorrectAlertPosition(Alert, AlertControl);
    }

    private void CorrectAlertPosition(TmAlert Alert, RadElement AlertElement)
    { // If alert window runs out of the screen we should correct its position //

      if (AlertElement == null) return;
      // Попробуем привязать координаты всплывающего окна к координатам элемента типа RadElement //
      Point p = new Point(0, 0);
      int AlertHeight = Alert.Popup.DisplayRectangle.Height;
      int AlertWidth = Alert.Popup.DisplayRectangle.Width;

      try
      {
        p = AlertElement.PointToScreen(Point.Empty);
      }
      catch
      {
        return;
      }

      if (p.Y < (ScreenHeight / 2))
        p.Y += AlertElement.Size.Height + ConstDy;
      else
        p.Y -= (AlertHeight + ConstDy);

      if (p.X < 0) p.X = ConstDx;

      if ((p.X + AlertWidth) > ScreenWidth) p.X = ScreenWidth - AlertWidth - ConstDx;

      Alert.Popup.Location = p;
    }

    private void CorrectAlertPosition(TmAlert Alert, Control AlertControl)
    { // If alert window runs out of the screen we should correct its position //

      if (AlertControl == null) return;
      // Попробуем привязать координаты всплывающего окна к координатам элемента типа Control //
      Point p = new Point(0, 0);
      int AlertHeight = Alert.Popup.DisplayRectangle.Height;
      int AlertWidth = Alert.Popup.DisplayRectangle.Width;

      try
      {
        p = AlertControl.PointToScreen(Point.Empty);
      }
      catch
      {
        return;
      }

      if (p.Y < (ScreenHeight / 2))
        p.Y += AlertControl.Height + ConstDy;
      else
        p.Y -= (AlertHeight + ConstDy);

      if (p.X < 0) p.X = ConstDx;

      if ((p.X + AlertWidth) > ScreenWidth) p.X = ScreenWidth - AlertWidth - ConstDx;

      Alert.Popup.Location = p;
    }

    private void MoveAlertToScreenCenter(TmAlert Alert, MsgPos AlertPosition, Control AlertControl)
    {
      if ((AlertControl == null) && (AlertPosition == MsgPos.ScreenCenter))
        Alert.Popup.Location = new Point
        (
        ScreenWidth / 2 - Alert.Popup.DisplayRectangle.Width / 2,
        ScreenHeight / 2 - Alert.Popup.DisplayRectangle.Height / 2
        );      
    }

    private void CheckAlertHasOffset(TmAlert Alert, Point Offset)
    {
      if ((Offset.X == 0) && (Offset.Y == 0)) return;
      Alert.Popup.Location = new Point(Alert.Popup.Location.X + Offset.X, Alert.Popup.Location.Y + Offset.Y);
    }

    private void CheckAlertHasIndividualSize(TmAlert Alert, TmMessage Message)
    {
      if (Message.AlertSize != CxStandard.ZeroSize)
        Alert.FixedSize =
          new Size
          (
            Message.AlertSize.Width <= 10 ? Alert.Popup.Size.Width : Message.AlertSize.Width,
            Message.AlertSize.Height <= 10 ? Alert.Popup.Size.Height : Message.AlertSize.Height
          );
    }

    public void RemoveAllAlerts()
    {
      TmAlert item; int i = 1;
      while (QueueAlert.TryDequeue(out item))
      {
        item?.Hide(); item?.Dispose();
        if (i++ > 100) break;
      }
    }

    private string TestQueueAlert()
    {
      string s = string.Empty;
      foreach (var item in QueueAlert)
      {
        s += ((item == null) ? "NULL" : item.GetHashCode().ToString()) + "; ";
      }
      return s;
    }
  }
}