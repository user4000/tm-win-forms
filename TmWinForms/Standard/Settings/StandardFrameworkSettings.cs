﻿using System;
using System.IO;
using System.Drawing;
using Newtonsoft.Json;
using TmWinForms.Tools;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace TmWinForms
{
  [JsonObject(MemberSerialization.OptIn)]
  public class StandardFrameworkSettings : StandardJsonSettings<StandardFrameworkSettings>
  {

    private int tabMinWidth = 100;

    public int TabMinimumWidth // Минимальная ширина вкладки //
    {
      get => tabMinWidth;
      set
      {
        bool ValueIsOk = ((value >= 50) && (value <= 500));
        if (ValueIsOk)
          tabMinWidth = value;
        else
          tabMinWidth = 100;
      }
    }

    public string ThemeName { get; set; } = string.Empty; // Если пользователь задаст это значение, то фреймворк постарается найти и применить данную тему //

    public bool FlagMainPageViewVisibleWhileMainFormIsStarting { get; set; } = true;


    public int MainFormDelayMillisecondsBeforeUserFormsAreLoaded { get; set; } = 500;


    private Font pageViewFont = new Font("Verdana", 9, FontStyle.Regular);

    public Font PageViewFont
    {
      get => pageViewFont;
      set
      {
        bool CheckIsNull = FrameworkManager.MainForm?.PvMain?.Font == null ? true : false;
        bool ValueIsOK = ((value.Size >= 8) && (value.Size <= 20));

        if (ValueIsOK)
        {
          pageViewFont = value;
          if (CheckIsNull == false) FrameworkManager.MainForm.PvMain.Font = pageViewFont;
        }
      }
    }

    public Font FontAlertCaption { get; set; } = new Font("Verdana", 9);

    public Font FontAlertText { get; set; } = new Font("Verdana", 9);

    /*-----------------------------------------------------------------------------------------------------*/
    //public bool PreviousAlertDisappears { get; set; } = false;
    /*-----------------------------------------------------------------------------------------------------*/
    public int MainFormMargin { get; set; } = 20;
    /*-----------------------------------------------------------------------------------------------------*/
    public PageViewItemSizeMode ItemSizeMode { get; set; } = PageViewItemSizeMode.EqualHeight; //PageViewItemSizeMode.Individual ;
    /*-----------------------------------------------------------------------------------------------------*/
    public int PageViewItemSpacing { get; set; } = 10;
    /*-----------------------------------------------------------------------------------------------------*/
    private Size pageViewItemSize = new Size(100, 27);
    public Size PageViewItemSize
    {
      get => pageViewItemSize;
      set
      {
        bool CheckIsNull = FrameworkManager.MainForm?.PvMain?.ItemSize == null ? true : false;
        bool ValueIsOK = ((value.Height >= 10) && (value.Width >= 10));

        if (ValueIsOK)
        {
          pageViewItemSize = value;
          if (CheckIsNull == false) FrameworkManager.MainForm.PvMain.ItemSize = pageViewItemSize;
        }
      }
    }
    /*-----------------------------------------------------------------------------------------------------*/
    private int maxAlertCount = 5;
    public int MaxAlertCount
    {
      get => maxAlertCount;
      set { if ((value > 0) && (value < 11)) maxAlertCount = value; }
    }
    /*-----------------------------------------------------------------------------------------------------*/

    public bool LimitNumberOfAlerts { get; set; } = true;


    private MsgPos defaultAlertPosition = MsgPos.BottomRight;
    public MsgPos DefaultAlertPosition
    {
      get => defaultAlertPosition;
      set { if ((value != MsgPos.Unknown) && (value != MsgPos.ScreenCenter) && (value != MsgPos.Manual)) defaultAlertPosition = value; }
    }


    /*-----------------------------------------------------------------------------------------------------*/
    private int secondsAlertAutoClose = 7;
    public int SecondsAlertAutoClose
    {
      get => secondsAlertAutoClose;
      set { if ((value >= 1) && (value <= 864000)) secondsAlertAutoClose = value; }
    }
    /*-----------------------------------------------------------------------------------------------------*/
    private byte valueColumnWidthPercent = 0;
    public byte ValueColumnWidthPercent
    {
      get => valueColumnWidthPercent;
      set { if ((value <= 90) && (value >= 10)) valueColumnWidthPercent = value; }
    }
    /*-----------------------------------------------------------------------------------------------------*/
    private Padding propertyGridPadding = new Padding(30, 30, 30, 30);
    public Padding PropertyGridPadding
    {
      get => propertyGridPadding;
      set
      {
        if
          (
          (value.Left <= 300) &&
          (value.Left >= 10) &&
          (value.Right <= 300) &&
          (value.Right >= 10) &&
          (value.Top <= 300) &&
          (value.Top >= 10) &&
          (value.Bottom <= 300) &&
          (value.Bottom >= 10)
          )
          propertyGridPadding = value;
      }
    }

    private string headerFormSettings = "Settings";

    public string HeaderFormSettings
    {
      get => headerFormSettings;
      set
      {
        if (!string.IsNullOrWhiteSpace(value)) headerFormSettings = value;
      }
    }

    private string headerFormExit = "Exit";

    public string HeaderFormExit
    {
      get => headerFormExit;
      set
      {
        if (!string.IsNullOrWhiteSpace(value)) headerFormExit = value;
      }
    }

    private string headerFormLog = "Message log";

    public string HeaderFormLog
    {
      get => headerFormLog;
      set
      {
        if (!string.IsNullOrWhiteSpace(value)) headerFormLog = value;
      }
    }

    private string confirmExitButtonText = string.Empty;


    public string ConfirmExitButtonText { get; set; }












    public bool MainFormMinimizeBeforeClosing { get; set; } = false;




    /*-----------------------------------------------------------------------------------------------------*/
    public bool RememberMainFormLocation { get; set; } = false;
    /*-----------------------------------------------------------------------------------------------------*/
    public bool MainPageViewReducePadding { get; set; } = false;

    public bool MainFormMinimizeToTray { get; set; } = false;


    public bool VisualEffectOnStart { get; set; } = false;

    public bool VisualEffectOnExit { get; set; } = false;


    public bool MainFormCloseButtonActsAsMinimizeButton { get; set; } = false;


    public bool MainFormCloseButtonMustNotCloseForm { get; set; } = false;



    [JsonProperty]
    public Point MainFormLocation { get; set; } = default(Point);

    [JsonProperty]
    public Size MainFormSize { get; set; } = default(Size);



    private void GetMainFormLocation()
    {
      this.MainFormLocation = FrameworkManager.MainForm.Location;
      this.MainFormSize = FrameworkManager.MainForm.Size;
    }

    private void CheckErrorFileNamedAsDirectory()
    {
      if (File.Exists(DefaultFolderUserSettings))
        try
        {
          File.Delete(DefaultFolderUserSettings);
        }
        catch (Exception ex)
        {
          string h = $"Could not delete file <<{DefaultFolderUserSettings}>> which prevents to save framework settings";
          FrameworkManager.SaveErrorToTextFile(h, ex);
          //Log.Save(ex, h, MsgType.Error);
          //Ms.Error(h, ex).Pos(MsgPos.BottomRight).Delay(10).Create();
        }
    }

    internal override void Save(string fileName = FrameworkSettingsFileName)
    {
      if (RememberMainFormLocation == false) return;
      if (FrameworkManager.MainForm.WindowState != FormWindowState.Normal) return;

      GetMainFormLocation();

      CheckErrorFileNamedAsDirectory();
      try
      {
        base.Save(fileName);
      }
      catch (Exception ex)
      {
        string h = $"Could not save framework settings file {fileName}";
        FrameworkManager.SaveErrorToTextFile(h, ex);
        //Log.Save(ex, h, MsgType.Error);
        //Ms.Error(h, ex).Pos(MsgPos.BottomRight).Delay(10).Create();
      }
    }

    internal void RestoreMainFormLocationAndSize()
    {
      if (RememberMainFormLocation == false) return;
      StandardFrameworkSettings settings = null;

      try
      {
        settings = Load();
      }
      catch (Exception ex)
      {
        string h = "Could not load framework settings.";
        FrameworkManager.SaveErrorToTextFile(h, ex);
        //Log.Save(ex, h, MsgType.Fail);
        //Ms.Error(h, ex).Pos(MsgPos.BottomRight).Delay(10).Create();
      };

      if (settings == null)
        try
        {
          CxTools.CreateDirectoryForFile(FrameworkSettingsFileName);
        }
        catch (Exception ex)
        {
          string h = "Could not create directory for framework settings file.";
          FrameworkManager.SaveErrorToTextFile(h, ex);
          //Log.Save(ex, h, MsgType.Error);
          //Ms.Error(h, ex).Pos(MsgPos.BottomRight).Delay(10).Create();
        }
      else
      {
        FrameworkManager.Service.RestoreMainFormLocationAndSize(settings.MainFormLocation, settings.MainFormSize);
      }
    }
  }
}