using System;
using System.Drawing;
using Telerik.WinControls.UI;
using static TmWinForms.FrameworkManager;

namespace TmWinForms
{
  partial class FrameworkService
  {
    RadPageViewPage CreateNewPageInnerMethod(SubForm form)
    {
      RadPageViewPage page = null;

      if ((FlagAboutProgramFormHasBeenCreated == false) && (IsAboutProgramForm(form)))
      {
        // Проверим, является ли данная форма формой типа "О программе" и если является, то поместим её на уже существующую вкладку //
        FlagAboutProgramFormHasBeenCreated = true;
        page = MainForm.PageAboutProgram; // Новую вкладку создавать не нужно, вкладка уже существует и находится на фиксированном месте //
        page.Name = form.UniqueName;
        page.Text = form.PageText;        
        return page;
      }

      page = new RadPageViewPage() { Name = form.UniqueName, Text = form.PageText };      // Создание новой вкладки //
      MainForm.PvMain.Pages.Insert(++IndexPage, page); // Помещение новой вкладки по индексу в определённом порядке //

      return page;
    }

    internal RadPageViewPage CreateNewPage(SubForm form)
    {
      RadPageViewPage page = null;

      if (FlagItIsTimeToAddStandardForms == false)
      {
        page = CreateNewPageInnerMethod(form);
      }
      else
      {
        page = TryToFindExistingPage(form.Form);
      }

      if (page == null) throw new ApplicationException("Error! Failed to find a [PageView] for standard form!"); 

      MainForm.PvMain.SelectedPage = null;

      page.ItemSize = new SizeF(120F, 30);
      page.Location = new Point(10, 10);
      page.TextAlignment = ContentAlignment.MiddleCenter;

      RadPageViewStripElement element = (RadPageViewStripElement)MainForm.PvMain.GetChildAt(0);

      element.ShowItemPinButton = false;
      element.StripButtons = StripViewButtons.Scroll;
      element.ItemAlignment = StripViewItemAlignment.Near;
      element.ItemFitMode = StripViewItemFitMode.FillHeight;
      element.ShowItemCloseButton = false;
      element.ItemSpacing = FrameworkSettings.PageViewItemSpacing;

      if (FrameworkSettings.StripOrientation != StripViewAlignment.Top) SetMainPageViewTabOrientation(FrameworkSettings.StripOrientation);

      return page;
    }
  }
}