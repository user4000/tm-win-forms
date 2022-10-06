using System;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace TmWinForms
{
  partial class FrameworkManager
  {
    private static ushort MainFormClosingCounter { get; set; } = 0;

    internal static bool UserHasClickedExitButton { get; set; } = false;




    private static async void EventMainFormClosing(object sender, FormClosingEventArgs e) // Событие: поступил сигнал "Закрыть главную форму приложения" //
    {
      // ------------------------------------------------------------------------------------------------------------- //
      if ((FrameworkSettings.MainFormCloseButtonActsAsMinimizeButton) && (UserHasClickedExitButton == false))
      {
        MainForm.WindowState = FormWindowState.Minimized;
        e.Cancel = true;
        return;
      }
      // ------------------------------------------------------------------------------------------------------------- //
      if ((FrameworkSettings.MainFormCloseButtonMustNotCloseForm) && (UserHasClickedExitButton == false))
      {
        e.Cancel = true;
        return;
      }
      // ------------------------------------------------------------------------------------------------------------- //
      
      if (MainFormClosingCounter > 0) return; // Со второго захода выполнится инструкция return в данном условии //

      /* =============================================================================================================== */

      // Всё, что ниже этого комментария выполнится только 1 раз с первого захода. 
      // А со второго захода в этом методе выполнение до этой строки уже не дойдёт (см. инструкцию return выше).

      e.Cancel = true; // С первого раза этот метод не закроет форму. А со второго захода закроет. И в этом нам поможет переменная MainFormClosingCounter //




      Service.ExecEndWorkHandlerForEachSubForm();

      FrameworkSettings.Save();      // Записать местоположение формы и её размер нужно до того, как мы её минимизируем //




      if (FrameworkSettings.FlagMinimizeMainFormBeforeClosing)
      {
        MainForm.WindowState = FormWindowState.Minimized; // Очень важная строка //
      }
      else if (FrameworkSettings.VisualEffectOnExit)
      {
        MainForm.VisualEffectFadeOut();
      }



      Log.EventEndWork(); // Завершаем работу логгера //

      await Task.Delay(500);


      // Если не выполнить строку MainForm.WindowState = FormWindowState.Minimized; 
      // тогда программа может выдать исключение "Ошибка при создании дескриптора окна".
      // System.ComponentModel.Win32Exception: Error creating window handle.
      // Причём это происходит для приложения, которое было свёрнуто в system tray и потом заново активировано двойным кликом по иконке.


      // await Service.MainExit();

      MainFormClosingCounter++;

      MainForm.Close(); // Эта команда вызовет данный метод повторно //

      /* =============================================================================================================== */
    }
  }
}