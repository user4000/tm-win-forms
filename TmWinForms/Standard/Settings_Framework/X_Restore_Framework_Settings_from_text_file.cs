using System;
using static TmWinForms.FrameworkManager;

namespace TmWinForms
{
  partial class StandardFrameworkSettings
  {
    void RestoreValuesFromFile() // NOTE: Здесь восстанавливаются из файла некоторые настройки фреймворка //
    {
      StandardFrameworkSettings settings = SettingsLoadedFromFile;
      if (settings == null) return;

      FrameworkSettings.MainFormSize = settings.MainFormSize;

      FrameworkSettings.MainFormLocation = settings.MainFormLocation;

      FrameworkSettings.StartTimerIntervalMilliseconds = settings.StartTimerIntervalMilliseconds;

      FrameworkSettings.StartTimerAsyncIntervalMilliseconds = settings.StartTimerAsyncIntervalMilliseconds;

      FrameworkSettings.StripOrientation = settings.StripOrientation;

      FrameworkSettings.TimeCheckOldLogFiles = settings.TimeCheckOldLogFiles;

      FrameworkSettings.FlagMinimizeMainFormBeforeClosing = settings.FlagMinimizeMainFormBeforeClosing;

      FrameworkSettings.ConfirmExit = settings.ConfirmExit;

      FrameworkSettings.RememberMainFormLocation = settings.RememberMainFormLocation;

      FrameworkSettings.VisualEffectOnStart = settings.VisualEffectOnStart;

      FrameworkSettings.VisualEffectOnExit = settings.VisualEffectOnExit;

      FrameworkSettings.TabMinimumWidth = settings.TabMinimumWidth;

      FrameworkSettings.PageViewFont = settings.PageViewFont;

      FrameworkSettings.FontAlertCaption = settings.FontAlertCaption;

      FrameworkSettings.FontAlertText = settings.FontAlertText;

      FrameworkSettings.PageViewItemSpacing = settings.PageViewItemSpacing;

      FrameworkSettings.MaxAlertCount = settings.MaxAlertCount;

      FrameworkSettings.SecondsAlertAutoClose = settings.SecondsAlertAutoClose;

      FrameworkSettings.ValueColumnWidthPercent = settings.ValueColumnWidthPercent;

      FrameworkSettings.ThemeName = settings.ThemeName;

      FrameworkSettings.MainFormCloseButtonActsAsMinimizeButton = settings.MainFormCloseButtonActsAsMinimizeButton;

      FrameworkSettings.MainFormCloseButtonMustNotCloseForm = settings.MainFormCloseButtonMustNotCloseForm;

      FrameworkSettings.HideMainPageViewBeforeMainFormIsShown = settings.HideMainPageViewBeforeMainFormIsShown;

      FrameworkSettings.FlagMainFormStartMinimized = settings.FlagMainFormStartMinimized;

      FrameworkSettings.FlagMinimizeMainFormToSystemTray = settings.FlagMinimizeMainFormToSystemTray;

      FrameworkSettings.MainFormCaption = settings.MainFormCaption;

      FrameworkSettings.TreeviewNavigationAlwaysExpandOnSelect = settings.TreeviewNavigationAlwaysExpandOnSelect;

      FrameworkSettings.TreeviewPanelWidth = settings.TreeviewPanelWidth;

      FrameworkSettings.AllowLoadingImagesForTreeviewFromFiles = settings.AllowLoadingImagesForTreeviewFromFiles;

      FrameworkSettings.ColorTreeviewBackground = settings.ColorTreeviewBackground;

      FrameworkSettings.TreeviewIsLocatedOnTheLeftSide = settings.TreeviewIsLocatedOnTheLeftSide;

      FrameworkSettings.FontTreeviewGroupNode = settings.FontTreeviewGroupNode;

      FrameworkSettings.FontTreeviewSubFormNode = settings.FontTreeviewSubFormNode;

      FrameworkSettings.ColorTreeviewGroupNode = settings.ColorTreeviewGroupNode;

      FrameworkSettings.ColorTreeviewGroupNodeDisabled = settings.ColorTreeviewGroupNodeDisabled;

      FrameworkSettings.ColorTreeviewSubFormNode = settings.ColorTreeviewSubFormNode;

      FrameworkSettings.ColorTreeviewSubFormNodeDisabled = settings.ColorTreeviewSubFormNodeDisabled;

      FrameworkSettings.TreeviewEnableHotTracking = settings.TreeviewEnableHotTracking;
    }




    internal void CheckFrameworkSettings() // Проверка согласованности настроек //
    {
      if (FrameworkSettings.FlagMainFormStartMinimized) // Запускать приложение в минимизированном виде //
      {
        FrameworkSettings.VisualEffectOnStart = false;
        FrameworkSettings.HideMainPageViewBeforeMainFormIsShown = false;
        FrameworkSettings.MainFormCloseButtonActsAsMinimizeButton = true;
        FrameworkSettings.FlagMinimizeMainFormToSystemTray = true;
        FrameworkSettings.ConfirmExit = true;
      }

      if ((FrameworkSettings.FlagMainFormStartMinimized) && (FlagSystemTrayIconIsConfigured == false))
      {
        // Приложение - серверное, но программист не настроил иконку для системного лотка. Придётся сделать это за него //
        SetIconForSystemTray(null);
      }
    }






    internal void RestoreMainFormLocationAndSize()
    {
      if (SettingsLoadedFromFile == null) return;
      Service.RestoreMainFormLocationAndSize(SettingsLoadedFromFile.MainFormLocation, SettingsLoadedFromFile.MainFormSize);
    }
  }
}